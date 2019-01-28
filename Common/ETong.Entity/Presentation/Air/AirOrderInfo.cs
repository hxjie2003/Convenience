using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 机票订单信息
    /// </summary>
    public class AirOrderInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 第三方订单ID
        /// </summary>
        public string ThrOrderId { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 支付日期
        /// </summary>
        public DateTime? PayDate { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        public int PayStatus { get; set; }

        /// <summary>
        /// 发货状态【合并的v3库没有发货状态了】
        /// </summary>
        public int ShippingStatus { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string Provider { get; set; }
    }
}
