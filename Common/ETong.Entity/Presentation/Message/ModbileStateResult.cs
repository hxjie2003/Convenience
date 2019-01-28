using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Message
{
    public class ModbileStateResult
    {
        /// <summary>
        /// 是否可充值
        /// </summary>
        public bool CanRecharged { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 运营商
        /// </summary>
        public string CompanyName { get; set; }
    }
}
