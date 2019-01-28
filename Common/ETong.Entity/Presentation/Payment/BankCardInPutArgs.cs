using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Payment
{
    public class BankCardInPutArgs
    {
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 还款金额
        /// </summary>
        public decimal RePayAmount { get; set; }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 回调
        /// </summary>
        public string Callback { get; set; }

        /// <summary>
        /// 是否需要验证
        /// </summary>
        public bool? IsNeedValidate { get; set; }
    }
}
