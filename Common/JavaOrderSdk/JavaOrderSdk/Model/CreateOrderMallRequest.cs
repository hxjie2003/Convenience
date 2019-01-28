using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaOrderSdk.Model
{
    public class CreateOrderMallRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public MallOrderInfos dataMap { get; set; }
    }


    public class MallOrderInfos
    {
        public MallOrderInfo[] orderList { get; set; }
        public string memberId { get; set; }
    }

    public class MallOrderInfo : OrderInfo
    {
        public CreateOrderMallOrderitemlist[] orderItemList { get; set; }
        public CreateOrderMallOrderdelivery orderDelivery { get; set; }
    }

    public class CreateOrderMallOrderdelivery
    {
        public string trueName { get; set; }
        public string locationPath { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string mobile { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
    }

    public class CreateOrderMallOrderitemlist
    {
        public string goodsId { get; set; }
        public string goodsName { get; set; }
        public string productId { get; set; }
        public string productName { get; set; }
        public string productPrice { get; set; }
        public string productQuantity { get; set; }
        public string productSn { get; set; }
        public string goodsImagePath { get; set; }
        public string goodsUrl { get; set; }
        public string fromType { get; set; }
        public string channType { get; set; }
        public string skuText { get; set; }
        public string remark { get; set; }
    }


}
