using System;
using System.Text;

namespace ETong.Utility
{
    /// <summary>
    /// 常用数据转换类
    /// </summary>
    public class CustomConvert
    {
        /// <summary>
        /// 转uint
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint ToUInt(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return uint.MinValue;
            }

            try
            {
                return Convert.ToUInt32(value);
            }
            catch
            {
                return uint.MinValue;
            }
        }
        /// <summary>
        /// 转long
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return long.MinValue;
            }

            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return long.MinValue;
            }
        }
        /// <summary>
        /// 转ulong
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ulong ToULong(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ulong.MinValue;
            }

            try
            {
                return Convert.ToUInt64(value);
            }
            catch
            {
                return ulong.MinValue;
            }
        }
        /// <summary>
        /// 转bool
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 字符串转byte
        /// </summary>
        /// <param name="bytes">转换结果</param>
        /// <param name="value">被转换字符串</param>
        /// <param name="encodingName">编码</param>
        public static void StringToBytes(byte[] bytes, string value, string encodingName)
        {
            byte[] tempBytes = new byte[2 * Math.Max(bytes.Length, value.Length)];

            Encoding.GetEncoding(encodingName).GetBytes(value, 0, value.Length, tempBytes, 0);

            for (uint i = 0; i < bytes.Length; i++)
            {
                bytes[i] = tempBytes[i];
            }
        }
        /// <summary>
        /// Int转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return int.MinValue;
            }

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return int.MinValue;
            }
        }

        /// <summary>
        /// double类型转换
        /// </summary>
        public static double ToDouble(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return double.MinValue;
            }

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// double类型转换，保留两位小数
        /// </summary>
        public static string ToTwoDecimal (object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return string.Empty;
            }

            try
            {
                return Convert.ToDouble(value).ToString("0.0");
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// string类型转换
        /// </summary>
        public static string ToString(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }


        /// <summary>
        /// 转换DateTime类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return DateTime.MinValue;
            }

            try
            {
                return DateTime.Parse(value.ToString());
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// 日期转换为yyyyMMdd格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateTimeFormatsD(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return DateTime.Now.ToString();
            }

            try
            {
                return DateTime.Parse(value.ToString()).ToString("yyyyMMdd");
            }
            catch
            {
                return DateTime.Now.ToString();
            }
        }
        /// <summary>
        /// 日期转换为yyyy-MM-dd格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateTimeFormatsG(object value)
        {
            if (value == DBNull.Value || value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return DateTime.Now.ToString();
            }

            try
            {
                return DateTime.Parse(value.ToString()).ToString("yyyy-MM-dd");
            }
            catch
            {
                return DateTime.Now.ToString();
            }
        }
        /// <summary>
        /// 去掉ID横杠
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSqlID(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            try
            {
                return value.Replace("-", "");
            }
            catch { }

            return value;
        }
        /// <summary>
        /// 去掉空格
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToReplaceSpace(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            try
            {
                return value.Replace(" ", "");
            }
            catch { }

            return value;
        }

        /// <summary>
        /// 格式化金额显示，返回格式如：“xx.xx元”
        /// </summary>
        /// <param name="money">金额</param>
        /// <returns></returns>
        public static string FormatMoney(string money)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(money))
                    return string.Empty;

                return Convert.ToDecimal(money).ToString("F2") + " 元";
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
