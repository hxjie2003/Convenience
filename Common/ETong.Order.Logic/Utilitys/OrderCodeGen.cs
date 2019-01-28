using ETong.Utility.Codegen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Order.Logic.Utilitys
{
    public class OrderCodeGen
    {
        public static string GetOrderGroupId()
        {
            return NewCodegen.GetNewID("ordergroupid");
        }

        public static string GetOrderId()
        {
            return NewCodegen.GetNewID("orderid");
        }
    }
}
