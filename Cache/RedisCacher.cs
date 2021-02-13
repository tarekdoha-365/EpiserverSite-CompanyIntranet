using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverSite_CompanyIntranet.Cache
{
    public class RedisCacher
    {
        public IDatabase SetRedisConnection()
        {
            var connectionString = string.Format("{0}:{1}", "127.0.0.1", 6379);
            var connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
            var cache = connectionMultiplexer.GetDatabase();
            return cache;
        }
        private static IDatabase cache;

        public RedisCacher()
        {
            cache = SetRedisConnection();
        }

        public object GetValue(string key)
        {
            return cache.StringGet(key);
        }

        public bool Add(string key, object value, TimeSpan? absExpiration)
        {
            return cache.StringSet(key, value.ToString(), absExpiration);
        }
    }
}