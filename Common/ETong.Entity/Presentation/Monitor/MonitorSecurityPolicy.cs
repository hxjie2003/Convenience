using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// 安全策略
    /// </summary>
    [Serializable]
    public class MonitorSecurityPolicy
    { 
        /// <summary>
        /// 安全策略Id
        /// </summary>
        public string SecurityPolicy_Id { set; get; }
    
        /// <summary>
        /// 安全策略名称
        /// </summary>
        public string SecurityPolicy_Name { set; get; }
       
        /// <summary>
        /// 启用状态(0:未启用，1：已启用)
        /// </summary>
        public int SecurityPolicy_state { set; get; }

        /// <summary>
        /// 安全策略相关的命令列表
        /// </summary>
        public List<MonitorSecurityPolicyItem> Items { set; get; }
    }
}
