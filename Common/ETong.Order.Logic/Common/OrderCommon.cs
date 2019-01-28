using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ETong.Order.Logic.Common
{
    /// <summary>
    /// 公共订单
    /// </summary>
    [KnownType(typeof(OrderCommonFull))]
    public class OrderCommon
    {
        private OrderDeliveryInfo _deliveryInfo;
        private OrderProductInfo _productInfo;
        private OrderStoreInfo _storeInfo;

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 商品信息。非空
        /// </summary>
        public OrderProductInfo ProductInfo
        {
            get { return _productInfo ?? (_productInfo = new OrderProductInfo()); }
            set { _productInfo = value; }
        }

        /// <summary>
        /// 发货信息。可空
        /// </summary>
        public OrderDeliveryInfo DeliveryInfo
        {
            get { return _deliveryInfo??(_deliveryInfo=new OrderDeliveryInfo()); }
            set { _deliveryInfo = value; }
        }

        /// <summary>
        /// 店铺信息。非空
        /// </summary>
        public OrderStoreInfo StoreInfo
        {
            get { return _storeInfo??(_storeInfo=new OrderStoreInfo()); }
            set { _storeInfo = value; }
        }

        /// <summary>
        /// 订单来源：商城=0，ETM=1，进销存=2，B2C=3，APP=4
        /// </summary>
        public int OrderFrom { get; set; }
        /// <summary>
        /// 订单来源描述
        /// </summary>
        public string OrderFromString { get; set; }
        /// <summary>
        /// 订单状态描述
        /// </summary>
        public string OrderStatusString { get; set; }
        /// <summary>
        /// 下单的ETMID,在手机端下单时可以为空。
        /// </summary>
        public string OrderETMID { get; set; } 
        /// <summary>
        /// 订单分类：一般订单=0，组合套餐=1，团购=2，促销=3
        /// </summary>
        public int OrderClassify { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity{ get; set; }
        /// <summary>
        /// 订单总金额
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
        public string  CreateIP { get; set; }
    }

    public class OrderCommonFull:OrderCommon
    {

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
