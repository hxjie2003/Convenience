using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// 采集数据项
    /// </summary>
    public class MonitorDataItem : MarshalByRefObject
    {
        /// <summary>
        /// 监控编号
        /// </summary>
        public string MonitorId { set; get; }

        /// <summary>
        /// 监控代码
        /// </summary>
        public string MonitorCode { set; get; }

        /// <summary>
        /// 监控名称
        /// </summary>
        public string MonitorName { set; get; }

        /// <summary>
        /// 监控结果
        /// </summary>
        public string MonitorValue { set; get; }

        /// <summary>
        /// 采集内容
        /// </summary>
        public string CollectValue { set; get; }

        /// <summary>
        /// 采集时间
        /// </summary>
        public string CollectDate { set; get; }
    }
}
