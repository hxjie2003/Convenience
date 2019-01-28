using System;

namespace ETong.Cache.HttpCache
{
    /// <summary>
    /// </summary>
    public class WebCache
    {
        /// <summary>
        ///     添加缓存项目
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="validFor">最后一次访问与过期时间之间的间隔</param>
        public static void Set<T>(string key, T value, TimeSpan? validFor = null)
        {
            CacheManager.Instance.Set(key, value, validFor);
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            CacheManager.Instance.Remove(key);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return CacheManager.Instance.Get<T>(key);
        }

        /// <summary>
        /// </summary>
        public static void Clear()
        {
            CacheManager.Instance.Clear();
        }
    }
}