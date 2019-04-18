using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Cache.Manage
{
    public interface ICacheManage
    {
        string GetString(string key, Func<string> func = null);

        Task<string> GetStringAsync(string key, Func<string> func = null);

        void SetString(string key, string value);

        Task SetStringAsync(string key, string value);

        T Get<T>(string key, Func<T> func = null);

        Task<T> GetAsync<T>(string key, Func<T> func = null);

        void Set<T>(string key, T value);

        Task SetAsync<T>(string key, T value);

        void Remove(string key);

        Task RemoveAsync(string key);
    }
}
