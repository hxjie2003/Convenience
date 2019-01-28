using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace ETong.Utility.Comunication
{
    public static class HttpJsonRequestHelper
    {
        public static void Post(string url, dynamic data, Action<string> callback)
        {
            Request(url, "POST", data, Encoding.UTF8, callback);
        }

        public static void Get(string url, dynamic data, Action<string> callback)
        {
            Request(url, "GET", data, Encoding.UTF8, callback);
        }

        public static void Request(string url, string method, dynamic sendData, Encoding coding, Action<string> callback)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            var data = ToData(sendData, method);

            HttpWebRequest httpRequest = Create(url, data, method);


            if (method == "POST" && data != null)
            {
                var postData = Encoding.UTF8.GetBytes(data);
                httpRequest.ContentLength = postData.Length;
                using (var writer = httpRequest.GetRequestStream())
                {
                    writer.Write(postData, 0, postData.Length);
                }
            }

            var response = httpRequest.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream(), coding))
            {
                callback(reader.ReadToEnd());
            }
            /*
            httpRequest.BeginGetResponse( interf =>
            {
                IAsyncResult s = interf as IAsyncResult;
                var request = (HttpWebRequest)s.AsyncState;
                var response = request.EndGetResponse(interf);
                using (var reader = new StreamReader(response.GetResponseStream(), coding))
                {
                    callback(reader.ReadToEnd());
                }
            }, httpRequest);*/
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

            httpRequest.ContentType = "application/json";
            httpRequest.Method = method;
            //httpRequest.TransferEncoding = "UTF-8";
            return httpRequest;
        }

        private static string ToData(dynamic sendData, string method)
        {
            if (method == "POST")
                return JsonConvert.SerializeObject(sendData);

            var nameValue = ToNameValueCollection(sendData);
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

        private static NameValueCollection ToNameValueCollection(object obj)
        {
            var result = new NameValueCollection();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                var value = descriptor.GetValue(obj).ToString();
                result.Add(descriptor.Name, value);
            }
            return result;
        }
    }
}