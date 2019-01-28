using System;
using System.Text.RegularExpressions;

namespace ETong.Utility.Validate
{
    /// <summary>
    /// 为应用程序提供基本数据检查与识别服务
    /// </summary>
    public class Check
    {
        /// <summary>
        /// 检查指定的数据是否为NULL值
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsNull(object value)
        {
            bool isNull = false;

            try
            {
                if (value == null || value == System.DBNull.Value)
                {
                    isNull = true;
                }
            }
            catch 
            { 
            
            }

            return isNull;
        }

        /// <summary>
        /// 检查指定的数据是否为空值
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsEmpty(object value)
        {
            bool isEmpty = false;

            try
            {
                if (IsNull(value))
                {
                    isEmpty = true;
                }
                else if (value.ToString().Trim().Length == 0)
                {
                    isEmpty = true;
                }
            }
            catch
            { 
            
            }

            return isEmpty;
        }

        /// <summary>
        /// 检查指定的数据是否为日期
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsDateTime(object value)
        {
            bool isDateTime = false;

            try
            {
                if (!IsEmpty(value))
                {
                    DateTime dt;

                    isDateTime = DateTime.TryParse(value.ToString(), out dt);
                }
            }
            catch 
            { 
            
            }

            return isDateTime;
        }

        /// <summary>
        /// 检查指定的数据是否为浮点型数据日期
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsFloat(object value)
        {
            if (IsEmpty(value))
                return false;
            else
            {
                float f = 0;
                return float.TryParse(value.ToString(), out f);
            }
        }

        /// <summary>
        /// 检查指定的数据是否为双精度型数据
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsDouble(object value)
        {
            if (IsEmpty(value))
                return false;
            else
            {
                double f = 0;
                return double.TryParse(value.ToString(), out f);
            }
        }

        /// <summary>
        /// 检查指定的数据是否为整型数据日期
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsInt(object value)
        {
            if (IsEmpty(value))
                return false;
            else
            {
                Int32 i = 0;
                return Int32.TryParse(value.ToString(), out i);
            }
        }

        /// <summary>
        /// 检查指定的数据是否为布尔型数据日期
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsBoolean(object value)
        {
            if (IsEmpty(value))
                return false;
            else
            {
                Boolean b = false;
                return Boolean.TryParse(value.ToString(), out b);
            }
        }

        /// <summary>
        /// 检查是否为安全的SQL数据，以确保免收SQL注入式攻击
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsSafeSqlData(string value)
        {
            if (!IsEmpty(value))
            {
                string sql = "',and,exec,insert,select,delete,update,count,*,%,chr,mid,master,truncate,char,declare,cmd,like";
                string[] sqlKeywords = sql.Split(',');
                foreach (string key in sqlKeywords)
                {
                    if (value.ToString().ToLower().Trim().Contains(key))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 检查是否为安全的SQL数据，以确保免收SQL注入式攻击
        /// </summary>
        /// <param name="value">要检查的数据</param>
        /// <returns>bool</returns>
        public static bool IsSafeSqlData(string[] values)
        {
            foreach (string v in values)
            {
                if (!IsSafeSqlData(v))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检查指定文本是否包含HTML标签
        /// </summary>
        public static bool IsHtml(string text)
        {
            string p = "<(?:(?:\\/?[A-Za-z]\\w+\\b(?:[=\\s](['\"]?)[\\s\\S]*?\\1)*)|(?:!--[\\s\\S]*?--))>";
            Regex regex = new Regex(p);
            return regex.IsMatch(text);
        }

        /// <summary>
        /// 检查是否为电子邮箱
        /// </summary>
        public static bool IsEmail(string text)
        {
            string p = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            Regex regex = new Regex(p);
            return regex.IsMatch(text);
        }

        /// <summary>
        /// 是否是手机号码
        /// </summary>
        public static bool IsCellphone(string text)
        {
            string p = "13[0-9]{9}$|15[0-9]{9}$|18[0-9]{9}$";
            Regex regex = new Regex(p);
            return regex.IsMatch(text);
        }

        /// <summary>
        /// 是否是有效网址
        /// </summary>
        public static bool IsUrl(string text)
        {
            string p = "(\\w+:\\/\\/)?\\w+(\\.\\w+)+.*$";
            Regex regex = new Regex(p);
            return regex.IsMatch(text);
        }
    }
}

