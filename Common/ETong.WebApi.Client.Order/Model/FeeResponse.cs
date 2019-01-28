using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.WebApi.Client.Order.Model
{
    public class FeeResponse
    {
        public object sign { get; set; }
        public string reqTime { get; set; }
        public FeeResponseDatamap dataMap { get; set; }
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string respTime { get; set; }
    }

    public class FeeResponseDatamap
    {
        public string amount { get; set; }
    }


}
