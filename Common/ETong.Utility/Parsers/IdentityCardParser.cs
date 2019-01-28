using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Utility.Parsers
{
    public class IdentityCardParser
    {
        public static short GetGenderCode(string idCardNo)
        {
            int genderCode = 2;

            //空值返回默认值
            if (string.IsNullOrEmpty(idCardNo))
                return (short)genderCode;

            if (idCardNo.Length == 15)
            {
                //一代身份证最后一位数为奇数是男，偶数是女
                if (Convert.ToInt32(idCardNo.Substring(14, 1)) % 2 == 0)
                    genderCode = 1;
                else
                    genderCode = 0;
            }
            else if (idCardNo.Length == 18)
            {
                //二代身份证第17位为奇数是男，偶数是女
                int flag = Convert.ToInt32(idCardNo.Substring(16, 1));
                if (flag % 2 == 0)
                    genderCode = 1;
                else
                    genderCode = 0;
            }

            return (short)genderCode;

        }
    }
}
