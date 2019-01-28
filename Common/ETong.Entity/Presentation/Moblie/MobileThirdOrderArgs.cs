using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Moblie
{
    /// <summary>
    /// 第三方提交信息
    /// </summary>
    public class MobileThirdOrderArgs
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileNo { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

    }
}
