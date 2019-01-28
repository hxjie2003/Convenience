//-----------------------------------------------------------------------
// <copyright file="HttpClientUtility.cs" company="Etong">
//     http的客户端
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using ETong.WebApiUtility.Entity;

namespace ETong.WebApiUtility
{
    using ETong.Common.Enum;

    /// <summary>
    ///     http客户端请求类
    /// </summary>
    public class HttpClientUtility
    {
        #region 私有属性

        /// <summary>
        ///     http请求的客户端
        /// </summary>
        private readonly HttpClient httpClient = new HttpClient();

        #endregion

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpClientUtility" /> class.
        ///     构造函数
        /// </summary>
        /// <param name="baseAddress">
        ///     主机地址
        /// </param>
        public HttpClientUtility(Uri baseAddress)
        {
            BaseAddress = baseAddress;
            httpClient.BaseAddress = BaseAddress;
            httpClient.Timeout = new TimeSpan(50000000000);
        }

        /// <summary>
        /// 构造函数,  没有BaseAddress
        /// </summary>
        public HttpClientUtility()
        {
            httpClient.Timeout = new TimeSpan(50000000000);
        }
        #region Public 属性

        /// <summary>
        ///     Gets or sets 主机地址
        /// </summary>
        public Uri BaseAddress { get; set; }

        /// <summary>
        ///     Gets or sets headerInfo
        /// </summary>
        public HeaderResponsetInfo ResponseHeader { get; set; }

        /// <summary>
        ///     Gets or sets
        /// </summary>
        public HeaderRequestInfo Requestheader { get; set; }

        #endregion

        #region Public 方法

        /// <summary>
        ///     Get请求
        /// </summary>
        /// <param name="uri">
        ///     The uri 是指定资源除主机地址外的唯一定位地址.
        /// </param>
        /// <param name="mediaType">
        ///     The media Type 是指定数据返回的格式.
        /// </param>
        /// <param name="header">系统级参数的头信息</param>
        /// <typeparam name="T">
        ///     获取结果的泛型实体
        /// </typeparam>
        /// <returns>
        ///     返回Get的结果
        /// </returns>
        public T GetAsync<T>(string uri, MediaTypeEnum mediaType, HeaderRequestInfo header)
        {
            var defaultT = default(T);

            // 设置响应格式
            httpClient.DefaultRequestHeaders.Accept.Add(HeaderInfoUtility.GetMediaTpye(mediaType));

            // 设置系统级参数的响应头
            httpClient.DefaultRequestHeaders.SetRequestHeadInfo(header);
            Requestheader = header;

            // 发送http
            var response = httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    defaultT = response.Content.ReadAsAsync<T>().Result;
                }
                catch (Exception)
                {
                    try
                    {
                        defaultT = (T)(Object)response.Content.ReadAsStringAsync().Result;
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("无法将取的值转换成指定的泛型,原因为：" + exception.Message);
                    }

                    //throw;
                }
            }
            // headInfo
            ResponseHeader = response.Headers.GetResponseHeadInfo();

