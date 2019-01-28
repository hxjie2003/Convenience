using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ETong.Utility
{
    public class HttpHelper
    {
        #region 常量
        /// <summary>
        /// 请求失败重试次数
        /// </summary>
        private readonly int _reTryTimes =Converts.Converter.ToInt(ConfigurationManager.AppSettings["ReTryTimes"], 3);
        #endregion

        #region 事件
        /// <summary>
        /// 在提交请求前触发该事件
        /// </summary>
        public event EventHandler<HttpArguments> BeforeSend;
        #endregion

        #region 成员
        private readonly HttpArguments _args;
        #endregion

        #region 属性
        /// <summary>
        /// 服务接口的URL地址
        /// </summary>
        public string Url
        {
            get
            {
                return _args.Url;
            }

            set
            {
                _args.Url = value;
            }
        }

        /// <summary>
        /// 服务类型
        /// </summary>
        public HttpMethodType Method
        {
            get
            {
                return _args.Method;
            }
            set
            {
                _args.Method = value;
            }
        }

        /// <summary>
        /// 拼在 URL 地址后面的查询字符串
        /// </summary>
        public string SearchString
        {
            get
            {
                return _args.SearchString;
            }
            set
            {
                _args.SearchString = value;
            }
        }

        /// <summary>
        /// 请求发送的数据
        /// </summary>
        public Dictionary<string, string> PostData
        {
            get
            {
                return _args.PostData;
            }

            set
            {
                _args.PostData = value;
            }
        }

        /// <summary>
        /// 请求头数据
        /// </summary>
        public Dictionary<string, string> HeaderData
        {
            get;
            set;
        }

        /// <summary>
        /// 请求内容类型
        /// </summary>
        public string HttpContentType
        {
            get
            {
                return _args.HttpContentType;
            }

            set
            {
                _args.HttpContentType = value;
            }
        }

        /// <summary>
        /// 字符集编码
        /// </summary>
        public Encoding Encoding
        {
            get
            {
                return _args.Encoding;
            }

            set
            {
                _args.Encoding = value;
            }
        }


        #endregion

        #region 构造函数
        /// <summary>
        /// 创建接口服务请求器
        /// </summary>
        /// <param name="uri">服务接口 uri</param>
        public HttpHelper(string uri)
        {
            _args = new HttpArguments(uri);
            HeaderData = new Dictionary<string, string>();
        }

        /// <summary>
        /// 创建接口服务请求器
        /// </summary>
        /// <param name="arg">请求参数对象</param>
        public HttpHelper(HttpArguments arg)
        {
            _args = arg;
        }

        /// <summary>
        /// 创建接口服务请求器
        /// </summary>
        /// <param name="uri">服务接口 uri</param>
        /// <returns></returns>
        public static HttpHelper CreateInstance(string uri)
        {
            return new HttpHelper(uri);
        }

        /// <summary>
        /// 创建接口服务请求器
        /// </summary>
        /// <param name="arg">请求参数对象</param>
        /// <returns></returns>
        public static HttpHelper CreateInstance(HttpArguments arg)
        {
            return new HttpHelper(arg);
        }
        #endregion

        #region 提交请求
        /// <summary>
        /// 提交请求
        /// </summary>
        /// <returns></returns>
        public Stream Send()
        {
            if (BeforeSend != null)
            {
                BeforeSend(this, _args);
            }

            var request = WebRequest.Create(_args.Url) as HttpWebRequest;
            if (request == null)
                throw new Exception("HttpWebRequest对象创建失败");

            request.ContentType = string.IsNullOrWhiteSpace(_args.HttpContentType) ? "application/x-www-form-urlencoded" : _args.HttpContentType;

            request.Method = _args.Method.ToString();

            var search = _args.SearchString;

            //加入请求参数
            if (_args.PostData != null && _args.PostData.Count > 0)
            {
                search = string.IsNullOrWhiteSpace(search)
                    ? _args.GetPostDataString()
                    : string.Format("{0}&{1}", search, _args.GetPostDataString());
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var encoding = _args.Encoding;

                var postbyte = encoding.GetBytes(search);

                request.ContentLength = postbyte.Length;

                var sm = request.GetRequestStream();
                sm.Write(postbyte, 0, postbyte.Length);
                sm.Close();
            }

            //加入参数头
            if (HeaderData != null && HeaderData.Keys.Count > 0)
            {
                foreach (string key in HeaderData.Keys)
                    request.Headers.Add(key, HeaderData[key]);
            }

            //重试次数
            var times = 0;
            Stream stream = new MemoryStream();
            while (true)
            {
                //记录重试次数,并检查是否超出重试次数
                if (times++ > _reTryTimes)
                    break;

                try
                {
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            System.Threading.Thread.Sleep(1000); //如果状态不对,则延时 1s 后重试
                            continue;
                        }

                        var rs = response.GetResponseStream();

                        if (rs == null)
                            return null;

                        rs.CopyTo(stream);

                        break;
                    }
                }
                catch (Exception ex)
                {
                    //写日记
                    //Log.LogHelper.Log(GetType().FullName, ex.Message + "-->" + ex.StackTrace);
                    string namesSpace = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Namespace;
                    string className = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name;
                    string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                    Utility.Log.Logger.Write(ETong.Common.Enum.Log.Log_Type.Info, namesSpace, className, methodName, GetType().FullName, ex.Message + "-->" + ex.StackTrace);

                }
            }

            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// 提交请求，返回字符串结果
        /// </summary>
        /// <returns></returns>
        public string SendByStringResult()
        {
            return SendByStringResult(Encoding.UTF8);
        }

        /// <summary>
        /// 提交请求，返回字符串结果
        /// </summary>
        /// <returns></returns>
        public string SendByStringResult(Encoding encoding)
        {
            var stream = Send();

            if (stream == null)
                return string.Empty;

            var sr = new StreamReader(stream, encoding);

            var json = sr.ReadToEnd();

            sr.Close();
            stream.Close();

            return json;
        }

        /// <summary>
        /// 提交请求，返回复杂类型结果
        /// </summary>
        /// <returns></returns>
        public T SendByObjectResult<T>()
        {
            return SendByObjectResult<T>(Encoding.UTF8);
        }

        /// <summary>
        /// 提交请求，返回复杂类型结果
        /// </summary>
        /// <returns></returns>
        public T SendByObjectResult<T>(Encoding encoding)
        {
            var stream = Send();

            if (stream == null)
                return default(T);

            var sr = new StreamReader(stream, encoding);

            var json = sr.ReadToEnd();

            var result = JsonConvert.DeserializeObject<T>(json);

            sr.Close();
            stream.Close();

            return result;
        }
        #endregion
    }
}
