using System.Collections.Generic;
using System.Web.Mvc;

namespace ETong.Coffee.Web.Controllers
{
    public class EtmClientInfoFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var pa = filterContext.ActionParameters;

            var ip = filterContext.HttpContext.Request.Headers["User-Agent"];
            var keyvaluesstring = ip.Split(' ');
            Dictionary<string, string> keyvalues = new Dictionary<string, string>();
            foreach (var c in keyvaluesstring)
            {
                var s = c.Split('/');
                keyvalues.Add(s[0], s[1]);
            }
            ClientInfo info = new ClientInfo();

            if (keyvalues.ContainsKey("IP"))
            {
                info.Ip = keyvalues["IP"];

            }
            if (keyvalues.ContainsKey("ETM-CODE"))
            {
                info.EtmCode = keyvalues["ETM-CODE"];
            }
            filterContext.Controller.TempData.Add("ClientInfo", info);
            base.OnActionExecuting(filterContext);
        }
    }
    public class ClientInfo
    {
        public string EtmCode { get; set; }
        public string Ip { get; set; }

        public string UserId { get; set; }

        public string ClientVersion { get; set; }
    }
}