//-----------------------------------------------------------------------
// <copyright file="ExceptionFilter.cs" company="Etong">
//     WebApi的异常拦截器
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using log4net;
using ETong.WebApi.Core;
using ETong.WebApi.Server.Core;
using System.Linq;
using ETong.WebApi.Server.Models;

namespace ETong.WebApi.Server.Filters
{


    /// <summary>
    ///     异常拦截器
    /// </summary>
    public class Log4netExceptionFilter : IExceptionFilter
    {
        /// <summary>
        ///     Gets or sets a AllowMultiple
        /// </summary>
        public bool AllowMultiple
        {
            get { return false; }
        }

        /// <summary>
        ///     异常筛选器
        /// </summary>
        /// <param name="actionExecutedContext">异常类型</param>
        /// <param name="cancellationToken">取消标记</param>
        /// <returns>异步异常筛选器</returns>
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(
                () =>
                {                
                    actionExecutedContext.Response =
                        actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError);

                    // 路由相关的信息 (收集信息，暂时不需要记录所以注释该段代码)
                    ////var route = actionExecutedContext.Request.GetRouteData().Route.RouteTemplate;
                    ////var method = actionExecutedContext.Request.Method.Method;
                    ////var url = actionExecutedContext.Request.RequestUri.AbsoluteUri;
                    //var controllerName =
                    //    actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    //var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                
                    

                    // 业务模块抛出的异常信息
                    var exception = actionExecutedContext.Exception ;
                    var codeexception = actionExecutedContext.Exception as ErrorCodeException;                
                    ILog log = LogManager.GetLogger(this.GetType().Name);   
                    var excptionMsg = BuildMesageStack(exception);          
                    excptionMsg.AppendLine("DisplayMessage:" + exception.Message);
                    log.Error(excptionMsg.ToString());
                    ResponseInfo<Object> response = new ResponseInfo<object>();
                    var sign= SignBuilder.BuildSign(null,"","");
                    response.respTime =sign.ReqTime;
                    response.respMsg = exception.Message;
                    response.sign = sign.Sign;
                    response.respCode = "401";
                    if (codeexception != null)
                    {
                        response.respCode = codeexception.ErrorCode;
                    }
                    //if (actionExecutedContext.Request.Headers.GetValues("resTime") != null &&
                    if (actionExecutedContext.Request.Headers.Any(o => o.Key == "resTime") &&
                        actionExecutedContext.Request.Headers.GetValues("resTime").Any())
                    {
                        response.reqTime = actionExecutedContext.Request.Headers.GetValues("resTime").FirstOrDefault();
                    }
                    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse<ResponseInfo<Object>>(response); 
                },
                cancellationToken);
        }

        private StringBuilder BuildMesageStack(Exception curExcepiton)
        {
            var msg = new StringBuilder();
            do
            {
                msg.AppendLine("ExcepitonMessage:" + curExcepiton.Message);
                msg.AppendLine("StackTrace:" + curExcepiton.StackTrace);
                curExcepiton = curExcepiton.InnerException;
            } while (curExcepiton != null);
            return msg;
        }


    }
}