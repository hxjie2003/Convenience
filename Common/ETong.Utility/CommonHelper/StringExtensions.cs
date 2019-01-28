using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace ETong.Utility
{
    /// <summary>
    /// String对象扩展
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 对字符串进行 URL 编码, 默认使用字符集 utf-8
        /// </summary>
        /// <param name="str"></param>
        /// <param name="codeUpCase">编码值是否大写</param>
        /// <returns></returns>
        public static String UrlEncode(this String str, bool codeUpCase = false)
        {
            var sb = new StringBuilder();

            Encoding encoding = Encoding.UTF8;

            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                var t = str[i].ToString(CultureInfo.InvariantCulture);
                var k = System.Web.HttpUtility.UrlEncode(t, encoding);

                if (string.Equals(t, k))
                    sb.Append(t);
                else if (!string.IsNullOrWhiteSpace(k))
                    sb.Append(codeUpCase ? k.ToUpper() : k);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 对字符串进行 URL 编码, 默认使用字符集 utf-8
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">编码字符集</param>
        /// <param name="codeUpCase">编码值是否大写</param>
        /// <returns></returns>
        public static String UrlEncode(this String str, Encoding encoding, bool codeUpCase = false)
        {
            var sb = new StringBuilder();

            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                var t = str[i].ToString(CultureInfo.InvariantCulture);
                var k = System.Web.HttpUtility.UrlEncode(t, encoding);

                if (string.Equals(t, k))
                    sb.Append(t);
                else if (!string.IsNullOrWhiteSpace(k))
                    sb.Append(codeUpCase ? k.ToUpper() : k);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 对字符串进行 GBK 编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String GBKEncode(this String str)
        {
            Encoding gbk = Encoding.GetEncoding(936);

            return gbk.GetString(Encoding.Default.GetBytes(str));
        }

        /// <summary>
        /// 对字符串进行 GBK 编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String Encode(this String str, Encoding encoding)
        {
            return encoding.GetString(encoding.GetBytes(str));
        }
        /// <summary>
        /// html解码字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToDecodeHtml(this string str)
        {
            return HttpUtility.HtmlDecode(str);
        }
    }
}
