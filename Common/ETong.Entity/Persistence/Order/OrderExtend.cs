using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Order
{
    /// <summary>
    /// 订单组相关订单信息
    /// </summary>
    public class OrderExtend
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public string ORDER_ID { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public int ORDER_TYPE { get; set; }

        /// <summary>
        /// 运费说明
        /// </summary>
        public string DELIVERYFEE { get; set; }

        /// <summary>
        /// 优惠说明
        /// </summary>
        public string PREFERENTIALAMOUNT { get; set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        public string CONTENT { get; set; }

        public string ExtCol02 { get; set; }
        public string ExtCol03 { get; set; }
    }
}
