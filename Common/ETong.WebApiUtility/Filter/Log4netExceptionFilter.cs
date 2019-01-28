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
using ETong.Common.Enum;
using ETong.Entity;
using ETong.Utility.Log;
using ETong.WebApiUtility.Entity;
using utility = ETong.WebApiUtility.Convert;
using log4net;

namespace ETong.WebApiUtility.Filter
{
    using ETong.Utility.Converts;

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
                    // 异常时直接抛出500错误
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
                    var exception = actionExecutedContext.Exception as ErrorCodeException;
                    if (exception == null)
                    {
                        // 系统系统时
                        /*exception = new ErrorCodeException("500", actionExecutedContext.Exception.Message,
                            "SystemError!");*/
                        exception = new ErrorCodeException("500", actionExecutedContext.Exception.Message,
                            actionExecutedContext.Exception)
                        {
                            DisplayMessage = actionExecutedContext.Exception.Message
                        };
                    }

                    ILog log = LogManager.GetLogger(this.GetType().Name);
                    // 写入head
                    var head = new HeaderResponsetInfo
                    {
                        ApiCode = exception.ErrorCode,
                        ApiMessage = exception.DisplayMessage,
                        ApiVersion = "v2.0.0"
                    };
                    try
                    {
                        actionExecutedContext.Response.SetResponseHeadInfo(head);
                    }
                    catch (Exception ex)
                    {
                        var msg = BuildMesageStack(ex);
                        log.Error("拦截异常HttpHead信息：" + Json.Encode(head));
                        log.Error("拦截异常发生错误，原因：" + msg);
                    }


                    // 使用log4net写入
                    /*var excptionMsg = exception.Message
                                      + (exception.InnerException != null ? ".InnerException:" + exception.InnerException.Message : string.Empty);*/

                    var excptionMsg = BuildMesageStack(exception);

                    excptionMsg.AppendLine("ErrorCode:" + exception.ErrorCode);
                    excptionMsg.AppendLine("DisplayMessage:" + exception.DisplayMessage);
                    log.Error(excptionMsg.ToString());

                    actionExecutedContext.Response.Content = new StringContent(actionExecutedContext.Exception.Message);





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