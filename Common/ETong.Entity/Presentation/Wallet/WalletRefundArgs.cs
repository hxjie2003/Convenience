using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 提交给java接口的退款参数类
    /// </summary>
    public class WalletRefundArgs
    {
        /// <summary>
        /// 支付订单号（非ETM订单号）
        /// </summary>
        public string orderID { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        public string refundRemark { get; set; }

        /// <summary>
        /// 退款金额（元）
        /// </summary>
        public decimal amount { get; set; }

        

    }
}