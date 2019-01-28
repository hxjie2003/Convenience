using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    /// <summary>
    /// webapi输入参数提现类
    /// </summary>
    public class InputWithdraw : InputBase
    {
        /// <summary>
        /// 提现金额（元）
        /// </summary>
        public decimal WithdrawAmount { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNo { get; set; }

        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPassword { get; set; }

        /// <summary>
        /// 银行账户名
        /// </summary>
        public string BankAccountName { get; set; }

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