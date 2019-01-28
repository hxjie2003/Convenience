using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ETong.Order.Core.Repository.Models
{
    /// <summary>
    /// 订单基类
    /// </summary>
    public abstract class OrderItemInfo
    {    
        /// <summary>
        /// 订单来源：商城=0，ETM=1，进销存=2，B2C=3，APP=4（必填）
        /// </summary>
        public int OrderFrom { get; set; }
        /// <summary>
        /// 下单的ETMID,在手机端下单时可以为空。
        /// </summary>
        public string OrderETMID { get; set; }
        /// <summary>
        /// 单价（必填）
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 购买数量（必填）
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 订单总金额（必填）
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 创建IP
        /// </summary>
        public string CreateIP { get; set; }
    }

    public class OrderItemDetail : OrderItemInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单项描述
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }
        /// <summary>
        /// 发货状态
        /// </summary>
        public int ShippingStatus { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 是否为信用订单
        /// </summary>
        public int IsCredit { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public int PaymentStatus { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? PaymentTime { get; set; }
        /// <summary>
        /// 支付ETM
        /// </summary>
        public string PayETM { get; set; }
        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 物流编号
        /// </summary>
        public string DeliverySn { get; set; }
        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string DeliveryName { get; set; }
        /// <summary>
        /// 总成本
        /// </summary>
        public decimal TotalCost { get; set; }
        /// <summary>
        /// 分润标志
        /// </summary>
        public int AllocationStatus { get; set; }


    }
}
