using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.PhoneBroadband
{
    /// <summary>
    /// 易通手续费请求类
    /// </summary>
    public class FeeReq
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public string orderType { get; set; }

        /// <summary>
        /// 通道编号
        /// </summary>
        public string providerCode { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string amount { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string memberId { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string reqFrom { get; set; }
    }

    /// <summary>
    /// 易通手续费响应类
    /// </summary>
    public class FeeRes
    {
        /// <summary>
        /// 手续费
        /// </summary>
        public string amount { get; set; }
    }

}
