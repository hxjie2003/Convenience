using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace ETong.Web
{
    /// <summary>
    ///     JSON ACCESS.
    /// </summary>
    /// <remarks>
    ///     code from ETM_V3\SourceCode\Common\ETong.WebApiUtility\HttpClientUtility.cs
    /// </remarks>
    public static class WebApiHelper
    {
        public static T Get<T>(string url, dynamic obj)
        {
            var requestData = ToRequetFormat(obj);
            url += url.Contains("?") ? ("&" + requestData) : ("?" + requestData);
            return Get<T>(url);
        }

        public static void Delete(string url)
        {
            var httpClient = CreateClient();
            var response = httpClient.DeleteAsync(url).Result;
        }

        public static T Delete<T>(string url)
        {
            var httpClient = CreateClient();
            var response = httpClient.DeleteAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default(T);
        }

        public static T Get<T>(string url)
        {
            var httpClient = CreateClient();


            // 发送http
            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json);
            }
            var s = response.Content.ReadAsStringAsync().Result;
            var ex = JsonConvert.DeserializeObject<WebApiExceptionInfo>(s);
            throw new RemoteAccesssException(response.StatusCode, ex);
        }

        public static T Put<T>(string url, object obj)
        {
            var httpClient = CreateClient();
            // 发送http
            var response = httpClient.PutAsJsonAsync(url, obj).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json);
            }

            var content = response.Content.ReadAsStringAsync().Result;
            try
            {
                var ex = JsonConvert.DeserializeObject<WebApiExceptionInfo>(content);
                throw new RemoteAccesssException(response.StatusCode, ex);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("转换" + content + "失败,httpCode=" + response.StatusCode);
            }
        }

        public static void Put(string url, object obj)
        {
            Put<string>(url, obj);
        }


        public static T Post<T>(string url, object obj)
        {
            var httpClient = CreateClient();
            // 发送http
            var response = httpClient.PostAsJsonAsync(url, obj).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json);
            }
            var s = response.Content.ReadAsStringAsync().Result;
            var ex = JsonConvert.DeserializeObject<WebApiExceptionInfo>(s);
            throw new RemoteAccesssException(response.StatusCode, ex);
        }

        public static void Post(string url, object obj)
        {
            var s = Post<string>(url, obj);
        }

        private static HttpClient CreateClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
        private static string ToRequetFormat(object obj)
        {
            var valueSet = ToNameValueCollection(obj);
            return ToData(valueSet);
        }

        private static NameValueCollection ToNameValueCollection(object obj)
        {
            var result = new NameValueCollection();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                var value = descriptor.GetValue(obj);
                if (value != null)
                {
                    result.Add(descriptor.Name, Convert.ToString(value));
                }
            }
            return result;
        }

        private static string ToData(NameValueCollection nameValue)
        {
            var result = new StringBuilder();
            var first = true;

            foreach (var key in nameValue.AllKeys)
            {
                var value = HttpUtility.UrlEncode(nameValue.Get(key));
                if (first)
                {
                    first = false;
                    result.Append(key).Append("=").Append(value);
                    continue;
                }
                result.Append("&");
                result.Append(key).Append("=").Append(value);
            }
            return result.ToString();
        }
    }
}