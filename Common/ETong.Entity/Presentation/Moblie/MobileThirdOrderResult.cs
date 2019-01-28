using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Moblie
{
    /// <summary>
    /// 提交第三方手机订单的结果
    /// </summary>
    public class MobileThirdOrderResult
    {
        /// <summary>
        /// 成功状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
    }
}
