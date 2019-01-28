using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Shop
{
    /// <summary>
    /// 商城订单扩展信息
    /// </summary>
    public class ShopOrderExtend
    {
        /// <summary>
        /// 支付方式名
        /// ExtCol05
        /// </summary>
        public string PaymentConfigName { get; set; }

        /// <summary>
        /// 收货日期类型
        /// ExtCol06
        /// </summary>
        public string ReceiverDateType { get; set; }

        /// <summary>
        /// 收货时间段开始时间
        /// ExtCol07
        /// </summary>
        public string ReceiverStarTime { get; set; }

        /// <summary>
        /// 收货时间段结束时间
        /// ExtCol08
        /// </summary>
        public string ReceiverEndTime { get; set; }

        /// <summary>
        /// 支付积分数
        /// ExtCol09
        /// </summary>
        public string CostIntegral { get; set; }

        /// <summary>
        /// 订单赠送积分
        /// ExtCol10
        /// </summary>
        public string TotalIntegral { get; set; }

        /// <summary>
        /// 区域ID
        /// ExtCol13
        /// </summary>
        public string AreaId { get; set; }

        /// <summary>
        /// 收货地址路径
        /// ExtCol27
        /// </summary>
        public string ShipAreaPath { get; set; }

        /// <summary>
        /// 收货人手机号
        /// ExtCol28
        /// </summary>
        public string ShipMobile { get; set; }

        /// <summary>
        /// 收货人姓名
        /// ExtCol30
        /// </summary>
        public string ShipName { get; set; }

        /// <summary>
        /// 收货人电话
        /// ExtCol31
        /// </summary>
        public string ShipPhone { get; set; }

        /// <summary>
        /// 收货人地址邮编
        /// ExtCol32
        /// </summary>
        public string ShipZipCode { get; set; }

        /// <summary>
        /// 订单优惠金额
        /// ExtCol14
        /// </summary>
        public string PreferentialAmount { get; set; }

        /// <summary>
        /// 配送费用承担者
        /// ExtCol15
        /// </summary>
        public string BearDeliveryFeeType { get; set; }

        /// <summary>
        /// 配送费用
        /// ExtCol01
        /// </summary>
        public string DeliveryFee { get; set; }

        /// <summary>
        /// 已付金额
        /// ExtCol04
        /// </summary>
        public string PaidAmount { get; set; }

        /// <summary>
        /// 银行支付名称
        /// ExtCol16
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 商品成本价格
        /// ExtCol17
        /// </summary>
        public string TotalProductCost { get; set; }

        /// <summary>
        /// 服务网点id
        /// ExtCol18
        /// </summary>
        public string ServiceBranchStoreId { get; set; }

        /// <summary>
        /// 配送网点id
        /// ExtCol19
        /// </summary>
        public string DeliveryBranchStoreId { get; set; }

        /// <summary>
        /// 是否缺货
        /// ExtCol20
        /// </summary>
        public string IsStockout { get; set; }

        /// <summary>
        /// 商品货号
        /// ExtCol22
        /// </summary>
        public string ProductSN { get; set; }

        /// <summary>
        /// 商品平台ID
        /// ExtCol33
        /// </summary>
        public string ShopId { get; set; }

        /// <summary>
        /// 商品平台名称
        /// ExtCol34
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 产品的链接地址
        /// EXTCOL35
        /// </summary>
        public string GoodsUrl { get; set; }

        /// <summary>
        /// JAVA商场商家ID
        /// EXTCOL36
        /// </summary>
        public string StoreId2 { get; set; }

        /// <summary>
        /// 订单扩展信息
        /// BIGCOL01
        /// </summary>
        public string OrderInfo { get; set; }

        /// <summary>
        /// 订单频道信息
        /// 暂不写入表
        /// </summary>
        public string ChannelType { get; set; }

        /// <summary>
        /// 订单附言
        /// EXTCOL37
        /// </summary>
        public string OrderRemark { get; set; }

    }
}
