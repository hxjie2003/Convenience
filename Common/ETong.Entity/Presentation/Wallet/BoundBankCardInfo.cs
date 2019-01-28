using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 绑定银行卡信息
    /// </summary>
    public class BoundBankCardInfo
    {
        /// <summary>
        /// 绑定记录ID
        /// </summary>
        public string BoundID { get; set; }

        private string _accountName = string.Empty;
        /// <summary>
        /// 银行卡账户姓名
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
        /// 掩盖的银行卡账户姓名
        /// </summary>
        public string AccountNameMask { get; set; }

        private string _bankCardNum = string.Empty;
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNum
        {
            get
            {
                return _bankCardNum;
            }

            set
            {
                if (value != _bankCardNum)
                {
                    _bankCardNum = value;
                    BankCardNumMask = hideCardNumber(_bankCardNum);
                }
            }
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

      
        /// <summary>
        /// 有掩盖的银行卡号
        /// </summary>
        public string BankCardNumMask { get; set; }

        private string _bankName = string.Empty;
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName
        {
            get
            {
                return _bankName;
            }

            set
            {
                if (value != _bankName)
                {
                    _bankName = value;
                    IconUrl = getBankIconUrlByName(_bankName);
                }
            }
        }
        /// <summary>
        /// 根据银行名称获取银行图标路径或名称
        /// </summary>
        /// <param name="bankName">银行名称</param>
        /// <returns></returns>
        string getBankIconUrlByName(string bankName)
        {
            string iconName = string.Empty;
            string bankFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "Files\\BankIcon.xml";
            System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Load(bankFilePath);
            var icons = from bankNode in xdoc.Element("banks").Elements("bank")
                        where bankNode.Value.Contains(bankName) || bankName.Contains(bankNode.Value) || bankNode.Value == "其他银行"
                        select bankNode.Attribute("iconName").Value;
            if (icons != null && icons.Count() > 0)
                iconName = icons.First();

            return iconName;
        }


        /// <summary>
        /// 卡类型 0 借记卡，1 信用卡
        /// </summary>
        public int CardType { get; set; }

        /// <summary>
        /// 银行图标路径
        /// </summary>
        public string IconUrl { get; set; }

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