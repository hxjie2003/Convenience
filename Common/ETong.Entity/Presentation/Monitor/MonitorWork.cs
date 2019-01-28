using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor 
{
    /// <summary>
    /// 监控作业
    /// </summary>
    [Serializable] 
   public class MonitorWork
    {
        public string Work_Id { set; get; }

        /// <summary>
        /// 作业名称
        /// </summary>
        public string Work_Name { set; get; }

        /// <summary>
        /// 0:未启动，1：已启动
        /// </summary>
        public int Work_state { set; get; }

        /// <summary>
        /// 作业类型（0：顺序执行，1：同步执行） 
        /// </summary>
        public int Work_Type { set; get; }

        /// <summary>
        /// 作业计划
        /// </summary>
        public List<ETong.Entity.Presentation.Monitor.MonitorWorkPlan> Plans { set; get; }

        /// <summary>
        /// 作业步骤
        /// </summary>
        public List<ETong.Entity.Presentation.Monitor.MonitorWorkStep> Steps { set; get; }
    }
}
