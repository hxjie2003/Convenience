using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Model 
{

    public class CancelOrderResponse
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public CancelOrderDatamap dataMap { get; set; }
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string respTime { get; set; }
    }

    public class CancelOrderDatamap
    {
        public CancelOrderResult result { get; set; }
        public string memberId { get; set; }
    }

    public class CancelOrderResult
    {
        public bool success { get; set; }
        public object[] error { get; set; }
        public object[] ecode { get; set; }
        public object models { get; set; }
        public string model { get; set; }
        public string exception { get; set; }
    }
}
