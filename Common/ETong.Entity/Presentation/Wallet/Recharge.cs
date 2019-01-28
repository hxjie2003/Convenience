using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 充值
    /// </summary>
    public class Recharge
    {
        /// <summary>
        /// 充值定单号
        /// </summary>
        public string orderID { get; set; }

        /// <summary>
        /// 到帐时间
        /// </summary>
        public DateTime accountingDate { get; set; }
    }
}