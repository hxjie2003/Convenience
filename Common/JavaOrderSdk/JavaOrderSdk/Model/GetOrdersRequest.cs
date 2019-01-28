using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaOrderSdk.Model
{
    public class GetOrdersRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public GetOrdersCondition dataMap { get; set; }
    }

    public class GetOrdersCondition
    {
        public string curPage { get; set; }
        public string pageSize { get; set; }
        public string orderId { get; set; }
        public string orderStatus { get; set; }
        public string orderType { get; set; }
        public string createStartDate { get; set; }
        public string createEndDate { get; set; }
        public string productDesc { get; set; }
        public string memberId { get; set; }
    }

}



