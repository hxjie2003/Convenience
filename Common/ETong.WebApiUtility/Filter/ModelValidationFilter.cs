﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace ETong.WebApiUtility.Filter
{
    public class ModelValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                // Return the validation errors in the response body.
                // 在响应体中返回验证错误
                var errors = new Dictionary<string, IEnumerable<string>>();
                foreach (KeyValuePair<string, ModelState> keyValue in actionContext.ModelState)
                {
                    errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                //actionContext.Response = new System.Net.Http.HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest, Content = errors };
                //actionContext.Response.Content = new StringContent(JsonConvert.SerializeObject(errors));
            }
        }
    }
}
