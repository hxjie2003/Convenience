
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ETong.Utility.Comunication
{
    public static class Extension
    {
        /// <summary>
        /// 获取Get参数值
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="context">Http上下文对象</param>
        /// <param name="param">参数名称</param>
        /// <returns></returns>
        public static T Get<T>(this HttpContext context, string param)
        {
            T tvalue = default(T);
            try
            {
                var tmp = context.Request.QueryString[param];

                if (tmp != null)
                {
                    tvalue = (T)System.Convert.ChangeType(tmp, typeof(T));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //TODO:返回前加入防注入
            return tvalue;
        }
        /// <summary>
        /// 获取Post参数值
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="context">Http上下文对象</param>
        /// <param name="param">参数名称</param>
        /// <returns></returns>
        public static T Post<T>(this HttpContext context, string param)
        {
            T tvalue = default(T);
            try
            {
                var tmp = context.Request.Form[param];

                if (tmp != null)
                {
                    tvalue = (T)System.Convert.ChangeType(tmp, typeof(T));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //TODO:返回前加入防注入
            return tvalue;
        }



        /// <summary>
        /// 输出字符串流
        /// </summary>
        /// <param name="context"></param>
        /// <param name="str">要输出的字符串</param>
        public static void Write(this HttpContext context, string str)
        {
            context.Response.Write(str);
        }
    }
}
