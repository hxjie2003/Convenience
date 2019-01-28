using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Model 
{
    
      public class CancelOrderRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public CancelOrderInfo dataMap { get; set; }
    }
      public class CancelOrderInfo
    {
        public string orderId { get; set; }
        public string memberId { get; set; }
    }
}
