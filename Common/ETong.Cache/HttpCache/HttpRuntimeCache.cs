using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ETong.Cache.HttpCache
{
    public class HttpRuntimeCache : ICache
    {
        private static HttpRuntimeCache _httpRuntime = null;
        private static readonly object _locker = new object();



        public static HttpRuntimeCache Default
        {
            get
            {

                if (_httpRuntime == null)
                {
                    lock (_locker)
                    {
                        if (_httpRuntime == null)
                        {
                            _httpRuntime = new HttpRuntimeCache();
                        }
                    }
                }
                return _httpRuntime;

            }
        }

        /// <summary>
        /// 添加缓存项目
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="validFor">最后一次访问与过期时间之间的间隔</param>
        public void Set<T>(string key, T value, TimeSpan? validFor = null)
        {
            HttpRuntime.Cache.Insert(
               key,
               value,
               null,
               System.Web.Caching.Cache.NoAbsoluteExpiration,
               validFor??System.Web.Caching.Cache.NoSlidingExpiration,
               System.Web.Caching.CacheItemPriority.Normal,
               null);
        }
        /// <summary>
        /// 删除缓存项
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            try
            {
                return (T)HttpRuntime.Cache.Get(key);
            }
            catch
            {
                return default(T);
            }
        }
        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public void Clear()
        {
            var all = HttpRuntime.Cache
              .AsParallel()
              .Cast<DictionaryEntry>()
              .Select(x => x.Key.ToString())
              .ToList();

            foreach (var key in all)
            {
                Remove(key);
            }
        }
    }
}
