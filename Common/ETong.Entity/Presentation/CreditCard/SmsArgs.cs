using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.CreditCard
{
    /// <summary>
    /// 发送短信的参数
    /// </summary>
    public class SmsArgs
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreaDate { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MobileNo { get; set; }
    }
}
