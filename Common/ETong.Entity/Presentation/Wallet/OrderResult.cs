using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 提交订单返回结果类
    /// </summary>
    public class OrderResult
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 到账时间
        /// </summary>
        public string AccountingDate { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string ProviderCode { get; set; }
    }
}