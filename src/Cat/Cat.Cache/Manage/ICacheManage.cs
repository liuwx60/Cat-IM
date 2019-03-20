using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Cache.Manage
{
    public interface ICacheManage
    {
        string GetString(string key, Func<string> func = null);

        void SetString(string key, string value);

        T Get<T>(string key, Func<T> func = null);

        void Set<T>(string key, T value);
    }
}
