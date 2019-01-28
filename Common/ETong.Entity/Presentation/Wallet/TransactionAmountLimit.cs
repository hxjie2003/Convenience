using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 交易金额限额信息
    /// </summary>
    public class TransactionAmountLimit
    {
        /// <summary>
        /// 单笔最低限额
        /// </summary>
        public decimal LimitAmountLow { get; set; }

        /// <summary>
        /// 单笔最高限额
        /// </summary>
        public decimal LimitAmountHigh { get; set; }

        /// <summary>
        /// 当天最高限额
        /// </summary>
        public decimal LimitAmountDay { get; set; }

        /// <summary>
        /// 当月最高限额
        /// </summary>
        public decimal LimitAmountMonth { get; set; }

    }
}