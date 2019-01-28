using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web.Helpers;
using ETong.Entity;
using ETong.Common.Enum;
using System.IO;

namespace ETong.Utility
{
    /// <summary>
    /// Webapi的httpclient的封装，对.net4.0
    /// </summary>
    public static class HttpClientProxy
    {
        public static string RequestUrl(string url, HttpRequestMode requestMode, string postParams)
        {
            string responseString = string.Empty;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = requestMode.ToString();

            if (requestMode == HttpRequestMode.Post)
            {
                request.ContentType = "application/x-www-form-urlencoded";
                if (!string.IsNullOrEmpty(postParams))
                {
                    byte[] btBodys = Encoding.UTF8.GetBytes(postParams);
                    request.ContentLength = btBodys.Length;
                    request.GetRequestStream().Write(btBodys, 0, btBodys.Length);
                }
            }

            WebResponse response = request.GetResponse();
            if (response != null)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        responseString = sr.ReadToEnd();
                    }
                }
                response.Close();
            }
            return responseString;
        }
        /// <summary>
        /// Get方法
        /// </summary>
        /// <typeparam name="TReturn">返回参数</typeparam>
        /// <param name="url">url请求地址</param>
        /// <returns>返回参数</returns>
        public static TReturn Get<TReturn>(string url)
        {

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> response = httpClient.GetAsync(url);
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
                throw new Exception(url + "请求状态失败，状态码:" + response.Result.StatusCode);
            string resultstring = response.Result.Content.ReadAsStringAsync().Result;
            TReturn result = default(TReturn);
            if (!string.IsNullOrWhiteSpace(resultstring) && !(result is string))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<TReturn>(resultstring);
            }
            return result;
        }
        public static TReturn Put<TInput, TReturn>(string url, TInput input)
        {
            HttpClient httpClient = new HttpClient();
            string inputstring = string.Empty;
            if (!(input is string))
                inputstring = Newtonsoft.Json.JsonConvert.SerializeObject(input);
            else
                inputstring = input.ToString();

            HttpContent content = new StringContent(inputstring);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Task<HttpResponseMessage> response = httpClient.PutAsync(url, content);
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
                throw new Exception(url + "请求状态失败，状态码:" + response.Result.StatusCode);
            string resultstring = response.Result.Content.ReadAsStringAsync().Result;
            TReturn result = default(TReturn);
            if (!string.IsNullOrWhiteSpace(resultstring) && !(result is string))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<TReturn>(resultstring);
            }
            return result;
        }
        public static TReturn Post<TInput, TReturn>(string url, TInput input)
        {
            HttpClient httpClient = new HttpClient();
            string inputstring = string.Empty;
            if (!(input is string))
                inputstring = Newtonsoft.Json.JsonConvert.SerializeObject(input);
            else
                inputstring = input.ToString();
            HttpContent content = new StringContent(inputstring);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Task<HttpResponseMessage> response = httpClient.PostAsync(url, content);
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new Exception("调用不成功！" + response.Result.StatusCode);
            }
            string resultstring = response.Result.Content.ReadAsStringAsync().Result;
            TReturn result = default(TReturn);
            if (!string.IsNullOrWhiteSpace(resultstring))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<TReturn>(resultstring);
            }
            return result;
        }

        /// <summary>
        /// 简化post方法，传入参数是json格式
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postParams"></param>
        /// <returns></returns>
        public static Return PostJson<Return>(string url, string postParams)
        {
            HttpClient httpClient = new HttpClient();

            HttpContent content = new StringContent(postParams);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            Task<HttpResponseMessage> response = httpClient.PostAsync(url, content);
            response.Wait(TimeSpan.FromMinutes(5));
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new Exception("调用不成功！" + response.Result.StatusCode);
            }
            string resultstring = response.Result.Content.ReadAsStringAsync().Result;
            Return result = default(Return);
            if (!string.IsNullOrWhiteSpace(resultstring) && !(result is string))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Return>(resultstring);
            }
            return result;
        }

        public static TReturn Delete<TReturn>(string url)
        {
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> response = httpClient.DeleteAsync(url);
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
                throw new Exception(url + "请求状态失败，状态码:" + response.Result.StatusCode);
            string resultstring = response.Result.Content.ReadAsStringAsync().Result;
            TReturn result = default(TReturn);
            if (!string.IsNullOrWhiteSpace(resultstring) && !(result is string))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<TReturn>(resultstring);
            }
            return result;
        }

    }
}
