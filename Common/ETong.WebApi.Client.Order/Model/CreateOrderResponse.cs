using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Model 
{

    
    public class CreateOrderOrderResult
    {
        public Dictionary<string,string> orderIds { get; set; }
        public string orderId { get; set; }
        public string memberId { get; set; }
    }
}

