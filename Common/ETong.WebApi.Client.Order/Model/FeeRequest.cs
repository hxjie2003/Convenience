using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.WebApi.Client.Order.Model
{

    public class FeeRequest
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public string version { get; set; }
        public string reqFrom { get; set; }
        public FeeRequestDatamap dataMap { get; set; }
    }

    public class FeeRequestDatamap
    {
        public string orderType { get; set; }
        public string providerCode { get; set; }
        public string amount { get; set; }

        public string memberId { get; set; }
    }


}

