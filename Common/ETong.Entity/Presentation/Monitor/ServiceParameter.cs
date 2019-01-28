using Newtonsoft.Json;

namespace ETong.Entity.Presentation.Monitor
{
    //[JsonObject(MemberSerialization.OptIn)]
    /// <summary>
    ///     服务参数
    /// </summary>
    public class ServiceParameter
    {
        /// <summary>
        ///     服务端1，客户端2,中转服务3
        /// </summary>
        public int SorC { set; get; }

        /// <summary>
        ///     ETM机编号
        /// </summary>
        public string ETMID { set; get; }

        /// <summary>
        ///     服务端编号
        /// </summary>
        public string SID { set; get; }

        /// <summary>
        ///     命令代码
        /// </summary>
        public string CommandCode { set; get; }

        /// <summary>
        ///     命令执行回调代码
        /// </summary>
        public string SessionId { set; get; }

        /// <summary>
        ///     ETM回调操作
        /// </summary>
        public int ETMAction { set; get; }

        /// <summary>
        ///     参数Josn内容:格式为 Dictionary<string, object>内容的Josn解析内容
        /// </summary>
        public string ParameterJosnValue { set; get; }

        /// <summary>
        ///     参数二进制内容：可用户存放大数据
        /// </summary>
        [JsonIgnore]
        public byte[] ParameterByteValue { set; get; }

        /// <summary>
        ///     操作类型:-2>退出。-1>读取在线ETM列表。0>服务端签到。1>发起命令。2>接受执行。3>返回执行结果。4>接收结果
        /// </summary>
        public int ActionType { set; get; }

        /// <summary>
        ///     服务调用结果
        /// </summary>
        public ServiceResult ResultValue { set; get; }
    }
}