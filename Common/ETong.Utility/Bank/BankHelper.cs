using ETong.Entity.Presentation.Payment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ETong.Utility.Bank
{
    public class BankHelper
    {
        /// <summary>
        /// 根据卡号获取银行名称等信息
        /// 银行列表文件路径默认为 xml\\BankInfo.xls
        /// </summary>
        /// <param name="bankCardNo">银行卡号</param>
        /// <param name="filePath">银行列表文件路径</param>
        /// <returns></returns>
        public static BankCardInfo GetBankCardInfo(string bankCardNo, string filePath=null)
        {
            if (string.IsNullOrEmpty(bankCardNo))
                throw new Exception("(GetBankCardInfo)银行卡号为空！");

            BankCardInfo bankInfo = new BankCardInfo();
            string bankXlsPath = string.Empty;
            if (string.IsNullOrEmpty(filePath))
                bankXlsPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "xml\\BankInfo.xls";
            else
                bankXlsPath = filePath;

            ETong.Utility.Log.Logger.Write(ETong.Common.Enum.Log.Log_Type.Info, "ETong.Utility.Bank", "BankHelper", "GetBankCardInfo", "读取xls文件  路径 " + bankXlsPath);
            System.Data.DataSet dsBankInfo = GetDataSetFromExcel(bankXlsPath, "where cardLength='" + bankCardNo.Length + "' and Instr('" + bankCardNo + "',cardPrefix)=1 order by cardPrefixLength desc");
            if (dsBankInfo != null && dsBankInfo.Tables.Count > 0)
            {
                System.Data.DataTable tableBandInfo = dsBankInfo.Tables[0];
                if (tableBandInfo.Rows.Count > 0)
                {
                    
                    string bankNameInfo = tableBandInfo.Rows[0]["bankName"].ToString();
                    bankInfo.BankName = bankNameInfo.Substring(0, bankNameInfo.IndexOf('\n'));
                    bankInfo.BankCode = bankNameInfo.Substring(bankNameInfo.IndexOf('\n') + 2, 8);

                    string cardTypeName = tableBandInfo.Rows[0]["cardType"].ToString().Trim();
                    ETong.Utility.Log.Logger.Write(ETong.Common.Enum.Log.Log_Type.Info, "ETong.Utility.Bank", "BankHelper", "GetBankCardInfo", "读取xls文件 类型:"+cardTypeName);
                    switch (cardTypeName)
                    {
                        case "借记卡":
                            bankInfo.BankCardType = 1;
                            break;
                        case "贷记卡":
                            bankInfo.BankCardType = 2;
                            break;
                        case "预付费卡":
                            bankInfo.BankCardType = 3;
                            break;
                        case "准贷记卡":
                            bankInfo.BankCardType = 4;
                            break;
                        default:
                            break;
                    }
                }
            }
            return bankInfo;
        }

        /// <summary>
        /// 根据银行前四位编号判断是否支持信用卡还款
        /// </summary>
        /// <param name="bankCode">银行前四位编号</param>
        /// <returns></returns>
        public static bool IsSupportedCreditCard(string bankCode)
        {
            string bankXmlPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "xml\\CreditCardBank.xml";
            XDocument xDoc = XDocument.Load(bankXmlPath);
            var bankInfoNodes = xDoc.Element("SupportedCreditCardBank").Elements("Bank");
            var supportedBankNode = from node in bankInfoNodes
                                    where node.Attribute("BankCode").Value == bankCode
                                    select node;
            if (supportedBankNode != null && supportedBankNode.Count() > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否有效银行卡
        /// </summary>
        /// <param name="cardNo">卡号</param>
        /// <returns></returns>
        public static bool isLegalCard(string cardNo)
        {
            try
            {
                int cardLength = cardNo.Length;
                if (cardLength < 10 || cardLength > 19)
                    return false;
                string validateNum = cardNo.Substring(cardLength - 1, 1);
                int cardSum = 0;
                bool needChange = true;
                for (int i = cardLength - 2; i >= 0; i--)
                {
                    if (needChange)
                    {
                        int tempCalc = Convert.ToInt32(cardNo[i].ToString()) * 2;
                        if (tempCalc > 9)
                        {
                            //若大于9则拆成两个数字
                            int geweishu = tempCalc % 10;
                            cardSum += 1 + geweishu;
                        }
                        else
                        {
                            cardSum += tempCalc;
                        }
                        needChange = false;
                    }
                    else
                    {
                        cardSum += Convert.ToInt32(cardNo[i].ToString());
                        needChange = true;
                    }
                }
                int bushu = 10 - cardSum % 10;
                if (bushu == 10)
                    bushu = 0;
                if (bushu == Convert.ToInt32(validateNum))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 转换excel为DataSet，工作表名必须为默认的Sheet1
        /// </summary>
        /// <param name="filePath">Excel文件路径</param>
        /// <returns></returns>
        public static DataSet GetDataSetFromExcel(string filePath, string where)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
            using (OleDbConnection OleConn = new OleDbConnection(strConn))
            {
                DataSet ds = new DataSet();
                try
                {
                    OleConn.Open();
                    string strSql = "SELECT * FROM [Sheet1$] ";
                    if (where.Length > 0)
                    {
                        strSql += where;
                    }
                    OleDbCommand cmd = new OleDbCommand(strSql, OleConn);
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(cmd))
                    {
                        OleDaExcel.Fill(ds, "BankInfo");
                    }
                }
                catch (Exception ex)
                {
                    ds = null;
                    ETong.Utility.Log.Logger.Write(ETong.Common.Enum.Log.Log_Type.Info, "ETong.Utility.Bank", "BankHelper", "GetBankCardInfo", "读取xls文件异常:" + ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 判断信用卡还款是否符合规定（这里看最低限额）
        /// </summary>
        /// <param name="creditCardNo">信用卡号</param>
        /// <param name="repayAmount">还款金额（元）</param>
        /// <returns></returns>
        public static bool IsRepayAmountAvailable(string creditCardNo, decimal repayAmount)
        {
            var bankCardInfo = GetBankCardInfo(creditCardNo);
            if (bankCardInfo == null)
                return false;
            string bankCode = bankCardInfo.BankCode.Substring(0, 4);

            string bankXmlPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "xml\\CreditCardBank.xml";
            XDocument xDoc = XDocument.Load(bankXmlPath);
            var bankInfoNodes = xDoc.Element("SupportedCreditCardBank").Elements("Bank");
            var supportedBankNode = from node in bankInfoNodes
                                    where node.Attribute("BankCode").Value == bankCode
                                    select node;
            if (supportedBankNode != null && supportedBankNode.Count() > 0)
            {
                var xnode = supportedBankNode.First();
                if (xnode.Attribute("MinLimit") == null)
                    return true;
                else if (decimal.Parse(supportedBankNode.First().Attribute("MinLimit").Value) <= repayAmount)
                    return true;
                else
                    return false;

            }
            else
            {
                //卡不支持
                return false;
            }
        }

        /// <summary>
        /// 根据银行前四位编号判断是否支持转账
        /// </summary>
        /// <param name="bankCode">银行前四位编号</param>
        /// <param name="isTransferIn">是否转入</param>
        /// <returns></returns>
        public static bool IsSupportedTransferCard(string bankCode, bool isTransferIn)
        {
            //工行不支持转入转出，农行不支持转出，其他银行均支持
            bool isSupport = true;
            if (bankCode == "0102")
                isSupport = false;
            else if (!isTransferIn && bankCode == "0103")
                isSupport = false;

            return isSupport;
        }

        /// <summary>
        /// 根据银行英文代码获取银行图标路径或名称
        /// </summary>
        /// <param name="bankEnCode">银行英文代码</param>
        /// <returns></returns>
        public static string getBankIconUrlByEnCode(string bankEnCode)
        {
            string iconName = string.Empty;
            string bankFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "Files\\BankIcon.xml";
            XDocument xdoc = XDocument.Load(bankFilePath);
            var icons = from bankNode in xdoc.Element("banks").Elements("bank")
                        where bankNode.Attribute("enCode").Value == bankEnCode || bankNode.Attribute("enCode").Value == "OTH"
                        select bankNode.Attribute("iconName").Value;
            if (icons != null && icons.Count() > 0)
                iconName = icons.First();

            return iconName;
        }

        /// <summary>
        /// 根据银行名称获取银行图标路径或名称
        /// </summary>
        /// <param name="bankName">银行名称</param>
        /// <returns></returns>
        public static string getBankIconUrlByName(string bankName)
        {
            string iconName = string.Empty;
            string bankFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "Files\\BankIcon.xml";
            XDocument xdoc = XDocument.Load(bankFilePath);
            var icons = from bankNode in xdoc.Element("banks").Elements("bank")
                        where bankNode.Value.Contains(bankName) || bankName.Contains(bankNode.Value) || bankNode.Value == "其他银行"
                        select bankNode.Attribute("iconName").Value;
            if (icons != null && icons.Count() > 0)
                iconName = icons.First();

            return iconName;
        }

        /// <summary>
        /// 隐藏部分银行卡号
        /// </summary>
        /// <param name="cardNumber">银行卡号</param>
        /// <returns></returns>
        public static string hideCardNumber(string cardNumber)
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

    }
}
