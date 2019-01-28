//-----------------------------------------------------------------------
// <copyright file="ActionFilter.cs" company="Etong">
//     WebApi的Action过滤器
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Globalization;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ETong.Entity;
using ETong.WebApiUtility.Entity;

namespace ETong.WebApiUtility.Filter
{
    /// <summary>
    /// Action拦截器
    /// </summary>
    public class ActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Action执行前的过滤器
        /// </summary>
        /// <param name="actionContext">操作执行的上下文</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// Action执行完成的过滤器
        /// </summary>
        /// <param name="actionExecutedContext">操作执行的上下文</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            // 不处理异常事件，异常由ExceptionFilter进行处理
            if (actionExecutedContext.Exception != null)
            {
                return;
            }

            // 不处理http状态码为200的action，例如路由不匹配action等则无须处理
            if (actionExecutedContext.Response.StatusCode != HttpStatusCode.OK && actionExecutedContext.Response.StatusCode != HttpStatusCode.NoContent)
            {
                return;
            }

            // 特殊处理，当HttpStatusCode.NoContent时也当作HttpStatusCode.OK处理，因为客户端就只验证状态码为200，对于204状态码会当作异常处理
            if (actionExecutedContext.Response.StatusCode == HttpStatusCode.NoContent)
            {
                actionExecutedContext.Response.StatusCode = HttpStatusCode.OK;
            }

            // 写入head
            var head = new HeaderResponsetInfo
                           {
                               ApiCode = ((int)actionExecutedContext.Response.StatusCode).ToString(CultureInfo.InvariantCulture),
                               ApiMessage = "OK",
                               ApiVersion = "v2.0.0"
                           };
            try
            {
                actionExecutedContext.Response.SetResponseHeadInfo(head);
            }
            catch (Exception ex)
            {
                throw new ErrorCodeException("500", "设置http head 出现失败，原因:" + ex.Message, "SystemError");
            }
        }
    }
}
