using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Transfer
{
    /// <summary>
    /// 银行账户信息
    /// </summary>
    public class BankAccountInfo
    {
        private string _accountNo = string.Empty;
        /// <summary>
        /// 转入账号
        /// </summary>
        public string AccountNo
        {
            get
            {
                return _accountNo;
            }

            set
            {
                if (value != _accountNo)
                {
                    _accountNo = value;
                    AccountNoMask = hideCardNumber(_accountNo);
                }
            }
        }

        /// <summary>
        /// 掩盖的转入账号
        /// </summary>
        public string AccountNoMask { get; set; }

        private string _accountName = string.Empty;
        /// <summary>
        /// 转入账户名
        /// </summary>
        public string AccountName
        {
            get
            {
                return _accountName;
            }

            set
            {
                if (value != _accountName)
                {
                    _accountName = value;
                    AccountNameMask = HideNameWithStar(_accountName);
                }
            }
        }

        /// <summary>
        /// 掩盖的银行卡账户姓名
        /// </summary>
        public string AccountNameMask { get; set; }

        /// <summary>
        /// 转入账户省份名称
        /// </summary>
        public string AccountProvince { get; set; }


        /// <summary>
        /// 转入账户城市名
        /// </summary>
        public string AccountCity { get; set; }


        /// <summary>
        /// 转入银行名称
        /// </summary>
        public string BankName { get; set; }

        private int _bankCardType = 0;
        /// <summary>
        /// 转入卡类型（1：借记卡，2：贷记卡，3预付卡，4准贷记卡）
        /// </summary>
        public int BankCardType
        {
            get { return this._bankCardType; }
            set
            {
                if (this._bankCardType != value)
                {
                    this._bankCardType = value;
                    switch (this._bankCardType)
                    {
                        case 1: BankCardTypeName = "储蓄卡"; break;
                        case 2: BankCardTypeName = "信用卡"; break;
                        case 3: BankCardTypeName = "预付卡"; break;
                        case 4: BankCardTypeName = "准贷记卡"; break;
                        default: BankCardTypeName = "无法识别的卡"; break;
                    }
                }
            }
        }

        /// <summary>
        /// 转入卡类型名称
        /// </summary>
        public string BankCardTypeName { get; set; }

        /// <summary>
        /// 银行图标路径
        /// </summary>
        public string IconUrl { get; set; }

        #region 私有方法

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
        /// 隐藏部分银行卡号
        /// </summary>
        /// <param name="cardNumber">银行卡号</param>
        /// <returns></returns>
        string hideCardNumber(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return cardNumber;

            if (cardNumber.Length < 11)
                return cardNumber;

            //string lastChar = cardNumber.Substring(cardNumber.Length - 1);
            //return cardNumber.Remove(cardNumber.Length - 6) + "*****" + lastChar;

            //改为显示前后各4个字符，中间部分全部隐藏
            string newCardNumber = string.Empty;
            for (int i = 0; i < cardNumber.Length; i++)
            {
                if (i < 4 || i > (cardNumber.Length - 5))
                    newCardNumber += cardNumber[i];
                else
                    newCardNumber += "*";

            }

            return newCardNumber;

        }

        #endregion 私有方法

    }

}