using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using ETong.WebApi.Core;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using ETong.WebApi.Server.Core;
using log4net;
using Newtonsoft.Json;
using System.Web;
using System.ServiceModel.Channels;

namespace ETong.WebApi.Server.Filters
{
    public class SignValidateActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Action执行前的过滤器
        /// </summary>
        /// <param name="actionContext">操作执行的上下文</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            //调试 记录
            ILog log = LogManager.GetLogger(this.GetType().Name);

            var method = actionContext.Request.Method;
            var client = GetClientIP(actionContext.Request);
            var reqUrl = client + "=>" + method.Method + "=>" + actionContext.Request.RequestUri.ToString();
            if (method.Method.ToUpper() == "GET" || method.Method.ToUpper() == "DELETE")
            {
                
                log.Debug(actionContext.Request.RequestUri);
                var urlarguments = actionContext.Request.GetQueryNameValuePairs();
                string requestsign;
                string requesttime;

                if (!urlarguments.Any(o => o.Key.ToLower() == "reqtime"))
                {
                    throw new ArgumentException("URL不含请求参数reqTime！" + reqUrl);
                }
                requesttime = urlarguments.FirstOrDefault(o => o.Key.ToLower() == "reqtime").Value;
                actionContext.Request.Headers.Add("resTime", new string[1] { requesttime });

                if (!urlarguments.Any(o => o.Key.ToLower() == "sign"))
                {
                    throw new ArgumentException("URL不含请求参数sign！" + reqUrl);
                }
                requestsign = urlarguments.FirstOrDefault(o => o.Key.ToLower() == "sign").Value;

                SortedList<string, object> slist = new SortedList<string, object>();

                foreach (var c in urlarguments)
                {
                    if (c.Key.ToLower() != "reqtime" && c.Key.ToLower() != "sign" && !string.IsNullOrWhiteSpace(c.Key))
                        slist.Add(c.Key, c.Value);
                }
                var sigh = SignBuilder.BuildSignList(slist,"","", requesttime);
                if (requestsign != sigh.Sign)
                {
                    throw new ArgumentException("签名失败！" + reqUrl);
                }
                actionContext.ActionArguments.Remove(urlarguments.FirstOrDefault(o => o.Key.ToLower() == "reqtime").Key);
                actionContext.ActionArguments.Remove(urlarguments.FirstOrDefault(o => o.Key.ToLower() == "sign").Key);
                actionContext.Request.Headers.Add("resTime", new string[1] { requesttime });
              
              
            }

            if (method.Method.ToUpper() == "POST" || method.Method.ToUpper() == "PUT")
            {
                var stream = actionContext.Request.Content.ReadAsStreamAsync();
                stream.Wait();
                Encoding encoding = Encoding.UTF8;
                stream.Result.Position = 0;
                string responseData = "";
                using (StreamReader reader = new StreamReader(stream.Result, encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                }

                log.Debug(responseData);

                if (!string.IsNullOrWhiteSpace(responseData))
                {
                    var urlarguments = actionContext.Request.GetQueryNameValuePairs();
                    Type contenttype=null;
                    var httpParameterDescriptor = actionContext.ActionDescriptor.GetParameters().FirstOrDefault(o => urlarguments.All(m => o.ParameterName != m.Key));
                    if (httpParameterDescriptor != null)
                        contenttype=    httpParameterDescriptor.ParameterType;
                  
                    if(contenttype==null)
                        throw new Exception("无法识别参数！" + reqUrl);
                   
                    Type genericType = typeof(RequestInfo<>);
                    Type[] templateTypeSet = new[] { contenttype };
                    Type implementType = genericType.MakeGenericType(templateTypeSet);
                    var originpostdata = Newtonsoft.Json.JsonConvert.DeserializeObject(responseData, implementType);

                    var datamap = implementType.GetProperty("dataMap").GetValue(originpostdata);
                    //if (datamap == null)
                    //{
                    //    throw new ArgumentException("content不含请求参数dataMap！");
                    //}

                    var odatetime = implementType.GetProperty("reqTime").GetValue(originpostdata);
                  
                    if (odatetime == null)
                    {
                        throw new ArgumentException("content不含请求参数reqTime！" + reqUrl);
                    }
                    actionContext.Request.Headers.Add("resTime", new string[1] { odatetime.ToString() });
                    string datetime = implementType.GetProperty("reqTime").GetValue(originpostdata).ToString();

                    var oreqsign = implementType.GetProperty("sign").GetValue(originpostdata);

                    if (oreqsign == null)
                    {
                        throw new ArgumentException("content不含请求参数reqsign！" + reqUrl);
                    }

                    string reqsign = implementType.GetProperty("sign").GetValue(originpostdata).ToString();


                    var sigh = SignBuilder.BuildSign(datamap,"","", datetime);
                    if (reqsign != sigh.Sign)
                    {
                        throw new ArgumentException("签名失败！" + reqUrl);
                    }
                    if (httpParameterDescriptor.ParameterName != null)
                    {
                        actionContext.ActionArguments.Remove(httpParameterDescriptor.ParameterName);
                        actionContext.ActionArguments.Add(httpParameterDescriptor.ParameterName, datamap);
                    }
           
                }
            }
            actionContext.Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

            // 来访信息，日志用。
            var method = actionExecutedContext.Request.Method;
            var client = GetClientIP(actionExecutedContext.Request);
            var reqUrl = client + "=>" + method.Method + "=>" + actionExecutedContext.Request.RequestUri.ToString();

            // 检查请求头(headers)是否设"Accept", 如果设了"Accept"必须有要接受/json格式
            if (actionExecutedContext.Request.Headers != null)
            {
                var headers = actionExecutedContext.Request.Headers;
                var accept = headers.FirstOrDefault(o => o.Key.ToLower() == "accept").Value;
                if (accept != null)
                {
                    var acceptJsons = accept.Where(x => (x.ToLower().Contains("*/*") || x.ToLower().Contains("json")) && !x.ToLower().Contains("q=0")).ToList();
                    if (acceptJsons.Count <= 0)
                    {
                        throw new ArgumentException("Headers指定了Accept但没有接受json格式。请不要设置Accept或设置Accept时需要包含接受json格式！" + reqUrl);
                    }
                }
            }
            
            var responseinfo = new ResponseInfo<Object>();
            //写入回复         
            try
            {
                var returntype = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType;
                if (returntype != null)
                {
                    var resultstring = "";
                    if (actionExecutedContext.Response.Content != null)
                    {
                        resultstring = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;
                        //Type genericType = typeof(RequestInfo<>);
                        //Type[] templateTypeSet = new[] { postargument.Value.GetType() };
                        responseinfo.dataMap = JsonConvert.DeserializeObject(resultstring, returntype);
                    }
                }

                if (responseinfo.dataMap != null)
                {
                    var sign = SignBuilder.BuildSign(responseinfo.dataMap, "", "");
                    responseinfo.sign = sign.Sign;
                    responseinfo.respTime = sign.ReqTime;
                }
                responseinfo.respCode = "0";
                responseinfo.respMsg = "接口调用成功！";
                responseinfo.reqTime = actionExecutedContext.Request.Headers.GetValues("resTime").FirstOrDefault();

                var s = JsonConvert.SerializeObject(responseinfo);
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse<ResponseInfo<Object>>(responseinfo);
            }
            catch (Exception ex)
            {
                throw new Exception("设置签名信息失败！" + reqUrl);
            }
        }

        private string GetClientIP(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return null;
            }  
        }
    }
}
