using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Payment
{
    /// <summary>
    /// 银联支付日志信息类
    /// </summary>
    public class UnionPayLogInfo
    {
        /// <summary>
        /// 交易名称
        /// </summary>
        public string trans_name { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string trans_type { get; set; }

        /// <summary>
        /// 支付卡号
        /// </summary>
        public string pay_card_num { get; set; }

        /// <summary>
        /// 交易金额（元）
        /// </summary>
        public decimal trans_amount { get; set; }

        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime trans_time { get; set; }

        /// <summary>
        /// 银联交易参考号
        /// </summary>
        public string reference_num { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string trans_status { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string terminal_num { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string merchant_num { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string order_id { get; set; }

        /// <summary>
        /// 本地交易流水号
        /// </summary>
        public string running_num { get; set; }

        /// <summary>
        /// 转入卡号，适用于还款、转账。
        /// </summary>
        public string in_card_num { get; set; }

        /// <summary>
        /// 48域
        /// </summary>
        public string bit48 { get; set; }

    }
}