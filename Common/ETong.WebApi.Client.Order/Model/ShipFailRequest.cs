using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.WebApi.Client.Order.Model
{
    public class ShipFailRequest
    {
        public string memberId { get; set; }
        public string orderId { get; set; }
        public string orderSubStatus { get; set; }
        public string failReason { get; set; }
    }

}
