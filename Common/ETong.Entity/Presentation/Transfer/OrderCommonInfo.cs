using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Transfer
{
    /// <summary>
    /// 订单公共信息
    /// </summary>
    public class OrderCommonInfo
    {
        /// <summary>
        /// 会员id
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 实体商品标志：实体商品=1，虚拟商品=0
        /// </summary>
        public int ItemType { get; set; }

        /// <summary>
        /// 订单类型：商城订单=0，彩票订单=1，机票订单=2，报刊订单=3，充值订单=4... 转账=15
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 商品分类ID
        /// </summary>
        public string GoodsCategoryId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品明细id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 商品明细名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// 商品总数
        /// </summary>
        public int ProductQty { get; set; }

        /// <summary>
        /// 商品图片URl
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 商品规格描述
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// 订单分类：一般订单=0，组合套餐=1，团购=2，促销=3
        /// </summary>
        public int OrderClassify { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 下订单时的ETM编号
        /// </summary>
        public string OrderETM { get; set; }

        /// <summary>
        /// 下订单时的ETM IP
        /// </summary>
        public string OrderIp { get; set; }

        /// <summary>
        /// 收货省
        /// </summary>
        public string ShipProvince { get; set; }

        /// <summary>
        /// 收货市
        /// </summary>
        public string ShipCity { get; set; }

        /// <summary>
        /// 收货区
        /// </summary>
        public string ShipRegion { get; set; }

        /// <summary>
        /// 收货详细地址
        /// </summary>
        public string ShipAddress { get; set; }

        /// <summary>
        /// 配送方式ID
        /// </summary>
        public string DeliveryTypeId { get; set; }

        /// <summary>
        /// 配送方式名称
        /// </summary>
        public string DeliveryTypeName { get; set; }

    }
}
