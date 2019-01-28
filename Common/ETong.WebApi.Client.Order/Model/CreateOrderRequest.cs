﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Model 
{
    public class CreateOrderRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public CreateOrderDatamap dataMap { get; set; }
    }

    public class CreateOrderDatamap
    {
        public OrderInfo[] orderList { get; set; }
        public string memberId { get; set; }
    }

    public class OrderInfo
    {
        public string orderFrom { get; set; }
        public string orderType { get; set; }
        public string memberId { get; set; }
        public string memberName { get; set; }
        public string storeId { get; set; }
        public string storeName { get; set; }
        public string orderEtm { get; set; }
        public string orderAmount { get; set; }
        public string totalAmount { get; set; }
        public string message { get; set; }
        public string orderDescribe { get; set; }

        public decimal deleiveryFee { get; set; }

        public string orderProperties { get; set; }
    }

    public class orderPropertiesJson
    {
        public string CAR_NO { get; set; }
        public decimal T_FEE { get; set; }
        public decimal DEAL_FEE { get; set; }
        public int IS_ONLINE_PROCESSING { get; set; }

    }

}
