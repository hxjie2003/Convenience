using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaOrderSdk.Model
{

    public class CreateOrderResponse
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public CreateOrderOrderResult dataMap { get; set; }
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string respTime { get; set; }
    }

    public class CreateOrderOrderResult
    {
        public Dictionary<string,string> orderIds { get; set; }
        public string orderId { get; set; }
        public string memberId { get; set; }
    }
}

