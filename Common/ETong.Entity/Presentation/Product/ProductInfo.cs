using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Product
{
    /// <summary>
    /// 货品信息
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品类别id
        /// </summary>
        public string GoodsCategoryId { get; set; }

        /// <summary>
        /// 货品id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商家id
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        public string StoreName { get; set; }

    }
}
