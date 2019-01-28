using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    /// <summary>
    /// webapi输入银行卡类
    /// </summary>
    public class InputBankCard : InputBase
    {
        /// <summary>
        /// 银行账户名
        /// </summary>
        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNo { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 银行卡类型
        /// </summary>
        public int BankCardType { get; set; }

        /// <summary>
        /// 绑定记录id
        /// </summary>
        public string BankCardBoundId { get; set; }

        /// <summary>
        /// 开户行省份名
        /// </summary>
        public string BankProvinceName { get; set; }

        /// <summary>
        /// 开户行城市名
        /// </summary>
        public string BankCityName { get; set; }
        
    }
}