using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Order.Logic.Common
{
    /// <summary>
    /// 产品信息
    /// </summary>
    public class OrderProductInfo
    {
        public OrderProductInfo()
        {
 
        }

        public OrderProductInfo(string productname, int itemtype, decimal price)
        {
            this.ProductName = productname;
            this.ItemType = itemtype;
            this.ProductPrice = price;
            this.GoodsName = productname;
        }   
        /// <summary>
        /// 实体商品标志：实体商品=1，虚拟商品=0
        /// </summary>
        public int ItemType { get; set; }
        /// <summary>
        ///产品Sku的ID号
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 产品名称。必填项
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal ProductPrice { get; set; }
        /// <summary>
        /// 产品图片路径
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public string ProductDescription { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsID { get; set; }
        /// <summary>
        /// 商品名称。必填项
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品类目ID
        /// </summary>
        public string GoodsCategroySetID { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandName { get; set; }

       


    }
}
