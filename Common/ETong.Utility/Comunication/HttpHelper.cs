using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace ETong.Utility.Comunication
{
    /// <summary>
    ///     用form提交数据，编码必须是utf-8，同步模式都行
    /// </summary>
    public static class HttpHelper
    {
        /// <summary>
        ///     使用 Post 方法提交，同步模式
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Post(string url, dynamic data)
        {
            return Request(url, ToData(ToNameValueCollection(data)), "GET");
        }

        /// <summary>
        ///     使用get方式提交，同步模式
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Get(string url, dynamic data)
        {
            return Request(url, ToData(ToNameValueCollection(data)), "POST");
        }

        private static NameValueCollection ToNameValueCollection(object obj)
            
        {
            var result = new NameValueCollection();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string value = descriptor.GetValue(obj).ToString();
                result.Add(descriptor.Name, value);
            }
            return result;
        }
        /// <summary>
        ///     把NameCollection变为QueryStringm 模式
        /// </summary>
        /// <param name="nameValue"></param>
        /// <returns></returns>
        private static string ToData(NameValueCollection nameValue)
        {
            var result = new StringBuilder();
            var first = true;
            foreach (var key in nameValue.AllKeys)
            {
                var value = HttpUtility.UrlEncode(nameValue.Get(key));
                result.Append(key).Append("=").Append(value);
                if (first)
                {
                    first = false;
                    continue;
                }
                result.Append("&");
            }
            return result.ToString();
        }

        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        /// <exception cref="UriFormatException">url 格式不正确</exception>
        /// <exception cref="ArgumentNullException">url null or empty</exception>
        public static object Request(string url, string data, string method)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            var httpRequest = Create(url, data, method);


            if (method == "POST" && data != null)
            {
                var sendData = Encoding.UTF8.GetBytes(data);
                httpRequest.ContentLength = sendData.Length;
                using (var writer = httpRequest.GetRequestStream())
                {
                    writer.Write(sendData, 0, sendData.Length);
                }
            }
            var stream = httpRequest.GetResponse().GetResponseStream();
            if (stream != null)
            {
                using (var reader = new StreamReader(stream,Encoding.GetEncoding("gb2312")))
                {
                    return reader.ReadToEnd();
                }
            }

            return "";
        }

        private static HttpWebRequest Create(string url, string data, string method)
        {
            HttpWebRequest httpRequest;
            try
            {
                if (data != null && method == "GET")
                    url += "?" + data;
                httpRequest = WebRequest.Create(url) as HttpWebRequest;
                if (httpRequest == null)
                    throw new UriFormatException("url is not in right http url format.");
            }
            catch (NotSupportedException)
            {
                throw new UriFormatException("url is not in right http url format.");
            }
            catch (UriFormatException)
            {
                throw new UriFormatException("url is not in right http url format.");
            }

            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Method = method;
            //httpRequest.TransferEncoding = "UTF-8";
            return httpRequest;
        }

        #region 新加的方法

        /// <summary>
        /// 使用 Post 方法提交Restful请求，同步模式
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PostRest(string url, string jsonData)
        {
            return RequestRest(url, jsonData);
        }

        public static string RequestRest(string url, string data)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            var httpRequest = CreateRest(url, data, "POST");


            if (data != null)
            {
                var sendData = Encoding.UTF8.GetBytes(data);
                httpRequest.ContentLength = sendData.Length;
                using (var writer = httpRequest.GetRequestStream())
                {
                    writer.Write(sendData, 0, sendData.Length);
                }
            }
            using (var stream = httpRequest.GetResponse().GetResponseStream())
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }

            return string.Empty;
        }

        private static HttpWebRequest CreateRest(string url, string data, string method)
        {
            HttpWebRequest httpRequest;
            try
            {
                if (data != null && method == "GET")
                    url += "?" + data;
                httpRequest = WebRequest.Create(url) as HttpWebRequest;
                if (httpRequest == null)
                    throw new UriFormatException("url is not in right http url format.");
            }
            catch (NotSupportedException)
            {
                throw new UriFormatException("url is not in right http url format.");
            }
            catch (UriFormatException)
            {
                throw new UriFormatException("url is not in right http url format.");
            }

            httpRequest.ContentType = "application/json";
            httpRequest.Method = method;
            httpRequest.Credentials = CredentialCache.DefaultCredentials;
            return httpRequest;
        }

        #endregion 新加的方法

    }
}