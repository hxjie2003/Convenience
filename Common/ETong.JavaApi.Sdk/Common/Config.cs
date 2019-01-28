using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class Config
    {
        private static string _javaAnonymousMemberId = System.Configuration.ConfigurationManager.AppSettings["JavaAnonymousMemberId"] ?? "" as string;
        private static string _javaAnonymousMemberPwd = System.Configuration.ConfigurationManager.AppSettings["JavaAnonymousMemberPwd"] ?? "" as string;
        private static string _javaorder_MemberId = System.Configuration.ConfigurationManager.AppSettings["javaorder_MemberId"] ?? "etong_common_user" as string;
        private static string _javaorder_Password = System.Configuration.ConfigurationManager.AppSettings["javaorder_Password"] ?? "e10adc3949ba59abbe56e057f20f883e" as string;

        //java接口根地址
        public static readonly string JavaApiUri = (System.Configuration.ConfigurationManager.AppSettings["JavaApiUri"] ?? "" as string).TrimEnd('/') + "/";
        //运费模板会员id
        public static readonly string JavaAnonymousMemberId = !string.IsNullOrWhiteSpace(_javaAnonymousMemberId) ? _javaAnonymousMemberId : _javaorder_MemberId;
        //运费模板会员pwd
        public static readonly string JavaAnonymousMemberPwd = !string.IsNullOrWhiteSpace(_javaAnonymousMemberPwd) ? _javaAnonymousMemberPwd : _javaorder_Password;

    }
}
