using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    /// <summary>
    /// webapi输入参数基类
    /// </summary>
    public class InputAccount : InputBase
    {
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 会员手机号
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddr { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 是否已实名认证
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// 钱包账户名称
        /// </summary>
        public string WalletAccountName { get; set; }

        /// <summary>
        /// 钱包账户登录密码
        /// </summary>
        public string WalletLoginPwd { get; set; }

        /// <summary>
        /// 钱包账户支付密码
        /// </summary>
        public string WalletPayPwd { get; set; }

    }
}