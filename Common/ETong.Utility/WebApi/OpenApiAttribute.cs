using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ETong.Utility.WebApi
{
    public class OpenApiAttribute:ActionFilterAttribute
    {
        public OpenApiAttribute(string api)
        {
 
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Request.Headers.Where(o => o.Key == "").FirstOrDefault();

            base.OnActionExecuting(actionContext);
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
