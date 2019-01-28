using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Infrasture
{
    /// <summary>
    /// EF连接元数据信息。
    /// </summary>
    public class DBMetadataResult
    {
        /// <summary>
        /// 元数据键
        /// </summary>
        public string MetadataKey { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Connectionstring { get; set; }
        /// <summary>
        /// 元数据
        /// </summary>
        public string Metadata { get; set; }
    }
}
