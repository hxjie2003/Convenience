using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class ChannelGoodsDetailDatamap
    {
        public Goodsdetail goodsDetail { get; set; }
    }

    public class Goodsdetail
    {
        public string goodsId { get; set; }
        public string goodsName { get; set; }
        public string code { get; set; }
        public float salePrice { get; set; }
        public int isPinkage { get; set; }
        public float marketPrice { get; set; }
        public string etongPriceRange { get; set; }
        public int store { get; set; }
        public string describe { get; set; }
        public string freightTemplateId { get; set; }
        public string[] imgSmall { get; set; }
        public string imgBig { get; set; }
        public string goodsAttrbuteList { get; set; }
        public MarketAttributeList[] marketAttributeList { get; set; }
        public string storeName { get; set; }
        public string categoryName { get; set; }
        public string goodsFrom { get; set; }
        public string storeId { get; set; }
        public string categoryId { get; set; }
        public string fromId { get; set; }
        public string detailText { get; set; }
        public Skulist[] skulist { get; set; }
    }

    public class MarketAttributeList
    {
        public string name { get; set; }
        public string[] marketAttValueList { get; set; }
    }

    public class Skulist
    {
        public string skuImg { get; set; }
        public string productId { get; set; }
        public float unitQuatity { get; set; }
        public string describe { get; set; }
        public string sn { get; set; }
        public int storeNum { get; set; }
        public int saleNum { get; set; }
        public string productName { get; set; }
        public float productPrice { get; set; }
        public string productMarketAttr { get; set; }
        public string unitValue { get; set; }
    }

}
