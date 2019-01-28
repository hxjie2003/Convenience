//-----------------------------------------------------------------------
// <copyright file="ConvertUtility.cs" company="Etong">
//     提供类型转换，将集合可以转换成一个指定的实体类
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ETong.WebApiUtility.Convert
{
     /// <summary>
    /// 类型转换
    /// </summary>
    public static class ConvertUtility
    {
        /// <summary>
        /// 将 k/v 集合转换成指定的泛型T对象
        /// </summary>
        /// <param name="list">
        /// 指定的集合对象
        /// </param>
        /// <typeparam name="TResult">
        /// 泛型类，指定返回值的类型
        /// </typeparam>
        /// <returns>
        /// 返回指定的TResult对象
        /// </returns>
        public static TResult StringCollectionToEntity<TResult>(List<KeyValuePair<string, IEnumerable<string>>> list)
        {
            var type = typeof(TResult);
            var prop = type.GetProperties();
            var result = Assembly.GetExecutingAssembly().CreateInstance(type.FullName);
            foreach (var li in prop)
            {
                var key = li.Name.ToLower();
                if (list.Any(x => x.Key.ToLower() == key))
                {
                    var val = list.SingleOrDefault(x => x.Key.ToLower() == key).Value.FirstOrDefault();
                    li.SetValue(result, val);
                }
            }

            return (TResult)result;
        }

        /// <summary>
        /// 将实体转换成字典集合
        /// </summary>
        /// <typeparam name="TInput">泛型Tinput,要转换实体的类型</typeparam>
        /// <param name="obj">泛型Tinput的实体</param>
        /// <returns>返回k/v string的集合</returns>
        public static Dictionary<string, string> EntityToDictionary<TInput>(TInput obj)
        {
            var result = new Dictionary<string, string>();
            var type = obj.GetType();
            var prop = type.GetProperties();
            foreach (var li in prop)
            {
                var key = li.Name;
                var val = li.GetValue(obj, null) ?? string.Empty;
                result.Add(key, val.ToString());
            }

            return result;
        }
    }
}
