using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Persistence.Shop
{
    /// <summary>
    /// 商品基本信息集
    /// </summary>
    public class ProductListResult
    {
        /// <summary>
        /// 商品总记录数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 本页商品列表
        /// </summary>
        public List<ProductResult> Products { get; set; }

        public ProductListResult() 
        {
            this.Products = new List<ProductResult>();
            this.TotalCount = 0;
        }
    }

    /// <summary>
    /// 商品基本信息
    /// </summary>
    public class ProductResult
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 商城编号
        /// </summary>
        public string ShopId { get; set; }

        /// <summary>
        /// 类目ID
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// 商城ID，有时需要接口方提供的，像农民兄弟，分京东和易通商城
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// 商城名称，有时需要接口方提供的，像农民兄弟，分京东和易通商城
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public int TradeAmount { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 商品标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 链接地址(第三方)
        /// </summary>
        public string LinkUrl { get; set; }

        /// <summary>
        /// 单图片地址
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 大展示图片("^"号分隔)
        /// </summary>
        public string BigImgUrls { get; set; }

        /// <summary>
        /// 小展示图片("^"号分隔)
        /// </summary>
        public string SmallImgUrls { get; set; }

        /// <summary>
        /// 市场价(元,指的是第三方接口的市场价)
        /// </summary>
        public double MarketPrice { get; set; }

        /// <summary>
        /// 原价(元,指的是第三方接口的售价)
        /// </summary>
        public double OriginPrice { get; set; }

        /// <summary>
        /// 易通价(元)
        /// </summary>
        public double SalePrice { get; set; }

        /// <summary>
        /// 易通价范围(元)
        /// </summary>
        public string SalePriceRange { get; set; }

        /// <summary>
        /// 库存量
        /// </summary>
        public int StoreQty { get; set; }

        /// <summary>
        /// 商品属性
        /// </summary>
        public string SkuData { get; set; }

        /// <summary>
        /// 属性信息
        /// </summary>
        public string SkuText { get; set; }

        /// <summary>
        /// 产品详情
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public string VenderId { get; set; }

        /// <summary>
        /// 供应商信息
        /// </summary>
        public string VenderInfo { get; set; }

        /// <summary>
        /// 供应商评价
        /// </summary>
        public string VenderEvaluate { get; set; }

        /// <summary>
        /// 供应商连接地址
        /// </summary>
        public string VenderUrl { get; set; }

        /// <summary>
        /// 促销活动
        /// </summary>
        public string Promotion { get; set; }

        /// <summary>
        /// 赠送积分
        /// </summary>
        public string Integral { get; set; }

        /// <summary>
        /// 货运信息
        /// </summary>
        public string ShippingInfo { get; set; }

        /// <summary>
        /// 运费数据
        /// </summary>
        public string ShippingData { get; set; }

        /// <summary>
        /// 商品品牌
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKeyWord { get; set; }

        /// <summary>
        /// 原始json数据
        /// </summary>
        public string Json { get; set; }
    }
}
