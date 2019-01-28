//-----------------------------------------------------------------------
// <copyright file="HeaderResponsetInfo.cs" company="Etong">
//     Http head输出的头信息，在response中提供响应状态等
// </copyright>
//-----------------------------------------------------------------------

namespace ETong.WebApiUtility.Entity
{
    /// <summary>
    /// http输出的头实体
    /// </summary>
    public class HeaderResponsetInfo
    {
        /// <summary>
        /// Gets or sets API协议版本
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets 状态码
        /// </summary>
        public string ApiCode { get; set; }

        /// <summary>
        /// Gets or sets 消息文本
        /// </summary>
        public string ApiMessage { get; set; }
    }
}
