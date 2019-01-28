using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor 
{
    /// <summary>
    /// 监控作业计划
    /// </summary>
    [Serializable]
   public class MonitorWorkPlan
    { 
        /// <summary>
        /// 作业Id
        /// </summary>
        public string Work_Id { set; get; }
   	
        /// <summary>
        /// 计划Id
        /// </summary>
        public string Work_Plan_Id { set; get; }
  
        /// <summary>
        /// 计划名称
        /// </summary>
        public string Work_Plan_Name { set; get; }
     
        /// <summary>
        /// 启用状态(0:未启用，1：已启用)
        /// </summary>
        public int Work_Plan_Start { set; get; }
     
        /// <summary>
        /// 计划类型（0：重复，1：执行一次）
        /// </summary>
        public int Work_Plan_Type { set; get; }
        
        /// <summary>
        /// 执行一次的执行时间
        /// </summary>
        public string OneTime { set; get; }
      
        /// <summary>
        /// 执行频率：0每天，1每周，2每月
        /// </summary>
        public string RunFrequencyType { set; get; }
   
        /// <summary>
        /// 执行间隔（若按天为天数，若按周为周数，以此类推）默认为1
        /// </summary>
        public string RunIntervalNum { set; get; }
        
        /// <summary>
        /// 按月执行间隔时，第几个星期，默认为1（-1为最后一个星期，1：第一周，2：第二周 以此类推）
        /// </summary>
        public string RunMonthWeek { set; get; }
      
        /// <summary>
        /// 指定星期几执行，默认为星期1
        /// </summary>
        public string RunWeekday { set; get; }
     
        /// <summary>
        /// 指定当月的第几天执行，默认为第1天
        /// </summary>
        public string RunMonthDay { set; get; }
         
        /// <summary>
        /// 每天的执行频率--0:执行一次，1：按间隔执行，默认为0
        /// </summary>
        public string DayRunFrequencyType { set; get; }
       	
        /// <summary>
        /// 每天的执行频率--执行一次的时间，默认为00：00：00
        /// </summary>
        public string DayRunTime { set; get; }
        
        /// <summary>
        /// 每天的执行频率--执行间隔时间
        /// </summary>
        public string DayRunIntervalNum { set; get; }
        
        /// <summary>
        /// 每天的执行频率--执行间隔时间类型（0：小时，1：分钟，2：秒）
        /// </summary>
        public string DayRunIntervalType { set; get; }
      	
        /// <summary>
        /// 每天的执行频率--执行开始时间
        /// </summary>
        public string DayStartTime { set; get; }
    
        /// <summary>
        /// 每天的执行频率--执行结束时间
        /// </summary>
        public string DayEndTime { set; get; }
       
        /// <summary>
        /// 持续时间-开始
        /// </summary>
        public string StartDate { set; get; }
       
        /// <summary>
        /// 持续时间-结束
        /// </summary>
        public string EndDate { set; get; }

    }
}
