using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaOrderSdk.Model
{
    
    public class RefundOrderRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public RefundOrderInfo dataMap { get; set; }
        
    }

    public class RefundOrderInfo
    {
        public string orderId { get; set; }
        public RefundOrderParam param { get; set; } 
    }
    public class RefundOrderParam
    {
        public string param { get; set; }
    }
}
