//-----------------------------------------------------------------------
// <copyright file="HeaderInfoUtility.cs" company="Etong">
//     Http head的工具类
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using ETong.WebApiUtility.Entity;

namespace ETong.WebApiUtility
{
    /// <summary>
    /// 提供访问对http head的类
    /// </summary>
    public static class HeaderInfoUtility
    {
        /// <summary>
        /// 获取Request的head
        /// </summary>
        /// <param name="headers">
        /// http的head
        /// </param>
        /// <returns>
        /// 返回指定上下文的head
        /// </returns>
        public static Entity.HeaderRequestInfo GetRequestHeadInfo(this 
            HttpRequestHeaders headers)
        {
            Entity.HeaderRequestInfo result;
            try
            {
                var head = headers.ToList();
                result = Convert.ConvertUtility.StringCollectionToEntity<Entity.HeaderRequestInfo>(head);
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// 获取response的head
        /// </summary>
        /// <param name="headers">http的head</param>
        /// <returns>返回指定上下文的head</returns>
        public static Entity.HeaderResponsetInfo GetResponseHeadInfo(this 
            HttpResponseHeaders headers)
        {
            Entity.HeaderResponsetInfo result;
            try
            {
                var head = headers.ToList();
                result = Convert.ConvertUtility.StringCollectionToEntity<Entity.HeaderResponsetInfo>(head);
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }


        /// <summary>
        /// 设置Request的head
        /// </summary>
        /// <param name="headers">
        /// Request的中下文.
        /// </param>
        /// <param name="header">
        /// head的实体
        /// </param>
        public static void SetRequestHeadInfo(this HttpRequestHeaders headers, HeaderRequestInfo header)
        {
            if (header == null)
            {
                return;
            }
            var dict = Convert.ConvertUtility.EntityToDictionary(header);
            foreach (var li in dict)
            {
                headers.Add(li.Key, li.Value);
            }
        }

        /// <summary>
        /// 设置Response的head
        /// </summary>
        /// <param name="content">
        /// Responset的上下文.
        /// </param>
        /// <param name="header">
        /// head的实体
        /// </param>
        public static void SetResponseHeadInfo(this HttpResponseMessage content, HeaderResponsetInfo header)
        {
            var dict = Convert.ConvertUtility.EntityToDictionary(header);
            foreach (var li in dict.Where(x => x.Key != null && x.Value != null))
            {
                content.Headers.Add(li.Key, li.Value);
            }
        }

        /// <summary>
        /// 返回响应类型
        /// </summary>
        /// <param name="mediaType">
        /// 枚举类型  json or xml
        /// </param>
        /// <returns>
        /// The <see cref="MediaTypeWithQualityHeaderValue"/>.
        /// </returns>
        public static MediaTypeWithQualityHeaderValue GetMediaTpye(MediaTypeEnum mediaType)
        {
            var pre = "application/";
            switch (mediaType)
            {
                case MediaTypeEnum.Json:
                    pre = "application/";
                    break;
                case MediaTypeEnum.Xml:
                    pre = "application/";
                    break;
                case MediaTypeEnum.Plain:
                    pre = "text/";
                    break;
            }

            return new MediaTypeWithQualityHeaderValue(pre + mediaType.ToString().ToLower());
        }
    }
}
