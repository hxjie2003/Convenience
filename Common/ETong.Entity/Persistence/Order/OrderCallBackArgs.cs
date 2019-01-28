using System;
using ETong.Common.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Order
{
    public class OrderCallBackArgs
    {
        /// <summary>
        /// 订单号，多个订单号以逗号分开
        /// </summary>
        public string orderIds { get; set; }

        /// <summary>
        /// 回调类型
        /// </summary>
        public ETong.Common.Enum.Order.OrderCallbackType callBackType { get; set; }
    }
}
