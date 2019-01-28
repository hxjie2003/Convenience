using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;


namespace ETong.Utility.Cache
{
    /// <summary>
    /// 系统全局缓存操作
    /// </summary>
    public class CacheManager
    {
        /// <summary>
        /// 缓存对象集合
        /// </summary>
        static List<string> m_Caches;

        private static string m_RegionName = "Etong_Shop_Data_";

        private static CacheItemPolicy m_CacheItemPolicy = new CacheItemPolicy()
        {
            SlidingExpiration = new TimeSpan(12, 0, 0)
        };

        public static string CombineKey(string name)
        {
            return m_RegionName + name;
        }

        /// <summary>
        /// 设置缓存数据
        /// </summary>
        /// <param name="name">缓存名</param>
        /// <param name="data">缓存数据</param>
        /// <param name="exTime">缓存有效时长</param>
        public static void Set(string name, object data, TimeSpan? exTime = null)
        {

            if (MemoryCache.Default.Contains(CombineKey(name)))
            {
                Update(CombineKey(name), data);
                return;
            }

            CacheItemPolicy cacheItemPolicy = m_CacheItemPolicy;
            if (exTime != null)
            {
                cacheItemPolicy = new CacheItemPolicy()
                {
                    SlidingExpiration = exTime.Value
                };
            }

            MemoryCache.Default.Add(CombineKey(name), data, cacheItemPolicy);
        }

        /// <summary>
        /// 获取缓存数据 
        /// </summary>
        /// <param name="name">缓存名</param>
        /// <returns>object</returns>
        public static object Get(string name)
        {
            if (MemoryCache.Default.Contains(CombineKey(name)))
            {
                return MemoryCache.Default.Get(CombineKey(name));
            }
            return null;
        }

        /// <summary>
        /// 更新缓存数据
        /// </summary>
        /// <param name="name">缓存名</param>
        /// <param name="data">缓存数据</param>
        public static void Update(string name, object data)
        {
            if (MemoryCache.Default.Contains(CombineKey(name)))
            {
                MemoryCache.Default[CombineKey(name)] = data;
            }
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="name">缓存名</param>
        public static void Remove(string name)
        {
            if (MemoryCache.Default.Contains(CombineKey(name)))
            {
                MemoryCache.Default.Remove(CombineKey(name));
            }
        }

        /// <summary>
        /// 移除缓存 compareType:startwith,endwith
        /// </summary>
        /// <param name="name">缓存名</param>
        public static void Remove(string name, CompareType compareType)
        {
            var keys = new List<string>();

            if (compareType == CompareType.EndWith)
                keys = MemoryCache.Default.Where(q => q.Key.EndsWith(name)).Select(q => q.Key).ToList();
            else if (compareType == CompareType.StartWith)
                keys = MemoryCache.Default.Where(q => q.Key.StartsWith(name)).Select(q => q.Key).ToList();
            else
                keys = MemoryCache.Default.Where(q => q.Key.Equals(name)).Select(q => q.Key).ToList();

            foreach (var key in keys)
            {
                if (key.Contains(m_RegionName))
                {
                    MemoryCache.Default.Remove(key);
                }
            }

            GC.Collect();
        }

        /// <summary>
        /// 查找缓存
        /// </summary>
        public static List<T> Find<T>(string name, CompareType compareType)
        {
            List<T> result = new List<T>();

            if (compareType == CompareType.EndWith)
            {
                result = MemoryCache.Default.Where(q => q.Key.EndsWith(name)).Select(q => q.Value).Cast<T>().ToList();
            }
            else if (compareType == CompareType.StartWith)
            {
                result = MemoryCache.Default.Where(q => q.Key.StartsWith(name)).Select(q => q.Value).Cast<T>().ToList();
            }
            else
            {
                result = MemoryCache.Default.Where(q => q.Key.Equals(name)).Select(q => q.Value).Cast<T>().ToList();
            }

            GC.Collect();
            return result;
        }

        /// <summary>
        /// 清除以某前缀开头的全部缓存
        /// </summary>
        public static void Clear(string strPrefix)
        {
            var items = MemoryCache.Default.Where(m => m.Key.StartsWith(CombineKey(strPrefix), StringComparison.CurrentCultureIgnoreCase));
            if (items.Any())
            {
                foreach (var item in items)
                {
                    MemoryCache.Default.Remove(item.Key);
                }
            }

            GC.Collect();
        }

        /// <summary>
        /// 清除全部缓存
        /// </summary>
        public static void Clear()
        {
            var keys = MemoryCache.Default.Select(m => m.Key).ToList();
            foreach (var key in keys)
            {
                if (key.Contains(m_RegionName))
                {
                    MemoryCache.Default.Remove(key);
                }
            }
            GC.Collect();
        }

        public static bool Contains(string name)
        {
            return MemoryCache.Default.Contains(CombineKey(name));
        }

        public enum CompareType
        {
            StartWith, EndWith, Equals
        }
    }
}
