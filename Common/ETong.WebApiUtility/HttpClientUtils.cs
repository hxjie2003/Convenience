using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ETong.WebApiUtility
{
    public class HttpClientUtils
    {
        public static string Get(string apiUrl, Encoding encoding = null)
        {
            var result = string.Empty;

            var req = WebRequest.Create(apiUrl);
            req.Timeout = 300000;
            req.Method = "get";
            req.ContentType = "application/json;charset=UTF-8";
            req.Headers[HttpRequestHeader.CacheControl] = "no-cache";

            //读取对方服务器返回的消息
            using (var rsp = req.GetResponse())
            {
                if (rsp != null)
                {
                    //encoding = encoding == null ? Encoding.Default : encoding;
                    encoding = encoding == null ? Encoding.UTF8 : encoding;
                    using (var answerReader = new StreamReader(rsp.GetResponseStream(), encoding))
                    {
                        result = answerReader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        public static string Post(string apiUrl, string content, Encoding encoding = null)
        {
            //et0001, 123456
            var result = string.Empty;

            var uri = apiUrl;
            var req = WebRequest.Create(uri);
            req.Timeout = 300000;  //timeout
            req.Method = "post";
            req.ContentType = "application/json;charset=UTF-8";
            req.Headers[HttpRequestHeader.CacheControl] = "no-cache";

            encoding = encoding == null ? Encoding.Default : encoding;

            using (var writer = new StreamWriter(req.GetRequestStream(), encoding))
            {
                writer.WriteLine(content);
                writer.Close();
            }

            //读取对方服务器返回的消息
            using (var rsp = req.GetResponse())
            {
                req.GetRequestStream().Close();
                if (rsp != null)
                {
                    using (var answerReader = new StreamReader(rsp.GetResponseStream(), encoding))
                    {
                        result = answerReader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        public static string PostXML(string apiUrl, string svrName, string xml, Encoding encoding = null)
        {
            //et0001, 123456
            var result = string.Empty;
            try
            {
                var uri = apiUrl + "/" + svrName + "/?wsdl";
                var req = WebRequest.Create(uri);
                req.Timeout = 300000;  //timeout
                req.Method = "post";
                req.ContentType = "text/xml;charset=UTF-8";
                req.Headers[HttpRequestHeader.CacheControl] = "no-cache";

                encoding = encoding == null ? Encoding.Default : encoding;

                using (var writer = new StreamWriter(req.GetRequestStream(), encoding))
                {
                    writer.WriteLine(xml);
                    writer.Close();
                }

                //读取对方服务器返回的消息
                using (var rsp = req.GetResponse())
                {
                    req.GetRequestStream().Close();
                    if (rsp != null)
                    {
                        using (var answerReader = new StreamReader(rsp.GetResponseStream(), encoding))
                        {
                            result = answerReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Log("FW1007", ex.StackTrace);
            }

            return result;
        }

    }
}
