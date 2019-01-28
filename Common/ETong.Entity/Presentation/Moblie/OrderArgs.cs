using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Moblie
{
    /// <summary>
    /// 订单查询参数
    /// </summary>
    public class OrderArgs
    {
        /// <summary>
        /// 订单单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public string ProviderId { get; set; }
    }
}
