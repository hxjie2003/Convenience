using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Infrasture
{
    /// <summary>
    /// 开放API资源
    /// </summary>
    public class OpenApiInfo
    {
        /// <summary>
        /// ID。由系统创建，除非在更新的场合，不要赋值。
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 服务器域名或IP地址
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public decimal? Port { get; set; }
        /// <summary>
        /// 虚拟目录
        /// </summary>
        public string VirtualPath { get; set; }
        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelativeUrl { get; set; }
        /// <summary>
        /// 全路径
        /// </summary>
        public string FullUrl { get; set; }
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 资源名称，控制器
        /// </summary>
        public string ResourceName { get; set; }

    }
}
