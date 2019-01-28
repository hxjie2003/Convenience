using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 电子钱包账户信息
    /// </summary>
    public class WalletAccountInfo
    {
        /// <summary>
        /// 帐户ID
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// 帐户名称
        /// </summary>
        public string AccountName { get; set; }

        private string _realName = string.Empty;
        /// <summary>
        /// 实名认证的姓名
        /// </summary>
        public string RealName
        {
            get
            {
                return _realName;
            }

            set
            {
                if (value != _realName)
                {
                    _realName = value;
                    RealNameMask =HideNameWithStar(_realName);
                }
            }
        }
        /// <summary>
        /// 部分隐藏姓名 -- 隐藏姓
        /// </summary>
        /// <param name="name">姓名</param>
        /// <returns></returns>
        string HideNameWithStar(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            //name = name.Substring(0, name.Length - 1) + "*";
            name = "*" + name.Substring(1);
            return name;
        }

        /// <summary>
        /// 掩盖的实名认证的姓名
        /// </summary>
        public string RealNameMask { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileNum { get; set; }

        /// <summary>
        /// 帐号状态 0: 停用 1:正常使用 2:冻结
        /// </summary>
        public string AccountStatus { get; set; }

        /// <summary>
        /// 帐户余额（元）
        /// </summary>
        public decimal AvailBalance { get; set; }

        /// <summary>
        /// 帐户可提现余额（元）
        /// </summary>
        public decimal CashBalance { get; set; }

        /// <summary>
        /// 冻结余额（元）
        /// </summary>
        public decimal BlockedBalance { get; set; }

        /// <summary>
        /// 信用卡充值余额（元）
        /// </summary>
        public decimal CreditBalance { get; set; }

        /// <summary>
        /// 实名认证状态 0：未认证，1：已认证
        /// </summary>
        public int NameAuth { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        private string _idCardNum = string.Empty;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNum
        {
            get
            {
                return _idCardNum;
            }

            set
            {
                if (value != _idCardNum)
                {
                    _idCardNum = value;
                    IdCardNumMask = hideIdCardNumber(_idCardNum);
                }
            }
        }

        /// <summary>
        /// 隐藏部分身份证号
        /// </summary>
        /// <param name="idCardNumber">身份证号</param>
        /// <returns></returns>
        string hideIdCardNumber(string idCardNumber)
        {
            if (string.IsNullOrWhiteSpace(idCardNumber))
                return idCardNumber;

            if (idCardNumber.Length < 12)
                return idCardNumber;

            string lastChar = idCardNumber.Substring(idCardNumber.Length - 1);
            return idCardNumber.Remove(idCardNumber.Length - 6) + "*****" + lastChar;
        }       

        /// <summary>
        /// 掩盖的身份证号
        /// </summary>
        public string IdCardNumMask { get; set; }

        /// <summary>
        /// 是否所有密码都已设置
        /// </summary>
        public bool IsAllPwdExist { get; set; }

        /// <summary>
        /// 是否新建账户
        /// </summary>
        public bool IsNewAccount { get; set; }

    }
}