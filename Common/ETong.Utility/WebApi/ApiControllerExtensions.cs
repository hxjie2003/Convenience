using ETong.Entity.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace ETong.Utility.WebApi
{
    /// <summary>
    /// 获取自定义Header,ApiHeaders。
    /// </summary>
    public static class ApiControllerExtensions
    {
        private const string AppId = "appid";
        private const string AppKey = "appkey ";
        private const string TimeStamp = "timestamp";
        private const string Session = "session";
        private const string Sign = "sign";
        public static OpenApiHeaders GetApiHeaders(this ApiController controller)
        {
            var header=controller.Request.Headers;
            OpenApiHeaders headerdetail = new OpenApiHeaders();  
            //获取Appid
            var appidobj = header.GetValues(AppId);
            if (appidobj != null && appidobj.Count() > 0)
            {
                headerdetail.AppId = appidobj.FirstOrDefault();
            } 
            //获取TimeStamp

            var timestampobj = header.GetValues(TimeStamp);
            if (timestampobj != null)
            {
                DateTime time = DateTime.MinValue;
                var timestampstr = timestampobj.FirstOrDefault();
                bool isok = DateTime.TryParse(timestampstr,out time);
                if (isok)
                {
                    headerdetail.TimeStamp = time;
                }
            }
            //获取Session
            var sessionobj = header.GetValues(Session);
            if (sessionobj != null)
            {
                headerdetail.Session = sessionobj.FirstOrDefault();
            }
            //获取sign
            var signobj = header.GetValues(Sign);
            if (signobj != null)
            {
                headerdetail.Sign = signobj.FirstOrDefault();
            }
            return headerdetail;
        }

        public static string GetAppKey(this ApiController controller)
        {
            string appid = string.Empty;
            var appidobj = controller.Request.Headers.Where(o => o.Key == AppKey).FirstOrDefault();
            //appid = appidobj.Value;
            return appid;
        }
    }
}
