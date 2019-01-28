using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    /// <summary>
    /// webapi输入参数-转账类
    /// </summary>
    public class InputTransfer : InputBase
    {
        /// <summary>
        /// 钱包接收帐户名称
        /// </summary>
        public string WalletAccountName { get; set; }

        /// <summary>
        /// 钱包接收人姓名
        /// </summary>
        public string AccountRealName { get; set; }

        /// <summary>
        /// 转账金额（元）
        /// </summary>
        public decimal TransferAmount { get; set; }

        /// <summary>
        /// 支付密码
        /// </summary>
        public string PayPassword { get; set; }

        /// <summary>
        /// 收款人手机号
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// 转账说明
        /// </summary>
        public string TransferRemark { get; set; }

        /// <summary>
        /// 银行账户户名
        /// </summary>
        public string PayeeRealName { get; set; }

        /// <summary>
        /// 转入银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 转入银行卡号
        /// </summary>
        public string BankCardNo { get; set; }

        /// <summary>
        /// 转入卡开户行省份名
        /// </summary>
        public string BankProvinceName { get; set; }

        /// <summary>
        /// 转入卡开户行城市名
        /// </summary>
        public string BankCityName { get; set; }

        /// <summary>
        /// 转出银行名称（付款）
        /// </summary>
        public string PayBankName { get; set; }

        /// <summary>
        /// 转出银行卡号（付款）
        /// </summary>
        public string PayBankAccount { get; set; }

        /// <summary>
        /// 转出账户姓名（付款）
        /// </summary>
        public string PayBankAccountName { get; set; }

        /// <summary>
        /// 易通订单组号
        /// </summary>
        public string GroupId { get; set; }

    }
}