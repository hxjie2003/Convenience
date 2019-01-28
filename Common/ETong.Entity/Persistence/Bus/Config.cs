using System;

namespace ETong.Entity.Persistence.Bus
{
    [Serializable]
    public class Config
    {
        public Config()
        {
            //ServiceUrl = "http://219.136.133.169:8002/kplw/BookTickets.asmx";
            //AgentCode = "1024";
            //HashSource = "0000000000000000";

            //SmsTemplateSubmitOrder = "您好！汽车票已预订成功，订单号：{orderid}，发车时间：{date}{time}，{source}至{dest}，取票密码:{password}。提示凭已登记的身份证号码原件到汽车站服务窗口取票，客服：400-000-8111";

            //SmsUrl = "http://localhost:2002/api/SmsMessage";
        }

        /// <summary>
        /// 短信地址
        /// </summary>
        public string SmsUrl { get; set; }

        /// <summary>
        /// 广州交投汽车购票服务地址
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// 代理点编码
        /// </summary>
        public string AgentCode { get; set; }

        /// <summary>
        /// 加密密钥
        /// </summary>
        public string HashSource { get; set; }

        /// <summary>
        /// 短信通知模板
        /// </summary>
        public string SmsTemplateSubmitOrder { get; set; }
    }
}