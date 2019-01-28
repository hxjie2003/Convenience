using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// 命令执行结果
    /// </summary>
    [Serializable]
   public class CommandResultData
    {
       /// <summary>
       /// 命令编号
       /// </summary>
        public string CommandCode { set; get; }

       /// <summary>
        /// 命令执行状态(1:成功，-1：失败)
       /// </summary>
        public int ExecuteState { set; get; }

       /// <summary>
       /// 命令执行返回信息
       /// </summary>
        public string Message { set; get; }

       /// <summary>
        /// 命令执行结果数据(以Json格式转换对象)
       /// </summary>
        public string Value { set; get; }

        /// <summary>
        /// 命令执行结果数据(以Json格式转换对象)
        /// </summary>
        public byte[] Bytes { set; get; }
    }
}
