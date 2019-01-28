using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor 
{

    /// <summary>
    /// 监控作业步骤
    /// </summary>
    [Serializable]
    public class MonitorWorkStep
    { 
        public string Work_Id { set; get; }
        public string Work_Steps_Id { set; get; }

        /// <summary>
        /// 作业步骤名称
        /// </summary>
        public string Work_Steps_Name { set; get; }

        /// <summary>
        /// 执行顺序
        /// </summary>
        public int IDX { set; get; }

        /// <summary>
        /// 命令代码（命令插件代码、监控命令代码） 
        /// </summary>
        public string CommanCode { set; get; }

        /// <summary>
        /// 执行命令参数
        /// </summary>
        public string Parameter{set;get;}
    

    }
}
