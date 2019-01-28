using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 电子钱包账户的多个姓名
    /// </summary>
    public class WalletAccountNames
    {
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
                    RealNameMask = HideNameWithStar(_realName);
                }
            }
        }

        /// <summary>
        /// 掩盖的实名认证的姓名
        /// </summary>
        public string RealNameMask { get; set; }

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
    }
}