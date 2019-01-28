using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web;

namespace ETong.Web
{
    public class EtmInfo
    {
        /// <summary>
        /// Login User
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// Etm Code
        /// </summary>
        public string EtmCode { get; set; }

        public static EtmInfo Create(HttpRequestBase request)
        {
            
            if (request == null) throw new ArgumentNullException("request");
            var header = request.Headers["user-agent"] ?? request.ServerVariables["HTTP-USER-AGENT"];
            /*ETM/1.0 ETM-Code/ETM0019 IP/192.168.0.12 User/LM00013396*/

            if (header == null)
            {
                return new EtmInfo
                {
                    Ip = "Unknown",
                    EtmCode = "Unknown",
                    MemberId = null
                };
            }
            var a = Regex.Matches(header, "(ETM-CODE|IP|User)/[\\w.]*");
            var result = new EtmInfo();
            for (var i = 0; i < a.Count; i++)
            {
                var ary = a[i].Value.Split('/');
                switch (ary[0])
                {
                    case "IP":
                        result.Ip = ary[1];
                        break;
                    case "ETM-CODE":
                        result.EtmCode = ary[1];
                        break;
                    case "User":
                        result.MemberId = ary[1] == "UNKNOWN" ? "" : ary[1];
                        break;
                }
            }
            return result;
        }
    }
}