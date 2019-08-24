using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Cache.Manager
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDistributedCache _cache;

        public RedisCacheManager(IDistributedCache cache)
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

        public async Task<string> GetStringAsync(string key, Func<string> func = null)
        {
            var value = await _cache.GetStringAsync(key);

            if (string.IsNullOrWhiteSpace(value))
            {
                if (func != null)
                {
                    value = func();

                    await SetStringAsync(key, value);
                }
            }

            return value;
        }

        public void SetString(string key, string value)
        {
            _cache.SetString(key, value);
        }

        public async Task SetStringAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value);
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

        public async Task<T> GetAsync<T>(string key, Func<T> func = null)
        {
            var value = await _cache.GetStringAsync(key);

            if (string.IsNullOrWhiteSpace(value))
            {
                if (func != null)
                {
                    var result = func();

                    await SetAsync(key, result);

                    return result;
                }
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }

        public void Set<T>(string key, T value)
        {
            _cache.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }

        public async Task SetAsync<T>(string key, T value)
        {
            await _cache.SetStringAsync(key, Newtonsoft.Json.JsonConvert.SerializeObject(value));
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
