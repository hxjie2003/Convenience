using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Upgrade
{
    public class VersionLog
    {
        /// <summary>
        /// 日志编号
        /// </summary>
        public int LOG_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 版本编号
        /// </summary>
        public int VERSION_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 客户机ETM编号
        /// </summary>
        public string CLIENT_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 文件状态（0:未下载，1下载中，2下载成功，3下载失败）
        /// </summary>
        public int FILE_STATUS
        {
            get;
            set;
        }
        /// <summary>
        /// 记录状态（0:待更新，1更新成功，2更新失败）
        /// </summary>
        public int STATUS
        {
            get;
            set;
        }
        /// <summary>
        /// 信息
        /// </summary>
        public string MESSAGE
        {
            get;
            set;
        }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime UPDATED_DATE
        {
            get;
            set;
        }
    }
}
