using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    public class InputRecharge:InputBase
    {
        /// <summary>
        /// 接收帐户名称
        /// </summary>
        public string payeeAccountName { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal amount { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string bankName { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string cardNo { get; set; }


        //****************确认订单******************

        /// <summary>
        /// 订单号
        /// </summary>
        public string orderID { get; set; }

        /// <summary>
        /// 银联流水单号
        /// </summary>
        public string txnNo { get; set; }

        ///// <summary>
        ///// 银行名称
        ///// </summary>
        //public string bankName { get; set; }
        ///// <summary>
        ///// 银行卡号
        ///// </summary>
        //public string cardNo { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string tradeStatus { get; set; }

        /// <summary>
        /// 结算日期
        /// </summary>
        public DateTime settleDate { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal settleAmount { get; set; }

        /// <summary>
        /// 结算状态
        /// </summary>
        public string settleStatus { get; set; }

    }
}