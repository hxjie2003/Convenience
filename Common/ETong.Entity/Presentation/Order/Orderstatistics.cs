using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Order
{
    /// <summary>
    /// 订单数量统计
    /// </summary>
    public class OrderStatistics
    {
        /// <summary>
        /// 已完成订单数量
        /// </summary>
        public int FinishedOrderCount { get; set; }
        /// <summary>
        /// 待支付订单数量
        /// </summary>
        public int TobePayOrderCount { get; set; }
    }
}
