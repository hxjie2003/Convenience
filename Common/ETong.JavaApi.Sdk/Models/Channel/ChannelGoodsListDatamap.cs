using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class ChannelGoodsListDatamap
    {
        public Goodslist[] goodsList { get; set; }
        public Page page { get; set; }
    }

    public class Page
    {
        public int pageSize { get; set; }
        public int curPage { get; set; }
        public int itemNum { get; set; }
        public int startRow { get; set; }
        public int totalPage { get; set; }
        public int endRow { get; set; }
        public bool nextPage { get; set; }
        public bool prePage { get; set; }
    }

    public class Goodslist
    {
        public string goodsId { get; set; }
        public string otherGoodsId { get; set; }
        public string name { get; set; }
        public string subhead { get; set; }
        public string code { get; set; }
        public string brandName { get; set; }
        public string storeId { get; set; }
        public string storeName { get; set; }
        public string channelId { get; set; }
        public string categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryVO { get; set; }
        public string attribute { get; set; }
        public int storeNum { get; set; }
        public int saleNum { get; set; }
        public int isDisplayMain { get; set; }
        public int isPinkage { get; set; }
        public int mainSortNum { get; set; }
        public int sortNum { get; set; }
        public float marketPrice { get; set; }
        public float otherPrice { get; set; }
        public float etongPrice { get; set; }
        public string etongPriceRange { get; set; }
        public int isPutaway { get; set; }
        public string detailText { get; set; }
        public string freightTemplateId { get; set; }
        public string fromId { get; set; }
        public string imgBig { get; set; }
        public string imgSmall { get; set; }
        public int needInvoice { get; set; }
        public int isRepair { get; set; }
        public int isShowPc { get; set; }
        public int isShowEtm { get; set; }
        public int isShowApp { get; set; }
        public int isDelete { get; set; }
        public long createDate { get; set; }
        public string creator { get; set; }
        public long modifyDate { get; set; }
        public string modifyor { get; set; }
        public string fromName { get; set; }
        public string fromCode { get; set; }
        public string productId { get; set; }
        public string skuText { get; set; }
        public string skuPrice { get; set; }
        public string skuImg { get; set; }
        public int isAdd { get; set; }
        public string productStock { get; set; }
        public string marketeAttributeList { get; set; }
        public string marketAttributeKeys { get; set; }
        public string marketeAttribute { get; set; }
        public string currentAttribute { get; set; }
        public string remark { get; set; }
        public object[] otherProductList { get; set; }
        public string oneImg { get; set; }
        public Hashtable attributeMap { get; set; }
        public string[] attributeKeys { get; set; }
        public string[] imagePaths { get; set; }
    }

}
