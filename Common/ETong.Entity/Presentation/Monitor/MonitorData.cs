using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// 采集的数据
    /// </summary>
    public class MonitorData : MarshalByRefObject
    {
       /// <summary>
        /// 采集的数据
       /// </summary>
       public string MonitorId { set; get; }

       /// <summary>
       /// ETM编号
       /// </summary>
       public string ETMCode { set; get; }

       /// <summary>
       /// 监控时间
       /// </summary>
       public string MonitorDate { set; get; }

       /// <summary>
       /// 监控项采集数据
       /// </summary>
       public List<MonitorDataItem> Items { set; get; }

       /// <summary>
       /// 监控状态
       /// </summary>
       public int MonitorState { set; get; }

       /// <summary>
       /// 预警级别
       /// </summary>
       public int EarlywarnLevle { set; get; }
    }
}
