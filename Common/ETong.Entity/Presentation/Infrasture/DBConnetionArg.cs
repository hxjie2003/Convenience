using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Infrasture
{
    /// <summary>
    /// 数据库连接信息
    /// </summary>
    public class DBConnetionArg
    {
        /// <summary>
        /// 连接键
        /// </summary>
        public string ConnectionKey { get; set; }
        /// <summary>
        /// 连接字符串。需加密
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
