using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Infrasture
{
    /// <summary>
    /// EF元数据信息。
    /// </summary>
    public class DBMetadataArg
    {
        /// <summary>
        /// 连接键
        /// </summary>
        public string ConnectionKey { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 元数据库路径
        /// </summary>
        public string MetadataPath { get; set; }
        /// <summary>
        /// 元数据键 
        /// </summary>
        public string MetadataKey { get; set; }
    }
}
