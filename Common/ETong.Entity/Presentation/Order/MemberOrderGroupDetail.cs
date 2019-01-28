using ETong.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Order
{

    /// <summary>
    /// 会员订单组明细
    /// </summary>
    public class MemberOrderGroupDetail
    {
        /// <summary>
        /// 组ID
        /// </summary>
        public string GroupID { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string StoreId { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string DeliveryAdress { get; set; }
        /// <summary>
        /// 收件人名称
        /// </summary>

        public string DeliveryPersonName { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public string DeliveryFee { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 收件人电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public PayStatus PayStatus { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusName { get; set; }
        /// <summary>
        /// 配送状态
        /// </summary>
        public ShippingStatus ShippingStatus { get; set; }
        public string ShippingStatusName { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public int PaymentStatus { get; set; }
        public string PaymentStatusName { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderTimeExpress
        {
            get { return this.OrderTime.ToString("yyyy-MM-dd HH:mm"); }
        }
        /// <summary>
        /// 订单明细列表
        /// </summary>
        public List<MemberOrderItem> Items { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string GoodsCategorySet { get; set; }
        /// <summary>
        /// 总共运费
        /// </summary>
        public decimal TotalDeliveryFee { get; set; }
        /// <summary>
        /// 订单详情Url
        /// </summary>
        public string OrderDetailUrl { get; set; }

        #region 主要用于违章代缴
        /// <summary>
        /// 罚金（Add by zyg 主要用于违章代缴）
        /// </summary>
        //public decimal OrderAmount { get; set; }

        /// <summary>
        /// 总手续费（用于会员中心-我的订单手续费）
        /// </summary>
        public decimal TotalPoundage { get; set; }

        #endregion
    }

    /// <summary>
    /// 会员订单明细
    /// </summary>
    public class MemberOrderItem
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 产品概述
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 收货区
        /// </summary>
        public string ShipRegion { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string ShipName { get; set; }

        /// <summary>
        /// 收货人手机号码
        /// </summary>
        public string ShipMobile { get; set; }

        /// <summary>
        /// 收货人邮政编号
        /// </summary>
        public string ShipZip { get; set; }

        /// <summary>
        /// 收货人省份
        /// </summary>
        public string ShipProvinces { get; set; }

        /// <summary>
        /// 收货人城市
        /// </summary>
        public string ShipCity { get; set; }

        /// <summary>
        /// 收货人具体地址
        /// </summary>
        public string ShipAddress { get; set; }

        /// <summary>
        /// 商店名称
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 实际支付金额
        /// </summary>
        public string PaidAmount { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public string DeliverFee { get; set; }

        public int OrderStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ShippingStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PaymentStatus { get; set; }

        /// <summary>
        /// 罚金（Add by zyg 主要用于违章代缴）
        /// </summary>
        //public decimal OrderAmount { get; set; }
    }
}
