using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Model 
{
    public class GetOrderRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public GetOrderCondition dataMap { get; set; }
    }
    public class GetOrderCondition
    {
        public string orderId { get; set; }
        public string memberId { get; set; }
    }

}
