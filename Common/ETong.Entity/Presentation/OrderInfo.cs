using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation
{
    /// <summary>
    /// 订单主要信息，主要供在调用支付的时候返回信息
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// 订单总价格
        /// </summary>
        public decimal totalAmount { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string orderType { get; set; }
    }
}
