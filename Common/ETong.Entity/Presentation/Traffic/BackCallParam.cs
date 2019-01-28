using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Traffic
{
    /// <summary>
    /// 回调参数
    /// </summary>
    public class BackCallParam
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderId { get; set; }
        /// <summary>
        /// 调用类型
        /// </summary>
        public int callType { get; set; }
    }
}
