using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation
{
    public class OpenApiHeaders
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 应用Key
        /// </summary>
        //public string AppKey { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime TimeStamp  { get; set; }
        /// <summary>
        /// 会话
        /// </summary>
        public string Session { get; set; }
        /// <summary>
        /// Appkey后的签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 操作系统 android,etm,ios
        /// </summary>
        public string OperatingSystem { get; set; }
        /// <summary>
        /// etmid
        /// </summary>
        public string EtmId { get; set; }
    }
}
