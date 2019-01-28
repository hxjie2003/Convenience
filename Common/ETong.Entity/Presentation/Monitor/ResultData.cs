using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Monitor
{  
    /// <summary>
    /// 命令返回的数据
    /// </summary>
    [Serializable]
    public class ResultData
    {
        /// <summary>
        /// 数据产生时间
        /// </summary>
        public DateTime ResultTime { get; set; }

        /// <summary>
        /// 是否执行成功
        /// </summary>
        public bool IsSucceed { get; set; }

        /// <summary>
        /// Josn类型的数据
        /// </summary>
        public string JsonData { get; set; }

        /// <summary>
        /// 来源ID
        /// </summary>
        public string SourceId { get; set; }

        /// <summary>
        /// 命令类型
        /// </summary>
        public Operate CmdType { get; set; }
    }
}
