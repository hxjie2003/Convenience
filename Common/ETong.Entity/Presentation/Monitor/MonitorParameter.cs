using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// 监控参数
    /// </summary>
    [Serializable]
   public class MonitorParameter
    {
       /// <summary>
       /// 是否监控所有信息
       /// 默认为：0 监控所有
       /// </summary>
       public int MonitorAll { set; get; }

       /// <summary>
       /// 监控列表，使用监控编号
       /// </summary>
       public List<string> MonitorCodeList { set; get; }

       /// <summary>
       /// 监控参数信息
       /// </summary>
       public Dictionary<string,string> ParameterList { set; get; }
    }
}
