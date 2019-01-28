using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Cache.HttpCache
{
    public interface ICache
    {
        void Set<T>(string key, T value,TimeSpan? validFor=null);
        void Remove(string key);
        T Get<T>(string key);
        void Clear();

    }
}
