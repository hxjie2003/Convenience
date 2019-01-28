using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    /// <summary>
    /// webapi输入参数基类
    /// </summary>
    public class InputBase
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// etm id
        /// </summary>
        public string EtmCode { get; set; }

        /// <summary>
        /// 请求时间（用于校验用）
        /// </summary>
        public DateTime RequestTime { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

    }
}