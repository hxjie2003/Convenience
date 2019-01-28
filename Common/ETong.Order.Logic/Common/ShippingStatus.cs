using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Order.Logic.Common
{
    /// <summary>
    /// 发货状态
    /// </summary>
    public enum ShippingStatus
    {
        /// <summary>
        /// 未发货0
        /// </summary>
        NoShip=0,
        /// <summary>
        /// 部分发货1
        /// </summary>
        PartShipped=1,
        /// <summary>
        /// 已发货2
        /// </summary>
        Shipped=2       
    }
}
