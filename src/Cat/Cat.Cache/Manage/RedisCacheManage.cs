using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Cache.Manage
{
    public class RedisCacheManage : ICacheManage
    {
        private readonly IDistributedCache _cache;

        public RedisCacheManage(IDistributedCache cache)
        {
            _cache = cache;
        }

        public string GetString(string key, Func<string> func = null)
        {
            var value = _cache.GetString(key);

            if (string.IsNullOrWhiteSpace(value))
            {
                if (func != null)
                {
                    value = func();

                    SetString(key, value);
                }
            }

            return value;
        }

        public void SetString(string key, string value)
        {
            _cache.SetString(key, value);
        }

        public T Get<T>(string key, Func<T> func = null)
        {
            var value = _cache.GetString(key);

            if (string.IsNullOrWhiteSpace(value))
            {
                if (func != null)
                {
                    var result = func();

                    Set(key, result);

                    return result;
                }
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }

        public void Set<T>(string key, T value)
        {
            _cache.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }
    }
}
