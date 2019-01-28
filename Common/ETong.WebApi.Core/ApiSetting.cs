using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.WebApi.Core
{
    public class ApiSetting
    {
        public ApiSetting(CofigApiSetting setting)
        {
            if (setting == null)
            {
                _javafee_url = ConfigurationManager.AppSettings["javafee_uri"];
                _javaorder_url = ConfigurationManager.AppSettings["javaorder_uri"];
                DefaultMemberId = ConfigurationManager.AppSettings["javaorder_MemberId"];               
                DefaultMemberPwd = ConfigurationManager.AppSettings["javaorder_Password"];              
            }
            else
            {
                _javafee_url = setting.JavaFee_Uri;
                _javaorder_url = setting.JavaOrder_Uri;
                DefaultMemberId = setting.DefaultMemberId;
                DefaultMemberPwd = setting.DefaultMemberPwd;
            }
          

            if (string.IsNullOrWhiteSpace(DefaultMemberId))
            {
                throw new ArgumentNullException("DefaultMemberId");
            }
            if (string.IsNullOrWhiteSpace(DefaultMemberPwd))
            {
                throw new ArgumentNullException("DefaultMemberPwd");
            }


        }
        /// <summary>
        /// 默认的会员ID
        /// </summary>
        public string DefaultMemberId { get; set; }
        /// <summary>
        /// 默认的会员密码
        /// </summary>
        public string DefaultMemberPwd { get; set; }

        private string _javaorder_url;
        public string JavaOrder_Uri {
            get
            {
                if (string.IsNullOrWhiteSpace(_javaorder_url))
                {
                    throw new ArgumentNullException("JavaOrder_Uri");
                }
                return _javaorder_url;
            }
        }


        private string _javafee_url;
        public string JavaFee_Uri
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_javafee_url))
                {
                    throw new ArgumentNullException("JavaFee_Uri");
                }
                return _javafee_url;
            }
        }
    }

    public class CofigApiSetting
    {
        public string JavaFee_Uri { get; set; }
        public string JavaOrder_Uri { get; set; }
        public string DefaultMemberId { get; set; }
        public string DefaultMemberPwd { get; set; }
    }



}
