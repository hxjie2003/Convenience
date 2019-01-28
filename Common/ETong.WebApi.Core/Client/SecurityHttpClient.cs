using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.IO;
using ETong.WebApi.Core;
using Newtonsoft.Json;
using ETong.WebApi.Server.Core;
using log4net;

namespace ETong.WebApi.Client
{
    /// <summary>
    /// Webapi的httpclient的封装，对.net4.0
    /// 易通专用，带加密
    /// </summary>
    public static class SecurityHttpClient
    {
        #region 基础方法
        /// <summary>
        /// 从信息转换成模型
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private static ResponseInfo<TReturn> ConvertToResult<TReturn>(Task<HttpResponseMessage> response)
        {
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new Exception("调用不成功！" + response.Result.StatusCode);
            }

            string resultstring = response.Result.Content.ReadAsStringAsync().Result;
            //resultstring=   resultstring.Replace("\"[", "[").Replace("]\"", "]");
            ResponseInfo<TReturn> result = null;
            if (!string.IsNullOrWhiteSpace(resultstring))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseInfo<TReturn>>(resultstring);
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
            log4net.ILog log = LogManager.GetLogger("ok");
            log.Info(inputstring);
            HttpContent content = new StringContent(inputstring);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }



        private static RequestInfo<Object> CreateRequest(Object body, string version, string reqfrom)
        {

            var sign = SignBuilder.BuildSign(body, version, reqfrom);

            var request = new RequestInfo<object>()
            {
                dataMap = body,
                sign = sign.Sign,
                reqTime = sign.ReqTime
            };
            if (!string.IsNullOrWhiteSpace(version))
            {
                request.version = version;
            }
            if (!string.IsNullOrWhiteSpace(reqfrom))
            {
                request.reqFrom = reqfrom;
            }
            return request;
        }
        #endregion

        #region  Get
        /// <summary>
        /// Get方法
        /// </summary>
        /// <typeparam name="TReturn">返回参数</typeparam>
        /// <param name="url">url请求地址</param>
        /// <returns>返回参数</returns>
        public static ResponseInfo<TReturn> Get<TReturn>(string url)
        {
            var items = UrlQueryParser.UrlToData(url).Item2;
            SortedList<string, object> list = new SortedList<string, object>();
            if (items != null)
            {
                foreach (var c in items)
                {
                    list.Add(c.Key, c.Value);
                }
            }

            var a = SignBuilder.BuildSignList(list, "", "");
            if (url.Contains('?'))
            {
                url += "&reqTime=" + a.ReqTime + "&sign=" + a.Sign;
            }
            else
            {
                url += "?reqTime=" + a.ReqTime + "&sign=" + a.Sign;
            }

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> response = httpClient.GetAsync(url);
            var result = ConvertToResult<TReturn>(response);

            return result;

        }
        #endregion

        #region Put
        /// <summary>
        /// Put方法
        /// </summary>
        /// <typeparam name="TInput">内容参数类型</typeparam>
        /// <typeparam name="TReturn">结果类型</typeparam>
        /// <param name="url">地址</param>
        /// <param name="input">请求参数</param>
        /// <returns>返回结果</returns>
        public static ResponseInfo<TReturn> Put<TInput, TReturn>(string url, TInput input)
        {
            return Put<TInput, TReturn>(url, input, "", "");
        }
        /// <summary>
        ///  Put方法 对应Java增加版本后及ReqFrom后的版本。
        /// </summary>
        /// <typeparam name="TInput">内容参数类型</typeparam>
        /// <typeparam name="TReturn">结果类型</typeparam>
        /// <param name="url">地址</param>
        /// <param name="input">请求参数</param>
        /// <param name="reqfrom">请求来源，1 ETM</param>
        /// <param name="version">v1</param>
        /// <returns>返回结果</returns>
        public static ResponseInfo<TReturn> Put<TInput, TReturn>(string url, TInput input, string reqfrom, string version = "")
        {
            RequestInfo<Object> request = CreateRequest(input, version, reqfrom);

            HttpContent content = CreateStringContent<Object>(request);

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> response = httpClient.PutAsync(url, content);
            var result = ConvertToResult<TReturn>(response);

            return result;
        }
        #endregion

        #region Post
        /// <summary>
        ///Post方法
        /// </summary>
        /// <typeparam name="TInput">内容参数类型</typeparam>
        /// <typeparam name="TReturn">结果类型</typeparam>
        /// <param name="url">地址</param>
        /// <param name="input">请求参数</param>
        /// <returns>返回结果</returns>
        public static ResponseInfo<TReturn> Post<TInput, TReturn>(string url, TInput input)
        {
            return Post<TInput, TReturn>(url, input, "", "");
        }
        /// <summary>
        /// Post方法 对应Java增加版本后及ReqFrom后的版本。
        /// </summary>
        /// <typeparam name="TInput">内容参数类型</typeparam>
        /// <typeparam name="TReturn">结果类型</typeparam>
        /// <param name="url">地址</param>
        /// <param name="input">请求参数</param>
        /// <param name="reqfrom">请求来源，1 ETM</param>
        /// <param name="version">v1</param>
        /// <returns>返回结果</returns>
        public static ResponseInfo<TReturn> Post<TInput, TReturn>(string url, TInput input, string reqfrom, string version = "")
        {
            RequestInfo<Object> request = CreateRequest(input, version, reqfrom);

            HttpContent content = CreateStringContent<Object>(request);

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> response = httpClient.PostAsync(url, content);
            var result = ConvertToResult<TReturn>(response);

            return result;
        }
        #endregion

        #region Delete
        public static ResponseInfo<TReturn> Delete<TReturn>(string url)
        {
            var items = UrlQueryParser.UrlToData(url).Item2;
            SortedList<string, object> list = new SortedList<string, object>();
            if (items != null)
            {
                foreach (var c in items)
                {
                    list.Add(c.Key, c.Value);
                }
            }

            var a = SignBuilder.BuildSignList(list, "", "");
            if (url.Contains('?'))
            {
                url += "&reqTime=" + a.ReqTime + "&sign=" + a.Sign;
            }
            else
            {
                url += "?reqTime=" + a.ReqTime + "&sign=" + a.Sign;
            }

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> response = httpClient.DeleteAsync(url);
            var result = ConvertToResult<TReturn>(response);

            return result;
        }
        #endregion
    }
}
