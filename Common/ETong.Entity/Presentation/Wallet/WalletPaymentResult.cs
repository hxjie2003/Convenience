using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// java接口返回的支付结果类
    /// </summary>
    public class WalletPaymentResult
    {
        /// <summary>
        /// 消费记录批次号
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 交易金额（元）
        /// </summary>
        public decimal TotalTradeAmount { get; set; }

        /// <summary>
        /// 支付结果明细记录
        /// </summary>
        public IList<WalletPaymentRecord> Details { get; set; }
    }

    /// <summary>
    /// java接口返回的支付结果明细记录类
    /// </summary>
    public class WalletPaymentRecord
    {
        /// <summary>
        /// 消费记录订单号
        /// </summary>
        public string RecordId { get; set; }

        /// <summary>
        /// 交易金额（元）
        /// </summary>
        public decimal TradeAmount { get; set; }

    }

}