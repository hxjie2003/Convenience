// <copyright file="BudgetInfo" company="ETong">
//     Copyright (c) ETong. All rights reserved.
// </copyright>
// <author>杨志泳</author>

using System.Collections.Generic;
using System.ComponentModel;

namespace ETong.Entity.Framework
{
    /// <summary>
    /// 收支记录
    /// </summary>
    public class BudgetInfo
    {
        /// <summary>
        /// 钱包ID，可为空
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 是否为收入
        /// </summary>
        [DefaultValue(false)]
        public bool IsIncome { get; set; }

        /// <summary>
        ///交易分类(0：购物付款，1：购物退款，2：平台内转账，3：账号提现，4：信用卡还款，5：银行卡转账,6:交易清算,7:钱包充值)
        /// </summary>
        [DefaultValue(7)]
        public int TradeType { get; set; }

        /// <summary>
        /// 支付渠道编码(0：电子货币,1：中国人民银行，2：中国工商银行,3:中国建设银行，4：中国农业银行，……)
        /// </summary>
        public string ChannelNo { get; set; }

        /// <summary>
        /// 支付类型（0:电子钱包,1：借记卡，2：信用卡，3预付卡，……）
        /// </summary>
        public int PaymentType { get; set; }

        /// <summary>
        /// 收款(付款)账户名(开户名)
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 账号/卡号
        /// </summary>
        public string AccountNo { get; set; }

        /// <summary>
        /// 关联订单号(银行流水号)
        /// </summary>
        public string BankOrderId { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// ETM编号
        /// </summary>
        public string ETMCode { get; set; }

        /// <summary>
        /// 支付金额(元)
        /// </summary>
        public decimal PayAmount { get; set; }

        /// <summary>
        /// 订单组或订单ID
        /// </summary>
        public List<string> OrderIds { get; set; }

        public BudgetInfo()
        {
            OrderIds = new List<string>();
        }
    }
}