using System;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// 命令参数
    /// </summary>
    [Serializable]
    public class OperateArgs
    {
        /// <summary>
        /// 来源ID
        /// </summary>
        public string SourceId { get; set; }

        /// <summary>
        /// 命令类型
        /// </summary>
        public Operate OperateType { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string JsonParams { get; set; }

        /// <summary>
        /// 返回标题
        /// </summary>
        public string ReturnTopic { get; set; }

    }
}
