using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Infrasture
{
    /// <summary>
    /// 应用信息
    /// </summary>
    public class OpenApplicationInfo
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 应用密钥
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 应用类型
        /// </summary>
        public string Type { get; set; }
    }
}
