using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace ETong.Cache
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiUrlsCache
    {
        private const string CACHEREGION = "apiuri";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apikey"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool Add(string apikey, string url)
        {
            var cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30);
            return cache.Add(apikey, url, policy, CACHEREGION);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apikey"></param>
        /// <returns></returns>
        public static string Get(string apikey)
        {
            var cache = MemoryCache.Default;
            return cache.Get(apikey, CACHEREGION).ToString();
        }
    }
}
