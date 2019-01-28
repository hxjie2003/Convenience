using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Moblie
{
    /// <summary>
    /// 设置写明细备注的参数
    /// </summary>
    public class RemarksArgs
    {
        /// <summary>
        /// 第三方单号
        /// </summary>
        public string ThirdOrderId { get; set; }

        /// <summary>
        /// 本地订单单号
        /// </summary>
        public string OrderId { get; set; }
    }
}
