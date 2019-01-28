using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaOrderSdk.Model
{

    public class ConfirmOrderRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public FinishOrderInfo dataMap { get; set; }
    }
    public class FinishOrderInfo
    {
        public string orderId { get; set; }
        public string memberId { get; set; }
        public string providerId { get; set; }
    }
}
