using ETong.WebApiUtility.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace ETong.WebApiUtility
{
    public class HttpClientProxy
    {
        private readonly string _appId;
        private readonly string _appVar;
        private readonly string _url;

        public HttpClientProxy(string url)
        {
            _url = url;

            _appVar = "0.0.0";
            _appId = Guid.Empty.ToString();
        }

        public HttpClientProxy(string url, string appVar, string appId)
        {
            _url = url;

            _appVar = appVar;
            _appId = appId;
        }

        public T Post<T>(dynamic obj)
        {
            var client = new HttpClientUtility(new Uri(_url));
            var result = client.PostAsync<T, object>(
                _url,
                MediaTypeEnum.Json,
                obj,
                GetHeaderRequestInfo());

            return result;
        }

        public TResult Delete<TResult>()
        {
            var client = new HttpClientUtility(new Uri(_url));
            var result = client.DeleteAsync<TResult>(
                _url,
                MediaTypeEnum.Json,
                GetHeaderRequestInfo());

            return result;
        }
        public T Get<T>(dynamic obj)
        {
            var fullPath = _url;
            if (obj != null)
            {
                var param = ToData(ToNameValueCollection(obj));
                fullPath += "?" + param;
            }
            var client = new HttpClientUtility(new Uri(fullPath));
            var result = client.GetAsync<T>(
              fullPath,
              MediaTypeEnum.Json,
              GetHeaderRequestInfo());
            return result;
        }

        private HeaderRequestInfo GetHeaderRequestInfo()
        {
            return new HeaderRequestInfo
            {
                ApiVersion = _appVar,
                AppId = _appId,
                Format = "XMLJSON",
                OperatingSystem = OperatingSystemEnum.Web,
                Session = string.Empty,
                Sign = string.Empty,
                TimeStamp = DateTime.Now
            };
        }

        #region static

        private static NameValueCollection ToNameValueCollection(object paramObj)
        {
            var result = new NameValueCollection();
            if (paramObj == null)
            {
                return result;
            }

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(paramObj))
            {
                var objV = descriptor.GetValue(paramObj);
                string value = objV == null ? "" : objV.ToString();
                result.Add(descriptor.Name, value);
            }

            return result;
        }

        private static string ToData(NameValueCollection nameValue)
        {
            var result = new List<string>();
            var first = true;
            foreach (var key in nameValue.AllKeys)
            {
                var value = HttpUtility.UrlEncode(nameValue.Get(key));
                result.Add(key + "=" + value);
            }
            return String.Join("&", result);
        }

        public static string ToSign(object paramObj, string signKey = "", char joinKeyStr = '&')
        {
            var result = string.Empty;

            if (paramObj == null)
            {
                return string.Empty;
            }

            var paramList = ToStringList(paramObj);
            paramList.OrderBy(o => o).ToList().ForEach(o => {
                result += o + joinKeyStr;
            });
            result = result.Trim(joinKeyStr);

            if (!string.IsNullOrWhiteSpace(signKey))
            {
                //result += joinKeyStr + signKey;
                result += signKey;
            }

            //result = HttpUtility.UrlEncode(result);
            result = ETong.Utility.Security.MD5.Encrypt(result, Encoding.Default);

            return result;
        }

        public static string ToSign(Dictionary<string, string> paramObj, string signKey = "", string joinKeyStr = "&")
        {
            var result = string.Empty;

            if (paramObj == null)
            {
                return string.Empty;
            }

            paramObj.OrderBy(o => o.Key).ToList().ForEach(o =>
            {
                result += o.Key + "=" + o.Value + "&";
            });
            result = result.Trim('&');

            if (!string.IsNullOrWhiteSpace(signKey))
            {
                result += joinKeyStr + signKey;
            }

            //result = HttpUtility.UrlEncode(result);
            result = ETong.Utility.Security.MD5.Encrypt(result, Encoding.Default);

            return result;
        }

        public static string ToQueryUrl(string baseUrl, object paramObj)
        {
            var result = string.Empty;

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                return string.Empty;
            }

            var param = string.Empty;
            if (paramObj != null)
            {
                var paramList = ToStringList(paramObj);
                paramList.ForEach(o =>
                {
                    param += o + "&";
                });
                param = param.Trim('&');
            }

            if (!string.IsNullOrWhiteSpace(param))
            {
                result = baseUrl + "?" + param;
            }

            return result;
        }

        public static string ToQueryUrl(string baseUrl, Dictionary<string, string> paramObj)
        {
            var result = string.Empty;

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                return string.Empty;
            }

            var param = string.Empty;
            if (paramObj != null)
            {
                paramObj.ToList().ForEach(o =>
                {
                    param += o.Key + "=" + o.Value + "&";
                });
                param = param.Trim('&');
            }

            if (!string.IsNullOrWhiteSpace(param))
            {
                result = baseUrl + "?" + param;
            }

            return result;
        }

        private static List<string> ToStringList(object paramObj)
        {
            var result = new List<string>();

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(paramObj))
            {
                var objV = descriptor.GetValue(paramObj);
                string value = objV == null ? "" : objV.ToString();
                result.Add(descriptor.Name + "=" + value);
            }

            return result;
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return System.Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        #endregion
    }
}