using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Moblie
{
    /// <summary>
    /// 运费的请求参数
    /// </summary>
    public class FeeArgs
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
}
