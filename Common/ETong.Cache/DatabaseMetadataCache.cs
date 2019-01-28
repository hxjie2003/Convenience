using ETong.Entity.Persistence.Infrasture;
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
    public class DatabaseMetadataCache

    {
   

        private static MemoryCache _cache;

        private static MemoryCache Cache
        {
            get {

                if (_cache == null)
                    _cache = MemoryCache.Default;
                return _cache; }
          
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadatakey"></param>
        /// <param name="metadatavalue"></param>
        /// <returns></returns>

        public static bool Add(string metadatakey, string metadatavalue)
        {           
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30);
            return Cache.Add(metadatakey, metadatavalue, policy);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadatakey"></param>
        /// <returns></returns>
        public static DBMetadataResult Get(string metadatakey)
        {

            return Cache.Get(metadatakey) as DBMetadataResult;
        }
    }
}
