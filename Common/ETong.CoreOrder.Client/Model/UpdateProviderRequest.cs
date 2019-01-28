using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Model 
{

    public class UpdateProvierRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public SendSupplierBody dataMap { get; set; }
    }

    public class SendSupplierBody
    {
        public string orderId { get; set; }
        public string memberId { get; set; }
        public string providerId { get; set; }
    }

}
