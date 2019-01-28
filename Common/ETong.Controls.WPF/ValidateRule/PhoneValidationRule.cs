using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace ETong.Controls.WPF
{
    public class PhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {         
            string valuestring = string.Empty;
            if (value != null) valuestring = value.ToString();
            if (valuestring == "")
            {
                return new ValidationResult(false, "手机号不能为空！");
            }
            string returnMsg = string.Empty;
            if (!PhoneCheck.IsMobile(valuestring, out returnMsg))
            {
                return new ValidationResult(false, returnMsg);
            }
            return ValidationResult.ValidResult;
        }
    }

    public class PhoneCheck
    {
        /// <summary>
        /// 移动号码段前缀
        /// </summary>
        private static string _MobilePrefix = "134,134,135,136,137,138,139,150,151,152,157,158,159,187,188,147";

        /// <summary>
        /// 联通号码段前缀
        /// </summary>
        private static string _UnicomPrefix = "130,131,132,155,156,185,186,145";

        /// <summary>
        /// 电信号码段前缀
        /// </summary>
        private static string _TelecomPrefix = "133,153,180,182,189,1349";

        /// <summary>
        /// 判断是否是中国移动号码
        /// </summary>
        /// <param name="mobileNum">电话号码</param>
        /// <returns></returns>
        public static bool IsMobilePrefix(string mobileNum)
        {
            if (string.IsNullOrEmpty(mobileNum))
            {
                return false;
            }
            string mobileNumPrefix = mobileNum.Substring(0, 3);
            if (!_MobilePrefix.Contains(mobileNumPrefix))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断是否是中国联通号码
        /// </summary>
        /// <param name="mobileNum">电话号码</param>
        /// <returns></returns>
        public static bool IsUnicomPrefix(string mobileNum)
        {
            if (string.IsNullOrEmpty(mobileNum))
            {
                return false;
            }
            string mobileNumPrefix = mobileNum.Substring(0, 3);
            if (!_UnicomPrefix.Contains(mobileNumPrefix))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断是否是中国电信号码
        /// </summary>
        /// <param name="mobileNum">电话号码</param>
        /// <returns></returns>
        public static bool IsTelecomPrefix(string mobileNum)
        {
            if (string.IsNullOrEmpty(mobileNum))
            {
                return false;
            }
            string mobileNumPrefix = mobileNum.Substring(0, 4);
            if (_TelecomPrefix.Contains(mobileNumPrefix))
            {
                return true;
            }
            mobileNumPrefix = mobileNum.Substring(0, 3);
            if (!_TelecomPrefix.Contains(mobileNumPrefix))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断手机号码
        /// </summary>
        /// <param name="inputMobile">手机号码</param>
        /// <returns></returns>
        public static bool IsMobile(string inputMobile, out string returnMsg)
        {
            returnMsg = string.Empty;
            if (inputMobile.Length != 11)
            {
                returnMsg = "您填写的手机号码长度有误，手机号码必须为11位,您只输入了" + inputMobile.Length + "位。";
            }
            string pattern = @"^(13[0-9]|15[0-9]|18[0-9]|17[0-9])\d{8}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(inputMobile))
            {
                returnMsg = "您输入的手机号码正确。";
                return true;
            }
            else
            {
                if (inputMobile.Length == 0)
                {
                    returnMsg = "请输入手机号码";
                    return false;
                }
                returnMsg = "手机号格式有误！";
                return false;
            }
        }
        /// <summary>
        /// 判断电话号码
        /// </summary>
        /// <param name="inputHomePhone">电话号码</param>
        /// <returns></returns>
        public static bool IsPhone(string inputHomePhone)
        {
            //((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)
            //^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^[0-9]{3,4}\-[0-9]{3,8}\-[0-9]{2,5}$
            string pattern = @"(^\d{3,4}-\d{7,8}(-\d{3,4})?$)";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(inputHomePhone);
        }
    }
}
