using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.CreditCard
{
    /// <summary>
    /// 手续费参数
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

    }


    /// <summary>
    /// 输出的手续费
    /// </summary>
    public class FeeOuts
    {
        /// <summary>
        /// 手续费
        /// </summary>
        public string amount { get; set; }
    }

    
}
