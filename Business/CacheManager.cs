
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework.Cache;
using EpiserverSite_CompanyIntranet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EpiserverSite_CompanyIntranet.Business
{
    public class CacheManager : ICacheManager
    {
        private readonly ISynchronizedObjectInstanceCache _cache;
        private readonly IContentLoader _contentLoader;
        private readonly IContentTypeRepository _contentTypeRepository;
        public CacheManager(IContentTypeRepository contentTypeRepository, IContentLoader contentLoader, ISynchronizedObjectInstanceCache cache)
        {
            _contentTypeRepository = contentTypeRepository;
            _contentLoader = contentLoader;
            _cache = cache;
        }
        //Depending on page types...
        public CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes)
        {
            return new CacheEvictionPolicy(duration, CacheTimeoutType.Sliding, null, dependentTypes.Select(t => GetMasterKey(t)));
        }
        //Depending on ancestor node in content tree...
        public CacheEvictionPolicy GetCacheEvictionPolicy(TimeSpan duration, IEnumerable<Type> dependentTypes, IEnumerable<ContentReference> roots)
        {
            IEnumerable<string> dependentTypesKeys = new List<string>();
            if (dependentTypes != null)
            {
                dependentTypesKeys = dependentTypes.Select(t => GetMasterKey(t));
            }
            IEnumerable<string> ancestorKeys = new List<string>();
            if (ancestorKeys != null)
            {
                ancestorKeys = roots.Select(p => GetMasterKeyForAncestor(p));
            }
            return new CacheEvictionPolicy(duration, CacheTimeoutType.Sliding, null, dependentTypesKeys.Union(ancestorKeys));
        }

        public void Remove(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        private string GetMasterKeyForAncestor(ContentReference parent)
        {
            if (parent == null)
            {
                return string.Empty;
            }
            return $"Descendants:{parent.ID}";
        }
        private string GetMasterKey(Type type)
        {
            if (type == null)
            {
                return string.Empty;
            }
            var contentType = _contentTypeRepository.Load(type);
            return GenerateMasterKey(contentType);
        }

        private string GetMasterKey(IContent content)
        {
            if (content == null)
            {
                return string.Empty;
            }
            var contentType = _contentTypeRepository.Load(content.ContentTypeID);
            return GenerateMasterKey(contentType);
        }

        private string GenerateMasterKey(ContentType type)
        {
            if (type == null)
            {
                return string.Empty;
            }
            return $"ContentDependency:{type.GUID}";
        }
        //Invalidate cache if editor has changed a matching page...
        //Remember that a page can have children that is affected as well so need to take care of those as well
        public void OnContentChange(object sender, EPiServer.ContentEventArgs e)
        {
            if (e == null || e.Content == null)
            {
                return;
            }
            var masterkey = GetMasterKey(e.Content);
            _cache.RemoveLocal(masterkey);
            if (e.ContentLink == null)
            {
                return;
            }
            var descendants = _contentLoader.GetDescendents(e.ContentLink);
            foreach (var contentLink in descendants)
            {
                var page = _contentLoader.Get<IContent>(contentLink);
                masterkey = GetMasterKey(page);
                _cache.RemoveLocal(masterkey);
            }
            masterkey = GetMasterKeyForAncestor(e.ContentLink);
            _cache.RemoveLocal(masterkey);
            var ancestors = _contentLoader.GetAncestors(e.ContentLink);
            foreach (var ancestor in ancestors)
            {
                masterkey = GetMasterKeyForAncestor(ancestor.ContentLink);
                _cache.RemoveLocal(masterkey);
            }
        }


        public T Get<T>(string key)
        {
            return CastValue<T>(_cache.Get(key));
        }

        public void Insert(string key, object value, TimeSpan timespan, IEnumerable<Type> dependentTypes)
        {
            var cacheEvictionPolicy = new CacheEvictionPolicy(timespan, CacheTimeoutType.Sliding, null, dependentTypes.Select(t => GetMasterKey(t)));
            _cache.Insert(key, value, cacheEvictionPolicy);
        }

        public void Insert(string key, object value, IEnumerable<Type> dependentTypes)
        {
            var timespan = new TimeSpan(0, 10, 0);
            var cacheEvictionPolicy = new CacheEvictionPolicy(timespan, CacheTimeoutType.Sliding, null, dependentTypes.Select(t => GetMasterKey(t)));
            _cache.Insert(key, value, cacheEvictionPolicy);
        }

        private static T CastValue<T>(object value)
        {
            if (value == null || value is DBNull)
            {
                return default(T);
            }
            var valType = value.GetType();
            if (valType.IsGenericType && valType.GetGenericTypeDefinition() == typeof(LazyObject<>))
            {
                return CastValue<T>(valType.GetProperty("Value").GetValue(value));
            }
            if (value is T)
            {
                return (T)value;
            }
            var t = typeof(T);
            t = (Nullable.GetUnderlyingType(t) ?? t);
            if (typeof(IConvertible).IsAssignableFrom(t) && typeof(IConvertible).IsAssignableFrom(value.GetType()))
            {
                return (T)Convert.ChangeType(value, t);
            }
            return default(T);
        }

        private class LazyObject<T> : Lazy<T>
        {
            public LazyObject(Func<T> valueFactory) : base(valueFactory) { }
            public LazyObject(Func<T> valueFactory, LazyThreadSafetyMode mode) : base(valueFactory, mode) { }
        }
    }
}