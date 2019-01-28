using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETong.Entity;

namespace ETong.Order.Logic
{
    public abstract class OrderException : ErrorCodeException
    {
        public OrderException(string code,string message, Exception innerException)
            : base(code, message, innerException)
        {

        }

        public OrderException(string code,string message)
            : base(code,message)
        {
         
        }

        public string AppId
        {
            get { return "DataFlow_Order"; }
        }

    }
}
