// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AirResponse.cs" company="ETong">
//   第三方接口返回的类型
// </copyright>
// <summary>
//   第三方接口返回类型
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 第三方接口返回类型
    /// </summary>
    public class AirResponse
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 响应文本
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 返回的业务参数
        /// </summary>
        public object data { get; set; }
    }
}
