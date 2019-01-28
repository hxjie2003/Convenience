using ETong.WebApi.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ETong.WebApi.Server.Core
{
    public class SignBuilder
    {
        private const string DateTimeFormat = "yyyyMMddHHmmss";

        public static SignInfo BuildSign(Object orderinfo,string version ,string reqfrom,string createdate=null)
        {
            var values = new SortedList<string, object>();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(orderinfo))
            {
                var v = descriptor.GetValue(orderinfo);
                if (v != null)
                    values.Add(descriptor.Name, v);
            }
            return BuildSignList(values, version, reqfrom, createdate);
        }

        public static SignInfo BuildSignList(SortedList<string, object> values, string version, string reqfrom, string createdate = null)
        {            
            DateTime signTime = DateTime.Now; 
            object memberid = string.Empty;
            if (values != null)
            {
                values.TryGetValue("memberId", out memberid);
            }
            else
            {
                values = new SortedList<string, object>();
            }
            ApiSetting config = new ApiSetting(null);
            string password = string.Empty;
            if (memberid == null || string.IsNullOrEmpty(memberid.ToString()))
            {
                memberid = config.DefaultMemberId;
                password = config.DefaultMemberPwd;
            }
            if (string.IsNullOrWhiteSpace(password))
                password = MemberPwdManager.GetPassword(memberid.ToString());
            var datetime = signTime.ToString(DateTimeFormat);
            if (!string.IsNullOrWhiteSpace(createdate))
            {
                datetime = createdate;
            }
            ILog log = LogManager.GetLogger(typeof (SignBuilder));
            log.InfoFormat("user:{0} password:{1}",memberid,password);
            values.Add("reqTime", datetime);

            if (!string.IsNullOrWhiteSpace(version))
            {
                values.Add("version", version);
            }
            if (!string.IsNullOrWhiteSpace(reqfrom))
            {
                values.Add("reqFrom", reqfrom);
            }
            //values.Add("", password);
            var stringtosign = string.Empty;
            var x = values.OrderBy(o => o.Key);
            foreach (var keyvaluepair in x)
            {
                if (keyvaluepair.Value is string)
                {
                    string value = "";
                    value = keyvaluepair.Value.ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        if (!string.IsNullOrWhiteSpace(stringtosign))
                            stringtosign += "&";
                        stringtosign += keyvaluepair.Key + "=" + value;
                    }
                }
            }
            var encyptstring =
                MD5.Encrypt(AES.Encrypt(password, MD5.Encrypt(memberid + datetime).Substring(0, 16)));
            stringtosign += encyptstring;

            var sign = MD5.Encrypt(stringtosign);
            var singinfo = new SignInfo() { ReqTime = datetime, Sign = sign };
            return singinfo;
        }
    }

    /// <summary>
    /// 签名信息
    /// </summary>
    public class SignInfo
    {
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public string ReqTime { set; get; }

    }
}
