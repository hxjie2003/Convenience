using System.Net.Http;
using ETong.Cache;
using ETong.Entity;
using ETong.Entity.Persistence.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace ETong.Utility.Message
{
    /// <summary>
    /// 短信客户端
    /// </summary>
    public class SmsClient
    {
        public ResultData<string> SendSms(SmsMessageArgs message)
        {
            ResultData<string> result = new ResultData<string>();
            string url = ConfigurationManager.AppSettings["sms_api_baseuri"].ToString();
            url = url + "/api/SmsMessage";
            url = url.Replace("//", "/");
            url = url.Replace("http:/", "http://");
            if (string.IsNullOrEmpty(url))
            {

                result.Success = false;
                result.Message = "短信配置sms_sms为空";
            }
            else
            {
                HttpClient httpClient = new HttpClient();
                var httpResposeMessage = httpClient.PostAsJsonAsync(url, message).Result;
                var jsonResult = httpResposeMessage.Content.ReadAsStringAsync().Result;
                result.Message = JsonConvert.DeserializeObject<string>(jsonResult);
                result.Success = true;
            }
            return result;
        }
    }
}
