using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 提交给java接口的支付参数类
    /// </summary>
    public class WalletPaymentArgs
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 订单描述
        /// </summary>
        public string orderDesc { get; set; }

        /// <summary>
        /// 交易金额（元）
        /// </summary>
        public string tradeAmount { get; set; }

        /// <summary>
        /// 交易代码
        /// </summary>
        public string tradeCode { get; set; }

        /// <summary>
        /// 交易对方名称
        /// </summary>
        public string tradeName { get; set; }

        /// <summary>
        /// 成功回调地址
        /// </summary>
        public string successUrl { get; set; }

        /// <summary>
        /// 失败回调地址
        /// </summary>
        public string failureUrl { get; set; }

        /// <summary>
        /// 返回地址
        /// </summary>
        public string backUrl { get; set; }

        /// <summary>
        /// 商品详细地址
        /// </summary>
        public string detailUrl { get; set; }

        /// <summary>
        /// 支付银行账号
        /// </summary>
        public string payBankAccount { get; set; }

        /// <summary>
        /// 支付银行名称
        /// </summary>
        public string payBankName { get; set; }

        /// <summary>
        /// 银联支付参考号
        /// </summary>
        public string queryId { get; set; }

    }
}