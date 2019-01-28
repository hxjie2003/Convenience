using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Cache.HttpCache
{
    public class CacheManager
    {
        public static ICache Instance
        {
            get { return HttpRuntimeCache.Default; }
        }
    }

    public enum CacheSystem
    {
        HttpRuntime,
        MemCached,
        Redis
    }
}
