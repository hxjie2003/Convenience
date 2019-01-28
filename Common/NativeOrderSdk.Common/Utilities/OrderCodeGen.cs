using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeOrderSdk.Common.EntityModels;
using NativeOrderSdk.Common.Exceptions;

namespace NativeOrderSdk.Common.Utilities
{
    public class OrderCodeGen
    {
        public static string GetOrderGroupId()
        {
            ArchitectureContext context = new ArchitectureContext();
            string format = "SELECT F_GET_CODE('BM0022') as NewID   FROM DUAL";
            string commandstr = string.Format(format, "");
            var newidobj = context.Database.SqlQuery<IDResult>(commandstr).FirstOrDefault();
            if (newidobj == null)
                throw new OrderSdkException("400", "无法取得新的ID对象！数据库请求失败！");
            return newidobj.NewID;
        }

        internal static string GetOrderId()
        {
            ArchitectureContext context = new ArchitectureContext();
            string format = "SELECT F_GET_CODE('BM0015') as NewID   FROM DUAL";
            string commandstr = string.Format(format, "");
            var newidobj = context.Database.SqlQuery<IDResult>(commandstr).FirstOrDefault();
            if (newidobj == null)
                throw new OrderSdkException("400", "无法取得新的ID对象！数据库请求失败！");
            return newidobj.NewID;
        }
    }
}
