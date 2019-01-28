using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Transfer
{
    /// <summary>
    /// 订单状态类
    /// </summary>
    public class OrderStatusInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 发货状态
        /// </summary>
        public int ShippingStatus { get; set; }

    }
}
