using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor 
{
    /// <summary>
    /// 监控安全策略--监控项处理
    /// </summary>
   public class MonitorSecurityPolicyItem
    {
   
       /// <summary>
        /// 安全策略Id
       /// </summary>
        public string SecurityPolicy_Id { set; get; }
      
       /// <summary>
        /// 监控项Id
       /// </summary>
        public string SecurityPolicy_Item_Id { set; get; }
   
       /// <summary>
        /// 安全策略监控项名称
       /// </summary>
        public string SecurityPolicy_Item_Name { set; get; }
        
       /// <summary>
        /// 监控代码
       /// </summary>
        public string MonitorCode { set; get; }
    	
       /// <summary>
        /// 预警级别
       /// </summary>
        public int EarlywarnLevle { set; get; }
       
       /// <summary>
        /// 固定检查内容：如系统版本，IE版本，冲突软件等
       /// </summary>
        public string MonitorValue { set; get; }
       
       /// <summary>
        /// 上限 -- 范围检查内容：如内存占用、CPU使用等 
       /// </summary>
        public string MonitorValue_Min { set; get; }
        	
       /// <summary>
        /// 下限
       /// </summary>
        public string MonitorValue_Max { set; get; }

    }
}
