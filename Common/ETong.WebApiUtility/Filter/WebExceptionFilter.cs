using System;
using System.Net;
using System.Text;
using System.Web.Mvc;
using ETong.Common.Enum;
using ETong.Entity;
using ETong.Utility.Log;
using ETong.WebApiUtility.Entity;

namespace ETong.WebApiUtility.Filter
{
    public class WebExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            // 异常时直接抛出500错误
            /*filterContext.HttpContext.Response =
                actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError);*/
            var exception = filterContext.Exception as ErrorCodeException;

            // 路由相关的信息 (收集信息，暂时不需要记录所以注释该段代码)
            ////var route = actionExecutedContext.Request.GetRouteData().Route.RouteTemplate;
            ////var method = actionExecutedContext.Request.Method.Method;
            ////var url = actionExecutedContext.Request.RequestUri.AbsoluteUri;
            //var controllerName =filterContext.Request
            //    actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

            // 业务模块抛出的异常信息

            if (exception == null)
            {
                // 系统系统时
                /*exception = new ErrorCodeException("500", actionExecutedContext.Exception.Message,
                            "SystemError!");*/
                exception = new ErrorCodeException("500", filterContext.Exception.Message,
                    filterContext.Exception)
                {
                    DisplayMessage = "SystemError!"
                };
            }

            // 写入head
            filterContext.HttpContext.Response.AddHeader("ApiCode", exception.ErrorCode);
            filterContext.HttpContext.Response.AddHeader("ApiMessage", exception.DisplayMessage);
            filterContext.HttpContext.Response.AddHeader("ApiVersion", "v2.0.0");


            // Write log
            /*var excptionMsg = exception.Message
                                      + (exception.InnerException != null ? ".InnerException:" + exception.InnerException.Message : string.Empty);*/

            var excptionMsg = BuildMesageStack(exception);
            object actionName = null;
            if (!filterContext.RouteData.Values.TryGetValue("action", out actionName))
            {
                actionName = "UNKNOW!";

            }

            Logger.Write(
                Log.Log_Type.Error,
                filterContext.Controller.GetType().Namespace,
                filterContext.Controller.GetType().FullName,
                actionName.ToString(),
                excptionMsg.ToString());
        }
        private StringBuilder BuildMesageStack(Exception curExcepiton)
        {
            var excptionMsg = new StringBuilder();
            do
            {
                excptionMsg.AppendLine(curExcepiton.Message);
                excptionMsg.AppendLine(curExcepiton.StackTrace);
                curExcepiton = curExcepiton.InnerException;
            } while (curExcepiton != null);
            return excptionMsg;
        }
    }
}

