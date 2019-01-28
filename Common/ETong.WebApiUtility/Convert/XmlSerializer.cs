//-----------------------------------------------------------------------
// <copyright file="xmlserializer.cs" company="Etong">
//     xml序列化相关的工具方法
// </copyright>
//-----------------------------------------------------------------------
using System.IO;

namespace ETong.WebApiUtility.Convert
{
    /// <summary>
    /// XML序列工具类
    /// </summary>
    public class XmlSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="t">t为泛型T的一个实例对象</param>
        /// <returns>将t序列成string并返回</returns>
        /// <typeparam name="T">泛型T</typeparam>
        public static string SerializeObj<T>(T t)
        {
            if (t == null)
            {
                return null;
            }

            using (var sw = new StringWriter())
            {
                var xz = new System.Xml.Serialization.XmlSerializer(t.GetType());
                xz.Serialize(sw, t);
                return sw.ToString();
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="s">s为T类型的实例序列化后的string</param>
        /// <returns>将s反序列化并返回</returns>
        /// <typeparam name="T">泛型T</typeparam>
        public static T DeserializeObj<T>(string s)
        {
            using (var sr = new StringReader(s))
            {
                var xz = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)xz.Deserialize(sr);
            }
        }
    }
}
