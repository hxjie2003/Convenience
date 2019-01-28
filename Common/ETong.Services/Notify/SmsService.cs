using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ETong.Web;

namespace ETong.Services.Notify
{
    /// <summary>
    /// 短信服务
    /// </summary>
    public class SmsService
    {

        private readonly string _apiUrl;

        public SmsService(string apiUrl)
        {
            if (apiUrl == null) throw new ArgumentNullException("apiUrl");
            _apiUrl = apiUrl.TrimEnd('/') + "/api/SmsMessage"; ;
        }
        public string SendSms(SmsMessageArgs message)
        {
            return WebApiHelper.Post<string>(_apiUrl, message);
        }
    }
}
