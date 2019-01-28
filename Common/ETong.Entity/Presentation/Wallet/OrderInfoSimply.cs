using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 简要订单信息
    /// </summary>
    public class OrderInfoSimply
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string ProviderCode { get; set; }
    }
}
