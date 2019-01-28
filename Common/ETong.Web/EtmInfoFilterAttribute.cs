using System;
using System.Web.Mvc;

namespace ETong.Web
{
    public class EtmInfoFilterAttribute : ActionFilterAttribute
    {
        private readonly string _inputName;

        public EtmInfoFilterAttribute(string inputName)
        {
            if (inputName == null) throw new ArgumentNullException("inputName");
            _inputName = inputName;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var etmInfo = EtmInfo.Create(filterContext.HttpContext.Request);
            filterContext.ActionParameters[_inputName] = etmInfo;
            base.OnActionExecuting(filterContext);
        }
    }
}