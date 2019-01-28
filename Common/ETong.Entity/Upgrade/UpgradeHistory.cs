using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Upgrade
{
    /// <summary>
    /// 更新日志信息类
    /// </summary>
    public class UpgradeHistory
    {
        /// <summary>
        /// 版本ID
        /// </summary>
        public int VersionID;
        /// <summary>
        /// 版本编号
        /// </summary>
        public string VersionCode;
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName;
        /// <summary>
        /// 文件MD5
        /// </summary>
        public string MD5;
        /// <summary>
        /// Url
        /// </summary>
        public string Url;
        /// <summary>
        /// 是否已下载
        /// </summary>
        public bool IsDownLoad;
        /// <summary>
        /// 是否已更新
        /// </summary>
        public bool IsUpdated;
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime UpdateDate;  
    }
}
