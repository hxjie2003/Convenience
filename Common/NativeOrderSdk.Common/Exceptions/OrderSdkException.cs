using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeOrderSdk.Common.Exceptions
{
    public class OrderSdkException:Exception
    {
        public OrderSdkException(string code, string message)
            : base(message)
        {
            ErrorCode = code;         
        }

        public string ErrorCode { get; set; }
     
    }
}
