using System;
using System.Collections.Generic;
using System.Linq;

namespace ETong.Utility
{
    public class HttpArguments : EventArgs
    {
        /// <summary>
        /// 服务接口的URL地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 服务类型
        /// </summary>
        public HttpMethodType Method { get; set; }

        /// <summary>
        /// 拼在 URL 地址后面的查询字符串
        /// </summary>
        public string SearchString { get; set; }

        /// <summary>
        /// 请求发送的数据
        /// </summary>
        public Dictionary<string, string> PostData { get; set; }

        /// <summary>
        /// 请求内容类型
        /// </summary>
        public string HttpContentType { get; set; }

        /// <summary>
        /// 字符集编码
        /// </summary>
        public System.Text.Encoding Encoding { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri">服务接口地址</param>
        public HttpArguments(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new ArgumentNullException("uri");

            Url = uri;
            Method = HttpMethodType.Get;
            PostData = new Dictionary<string, string>();
            Encoding = System.Text.Encoding.UTF8;
            SearchString = "";
        }

        /// <summary>
        /// 获取发送数据字符串
        /// </summary>
        /// <returns></returns>
        public string GetPostDataString()
        {
            if (PostData.Count == 0)
                return string.Empty;

            var searchs = PostData.OrderBy(r => r.Key);

            string str = searchs.Aggregate("", (current, item) => current + string.Format("&{0}={1}", item.Key, item.Value.UrlEncode(true)));

            str = str.Substring(1);

            return str;
        }
    }
}