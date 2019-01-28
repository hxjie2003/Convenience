using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Infrasture
{
    /// <summary>
    /// APP在使用中的API。
    /// </summary>
    public class OpenApiUsageInfo
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// APIID
        /// </summary>
        public string ApiId { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 是否申核通过
        /// </summary>
        public bool IsApproved { get; set; }
        /// <summary>
        /// 允许POST
        /// </summary>
        public bool AllowPost { get; set; }
        /// <summary>
        /// 允许GET
        /// </summary>
        public bool AllowGet { get; set; }
        /// <summary>
        /// 允许Put
        /// </summary>
        public bool AllowPut { get; set; }
        /// <summary>
        /// 允许Delete
        /// </summary>
        public bool AllowDelete { get; set; }
        /// <summary>
        /// API的信任站点。即APP向API提交的信任web站点。用于权限及跨域访问。
        /// </summary>
        public List<string> ReliableUrls { get; set; }
    }

    /// <summary>
    /// APP的开放API列表。
    /// </summary>
    public class OpenAppWithApiUsagesInfo
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 在使用中的API列表
        /// </summary>
        public List<OpenApiUsageInfo> Apis { get; set; }
    }

}
