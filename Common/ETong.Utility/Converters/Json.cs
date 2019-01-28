using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ETong.Utility.Converts
{
    

    [Serializable]
    public class Json
    {
        /// <summary>
        /// json 统一返回参数对象
        /// </summary>
        [Serializable]
        public class JsonReturn
        {
            public JsonReturn()
            {
                state = false;
                code = string.Empty;
                message = string.Empty;
                message_detail = string.Empty;
                timestamp = string.Empty;
                data = string.Empty;
            }

            /// <summary>
            /// 执行状态
            /// </summary>
            public bool state;

            /// <summary>
            /// 执行结果响应码
            /// </summary>
            public string code;

            /// <summary>
            /// 简要错误信息
            /// </summary>
            public string message;

            /// <summary>
            /// 详细错误信息
            /// </summary>
            public string message_detail;

            /// <summary>
            /// 时间戳
            /// </summary>
            public string timestamp;

            /// <summary>
            /// 返回结果数据
            /// </summary>
            public object data;

            public JsonReturn Clone()
            {
                JsonReturn result = new JsonReturn();
                result.state = state;
                result.code = code;
                result.message = message;
                result.message_detail = message_detail;
                result.timestamp = timestamp;
                result.data = data;
                return result;
            }
        }

        /// <summary>
        /// 分页对象
        /// </summary>
        [Serializable]
        public class JsonPagination : JsonReturn
        {
            public JsonPagination()
            {
                start_index = 0;
                total = -1;
                size = 10;
            }

            public new JsonPagination Clone()
            {
                JsonPagination result = new JsonPagination();
                result.state = state;
                result.code = code;
                result.message = message;
                result.message_detail = message_detail;
                result.timestamp = timestamp;
                result.data = data;
                result.start_index = start_index;
                result.total = total;
                result.size = size;
                return result;
            }

            /// <summary>
            /// 开始记录索引（开始记录数）
            /// </summary>
            public int start_index;
            /// <summary>
            /// 记录总数
            /// </summary>
            public int total;
            /// <summary>
            /// 分页大小
            /// </summary>
            public int size; 
        }

        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public static string Encode(object o)
        {
            if (o == null || o.ToString() == "null") return null;

            if (o != null && (o.GetType() == typeof(String) || o.GetType() == typeof(string)))
            {
                return o.ToString();
            }
            IsoDateTimeConverter dt = new IsoDateTimeConverter();
            dt.DateTimeFormat = DateTimeFormat;
            return JsonConvert.SerializeObject(o, dt);
        }

        public static object Decode(string json)
        {
            if (String.IsNullOrEmpty(json)) return "";
            object o = JsonConvert.DeserializeObject(json);
            if (o.GetType() == typeof(String) || o.GetType() == typeof(string))
            {
                o = JsonConvert.DeserializeObject(o.ToString());
            }
            object v = toObject(o);
            return v;
        }

        public static object Decode(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        public static T Decode<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private static object toObject(object o)
        {
            if (o == null) return null;

            if (o.GetType() == typeof(string))
            {
                //判断是否符合2010-09-02T10:00:00的格式
                string s = o.ToString();
                if (s.Length == 19 && s[10] == 'T' && s[4] == '-' && s[13] == ':')
                {
                    o = System.Convert.ToDateTime(o);
                }
            }
            else if (o is JObject)
            {
                JObject jo = o as JObject;

                Hashtable h = new Hashtable();

                foreach (KeyValuePair<string, JToken> entry in jo)
                {
                    h[entry.Key] = toObject(entry.Value);
                }

                o = h;
            }
            else if (o is IList)
            {
                ArrayList list = new ArrayList();
                list.AddRange((o as IList));
                int i = 0, l = list.Count;
                for (; i < l; i++)
                {
                    list[i] = toObject(list[i]);
                }
                o = list;

            }
            else if (typeof(JValue) == o.GetType())
            {
                JValue v = (JValue)o;
                o = toObject(v.Value);
            }
            else
            {
            }
            return o;
        }

        /// <summary>
        /// 把对象序列化为字符串。
        /// </summary>
        /// <param name="o">序列化的对象。</param>
        /// <returns>返回字符串。</returns>
        public static string Serialize(object o)
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            //这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式   
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            return JsonConvert.SerializeObject(o, Formatting.None, timeConverter);
        }

        /// <summary>
        /// 把字符串反序列化为泛型类型的实例。
        /// </summary>
        /// <typeparam name="T">泛型类型。</typeparam>
        /// <param name="s">被反序列化的字符串。</param>
        /// <returns>返回范型类型的实例。</returns>
        public static T Deserialize<T>(string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }

    }
}




