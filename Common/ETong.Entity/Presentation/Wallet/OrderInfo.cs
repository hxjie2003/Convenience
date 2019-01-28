using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单组编号
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 订单状态：待处理=0,已通过审核=1 ,未通过审核=20,等待备货=4,等待买家确认收货=5 ,
        /// 交易关闭=10（系统自动），客户作废=11,客户拒收=12,异常订单=13, 无人签收=3, 
        /// 客户拒收=12, 已签收=2, 已完成=9, 订单作废=18, 处理中=19
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 支付状态：未支付=0，部分支付=1，已支付=2，部分退款=3，全额退款=4，联合支付=5，无需支付=6
        /// </summary>
        public int PaymentStatus { get; set; }

        /// <summary>
        /// 货品id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 运费（商城订单才有运费）
        /// </summary>
        public decimal DeliveryFee { get; set; }
    }
}
