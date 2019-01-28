//-----------------------------------------------------------------------
// <copyright file="JsonSerializer.cs" company="Etong">
//     xml序列化相关的工具方法
// </copyright>
//-----------------------------------------------------------------------
using Newtonsoft.Json;

namespace ETong.WebApiUtility.Convert
{
    /// <summary>
    /// Json序列化的工具类
    /// </summary>
    public class JsonSerializer
    {
        /// <summary>
        /// 序列化json数据
        /// </summary>
        /// <returns>将类型T的实例t序列成json的string并返回</returns>
        /// <typeparam name="T">泛型T</typeparam>
        /// <param name="t">类型T的实例</param>
        public static string SerializeJson<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }

        /// <summary>
        /// 反序列化成
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <returns>将json字符串反序列成为T的实体</returns>
        /// <param name="s">json字符串</param>
        public static T DeserializeJson<T>(string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}