            return defaultT;
        }

        /// <summary>
        /// 一般Form提交
        /// </summary>
        /// <param name="url">路径</param>
        /// <param name="postData">提交内容，Form提交格式，如userId=admin&Password=324324,如果是只有一个字符串的WebApi，那么直接=postValue即可</param>
        /// <returns></returns>
        public string FormPost(string url, string postData, HeaderRequestInfo header)
        {
            HttpContent content = new StringContent(postData);
            content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            // 设置系统级参数的响应头
            if (header != null)
            {
                httpClient.DefaultRequestHeaders.SetRequestHeadInfo(header);
            }
            HttpResponseMessage responseMessage = httpClient.PostAsync(url, content).Result;
            responseMessage.EnsureSuccessStatusCode();

            return responseMessage.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        ///     Post请求
        /// </summary>
        /// <typeparam name="TResut">返回结果的泛型类型</typeparam>
        /// <typeparam name="TData">输入参数的泛型类型</typeparam>
        /// <param name="uri">指定的uri，不包含主机地址</param>
        /// <param name="mediaType">指定的结果返回类型</param>
        /// <param name="body">泛型，用于post的请求参数</param>
        /// <param name="header">系统级参数的头信息</param>
        /// <returns>发送post请求并返回泛型T的结果</returns>
        public TResut PostAsync<TResut, TData>(string uri, MediaTypeEnum mediaType, TData body, HeaderRequestInfo header)
        {
            var defaultT = default(TResut);

            // 设置响应格式
            httpClient.DefaultRequestHeaders.Accept.Add(HeaderInfoUtility.GetMediaTpye(mediaType));

            // 设置系统级参数的响应头
            httpClient.DefaultRequestHeaders.SetRequestHeadInfo(header);
            Requestheader = header;

            // 发送http
            //var jsonFormatter = new JsonMediaTypeFormatter();
            //HttpContent txtContent = new ObjectContent<TData>(body, jsonFormatter);

            HttpContent txtContent = this.formateContent<TData>(mediaType, body);

            var response = httpClient.PostAsync(uri, txtContent).Result;
            if (response.IsSuccessStatusCode)
            {
                defaultT = response.Content.ReadAsAsync<TResut>().Result;
            }

            // ResponseHeader
            this.ResponseHeader = response.Headers.GetResponseHeadInfo();

            // Return
            return defaultT;
        }

        /// <summary>
        /// Delete操作
        /// </summary>
        /// <summary>
        ///     Delete请求
        /// </summary>
        /// <param name="uri">
        ///     The uri 是指定资源除主机地址外的唯一定位地址.
        /// </param>
        /// <param name="mediaType">
        ///     The media Type 是指定数据返回的格式.
        /// </param>
        /// <param name="header">系统级参数的头信息</param>
        /// <typeparam name="T">
        ///     获取结果的泛型实体
        /// </typeparam>
        /// <typeparam name="TResut">The TResult</typeparam>
        /// <returns>
        ///     返回Put的结果
        /// </returns>
        public TResut DeleteAsync<TResut>(string uri, MediaTypeEnum mediaType, HeaderRequestInfo header)
        {
            var defaultT = default(TResut);

            // 设置响应格式
            httpClient.DefaultRequestHeaders.Accept.Add(HeaderInfoUtility.GetMediaTpye(mediaType));

            // 设置系统级参数的响应头
            httpClient.DefaultRequestHeaders.SetRequestHeadInfo(header);
            Requestheader = header;

            // 发送http
            var response = httpClient.DeleteAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                defaultT = response.Content.ReadAsAsync<TResut>().Result;
            }

            // headInfo
            ResponseHeader = response.Headers.GetResponseHeadInfo();


            return defaultT;
        }

        /// <summary>
        ///    Put请求
        /// </summary>
        /// <typeparam name="TResut">返回结果的泛型类型</typeparam>
        /// <typeparam name="TData">输入参数的泛型类型</typeparam>
        /// <param name="uri">指定的uri，不包含主机地址</param>
        /// <param name="mediaType">指定的结果返回类型</param>
        /// <param name="body">泛型，用于post的请求参数</param>
        /// <param name="header">系统级参数的头信息</param>
        /// <returns>发送Put请求并返回泛型T的结果</returns>
        public TResut PutAsync<TResut, TData>(string uri, MediaTypeEnum mediaType, TData body, HeaderRequestInfo header)
        {
            var defaultT = default(TResut);

            // 设置响应格式
            httpClient.DefaultRequestHeaders.Accept.Add(HeaderInfoUtility.GetMediaTpye(mediaType));

            // 设置系统级参数的响应头
            httpClient.DefaultRequestHeaders.SetRequestHeadInfo(header);
            Requestheader = header;

            // 发送http
            var jsonFormatter = new JsonMediaTypeFormatter();
            HttpContent txtContent = new ObjectContent<TData>(body, jsonFormatter);
            var response = httpClient.PutAsync(uri, txtContent).Result;

            if (response.IsSuccessStatusCode)
            {
                defaultT = response.Content.ReadAsAsync<TResut>().Result;
            }

            // ResponseHeader
            ResponseHeader = response.Headers.GetResponseHeadInfo();


            // Return
            return defaultT;
        }
        #endregion


        #region private methods

        /// <summary>
        /// 返回被htpContent封装的内容
        /// </summary>
        /// <returns></returns>
        private HttpContent formateContent<TData>(MediaTypeEnum mediaType, TData body)
        {
            HttpContent result = null;
            switch (mediaType)
            {
                case MediaTypeEnum.Json:
                    var jsonFormatter = new JsonMediaTypeFormatter();
                    result = new ObjectContent<TData>(body, jsonFormatter);
                    break;
                case MediaTypeEnum.Xml:
                    var xmlFormatter = new XmlMediaTypeFormatter();
                    result = new ObjectContent<TData>(body, xmlFormatter);
                    break;
            }

            return result;
        }

        #endregion
    }
}