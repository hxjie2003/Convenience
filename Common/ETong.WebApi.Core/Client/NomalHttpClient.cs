using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using ETong.WebApi.Core;
using Newtonsoft.Json;
using ETong.WebApi.Server.Core;
using log4net;

namespace ETong.WebApi.Client
{
    /// <summary>
    /// Webapi的httpclient的封装，对.net4.0
    /// 通用
    /// </summary>
    public static class NormalHttpClient
    {
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }  

        #region 基础方法
        /// <summary>
        /// 从信息转换成模型
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private static TReturn ConvertToResult<TReturn>(Task<HttpResponseMessage> response)
        {
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
        /// 创建内容 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        private static HttpContent CreateStringContent<TInput>(TInput input)
        {
            string inputstring = string.Empty;
            if (!(input is string))
            {
                var jSetting = new JsonSerializerSettings();
                jSetting.NullValueHandling = NullValueHandling.Ignore;
                inputstring = Newtonsoft.Json.JsonConvert.SerializeObject(input, jSetting);
            }
            else
            {
                inputstring = input.ToString();
            }
            HttpContent content = new StringContent(inputstring);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
        #endregion

        #region  Get
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
            TReturn result = ConvertToResult<TReturn>(response);
            return result;
           
        }
        #endregion

        #region Put
        public static TReturn Put<TInput, TReturn>(string url, TInput input)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = CreateStringContent<TInput>(input);
            Task<HttpResponseMessage> response = httpClient.PutAsync(url, content);
            TReturn result = ConvertToResult<TReturn>(response);
            return result;
        }
        #endregion

        #region Patch
        public static TReturn Patch<TInput, TReturn>(string url, TInput input)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = CreateStringContent<TInput>(input);
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), url);
            request.Content = content;
            Task<HttpResponseMessage> response = httpClient.SendAsync(request,HttpCompletionOption.ResponseContentRead);
            TReturn result = ConvertToResult<TReturn>(response);
            return result;
        }
        #endregion

        #region Post
        public static TReturn Post<TInput, TReturn>(string url, TInput input)
        {
            TReturn result = default(TReturn);
            HttpClient httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            ILog logger = LogManager.GetLogger(typeof(NormalHttpClient));
            HttpContent content = CreateStringContent<TInput>(input);
            Task<HttpResponseMessage> response = httpClient.PostAsync(url, content);
            result = ConvertToResult<TReturn>(response);
            return result;
        }
        #endregion

        #region Delete
        public static TReturn Delete<TReturn>(string url)
        {
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> response = httpClient.DeleteAsync(url);
            TReturn result = ConvertToResult<TReturn>(response);
            return result;
        }
        #endregion
    }
}
