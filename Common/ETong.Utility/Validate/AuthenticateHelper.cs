using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Utility.Validate
{
    public class AuthenticateHelper
    {
        /// <summary>
        /// 根据18位身份证号判断性别，0：男，1：女，默认为0
        /// </summary>
        /// <param name="idNumber">18位身份证号</param>
        /// <returns></returns>
        public static int getSexByIDNumber(string idNumber)
        {
            int sexFlag = 0;
            if (!string.IsNullOrEmpty(idNumber) && idNumber.Length > 17)
            {
                if (Convert.ToInt32(idNumber[16]) % 2 == 0)
                    sexFlag = 1;
            }

            return sexFlag;
        }

        /// <summary>
        /// 部分隐藏姓名 -- 隐藏姓
        /// </summary>
        /// <param name="name">姓名</param>
        /// <returns></returns>
        public static string HideNameWithStar(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            //name = name.Substring(0, name.Length - 1) + "*";
            name = "*" + name.Substring(1);
            return name;
        }

        /// <summary>
        /// 隐藏部分身份证号
        /// </summary>
        /// <param name="cardNumber">身份证号</param>
        /// <returns></returns>
        public static string hideIdCardNumber(string idCardNumber)
        {
            if (string.IsNullOrWhiteSpace(idCardNumber))
                return idCardNumber;

            if (idCardNumber.Length < 12)
                return idCardNumber;

            string lastChar = idCardNumber.Substring(idCardNumber.Length - 1);
            return idCardNumber.Remove(idCardNumber.Length - 6) + "*****" + lastChar;
        }

        /// <summary>
        /// 判断密码格式是否符合要求 - 登录
        /// 要求必须含字符、数字，可以有-_，不能有其它字符
        /// 支付密码：4-20位
        /// 登录密码：8-16位
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool IsLoginPasswordAvailable(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Trim().Length < 8 || password.Trim().Length > 16)
                return false;
            
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^((?=.*?\\d)(?=.*?[A-Za-z])|(?=.*?\\d)(?=.*?[-_])|(?=.*?[A-Za-z])(?=.*?[-_]))([\\dA-Za-z_-]+){8,16}$");
            if (regex.IsMatch(password))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断密码格式是否符合要求 - 支付
        /// 要求必须含字符、数字，可以有-_，不能有其它字符
        /// 支付密码：4-20位
        /// 登录密码：8-16位
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool IsPayPasswordAvailable(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Trim().Length < 4 || password.Trim().Length > 20)
                return false;

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^((?=.*?\\d)(?=.*?[A-Za-z])|(?=.*?\\d)(?=.*?[-_])|(?=.*?[A-Za-z])(?=.*?[-_]))([\\dA-Za-z_-]+){4,20}$");
            if (regex.IsMatch(password))
                return true;
            else
                return false;

        }

        /// <summary>
        /// 判断密码格式是否符合要求
        /// 要求必须含字符、数字，可以有-_，不能有其它字符，字母开头
        /// <param name="password">密码</param>
        /// <returns></returns>
        private static bool isPasswordAvailable(string password)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]+[-_]*[0-9]+[a-zA-Z0-9\-_]*$");

            if (regex.IsMatch(password))
                return true;
            else
                return false;

        }

    }
}
