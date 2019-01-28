using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Moblie
{
    /// <summary>
    /// 订单实体信息
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal totalAmout { get; set; }

        /// <summary>
        /// 充值的手机号码
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 订单的支付状态
        /// </summary>
        public int orderState { get; set; }

        /// <summary>
        /// 订单的提交日期
        /// </summary>
        public DateTime orderDate { get; set; }
    }
}
