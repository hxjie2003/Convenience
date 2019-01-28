using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ETong.QianMi.Logic
{
    public class HttpRequestLogic
    {
        public static string GetHttpRequestInfo(string UrlPath)
        {
            string requestResult = string.Empty;

            HttpWebResponse response = null;
            HttpWebRequest request = null;

            try
            {
                if (UrlPath != null && UrlPath != string.Empty)
                {

                    request = (HttpWebRequest)WebRequest.Create(UrlPath);
                    request.KeepAlive = false;
                    request.Method = "GET";
                    request.Timeout = 10000;
                    request.ReadWriteTimeout = 10000;

                    using (response = (HttpWebResponse)request.GetResponse())
                    {
                        string webResult = ((HttpWebResponse)response).StatusDescription;

                        if (webResult == "OK")
                        {
                            using (StreamReader answerReader = new StreamReader(response.GetResponseStream()))
                            {
                                requestResult = answerReader.ReadToEnd();

                                answerReader.Close();
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                
            }

            if (response != null)
            {
                response.Close();
            }

            if (request != null)
            {
                request.Abort();
            }

            return requestResult;
        }
    }
}
