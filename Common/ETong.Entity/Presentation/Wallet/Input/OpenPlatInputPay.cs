using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    /// <summary>
    /// webapi输入参数-支付类
    /// </summary>
    public class OpenPlatInputPay : InputBase
    {
        /// <summary>
        /// 订单号集合，多个订单号时以英文逗号分隔
        /// </summary>
        public string OrderIds { get; set; }

        /// <summary>
        /// 支付金额（元）
        /// </summary>
        public decimal PayAmount { get; set; }

        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPassword { get; set; }


        /// <summary>
        /// 钱包支付参考号
        /// </summary>
        public string PayReferenceNo { get; set; }

        /// <summary>
        /// 钱包退款原因说明
        /// </summary>
        public string RefundRemark { get; set; }


        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 支付卡号
        /// </summary>
        public string BankCardNo { get; set; }

        /// <summary>
        /// 银行支付参考号
        /// </summary>
        public string BankReferenceNo { get; set; }

    }
}