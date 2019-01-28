using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace JavaOrderSdk
{
    /// <summary>
    /// 为应用程序提供数据加密与解密等安全服务
    /// </summary>
    public class SecurityHelper
    {
        /// <summary>
        /// 混淆字符串
        /// </summary>
        const string mixtureSeed = "A^9_";

        /// <summary>
        /// 基本64位算法加密与解密
        /// </summary>
        public class BASE64
        {
            /// <summary>
            ///  基本64位加密
            /// </summary>
            /// <param name="input">要加密的字符串</param>
            /// <returns>String</returns>
            public static string Encrypt(string input)
            {
                input = mixtureSeed + input;
                return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
            }

            /// <summary>
            ///  基本64位解密
            /// </summary>
            /// <param name="input">要机密的字符串</param>
            /// <returns>String</returns>
            public static string Decrypt(string input)
            {
                string txt = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(input));
                return txt.Remove(0, mixtureSeed.Length);
            }
        }

        /// <summary>
        /// DES算法加密与解密
        /// </summary>
        public class DES
        {
            /// <summary>
            /// 加密字符串
            /// </summary>
            /// <param name="source">待加密的字符串</param>
            /// <returns></returns>
            public static string Encrypt(string source)
            {
                StringBuilder s = new StringBuilder();

                try
                {
                    string key = "_HA@CON#";
                    string iv = "@N&OCAH_";

                    if ((source == "") || (source == null))
                        return "";

                    byte[] bf_1 = Encoding.ASCII.GetBytes(key);
                    byte[] bf_2 = Encoding.ASCII.GetBytes(iv);

                    byte[] bf_3 = Encoding.Default.GetBytes(source);

                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                    des.Key = bf_1;
                    des.IV = bf_2;

                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                    cs.Write(bf_3, 0, bf_3.Length);
                    cs.FlushFinalBlock();
                    foreach (byte b in ms.ToArray())
                    {
                        s.AppendFormat("{0:X2}", b);
                    }

                    cs.Close();
                    cs.Dispose();
                    ms.Close();
                    ms.Dispose();
                }
                catch { return source; }

                return s.ToString();
            }

            /// <summary>
            /// 解密字符串
            /// </summary>
            /// <param name="source">待解密的字符串</param>
            /// <returns></returns>
            public static string Decrypt(string source)
            {
                StringBuilder s = new StringBuilder();

                try
                {
                    string key = "_HA@CON#";
                    string iv = "@N&OCAH_";

                    if ((source == "") || (source == null))
                        return "";

                    byte[] bf_1 = Encoding.ASCII.GetBytes(key);
                    byte[] bf_2 = Encoding.ASCII.GetBytes(iv);

                    byte[] bf_5 = new byte[source.Length / 2];

                    for (int i = 0; i < (source.Length / 2); i++)
                    {
                        int k = System.Convert.ToInt32(source.Substring(i * 2, 2), 0x10);
                        bf_5[i] = (byte)k;
                    }

                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                    des.Key = bf_1;
                    des.IV = bf_2;

                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                    cs.Write(bf_5, 0, bf_5.Length);
                    cs.FlushFinalBlock();
                    s.Append(Encoding.Default.GetString(ms.ToArray()));

                    cs.Close();
                    cs.Dispose();
                    ms.Close();
                    ms.Dispose();
                }
                catch { return source; }

                return s.ToString();
            }

            /// <summary>
            /// 加密字符串
            /// </summary>
            /// <param name="source">待加密的字符串</param>
            /// <returns></returns>
            public static string Encrypt(string source, string key, string iv)
            {
                StringBuilder s = new StringBuilder();

                try
                {
                    if ((source == "") || (source == null))
                        return "";

                    byte[] bf_1 = Encoding.ASCII.GetBytes(key);
                    byte[] bf_2 = Encoding.ASCII.GetBytes(iv);

                    byte[] bf_3 = Encoding.Default.GetBytes(source);

                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                    des.Key = bf_1;
                    des.IV = bf_2;

                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                    cs.Write(bf_3, 0, bf_3.Length);
                    cs.FlushFinalBlock();
                    foreach (byte b in ms.ToArray())
                    {
                        s.AppendFormat("{0:X2}", b);
                    }

                    cs.Close();
                    cs.Dispose();
                    ms.Close();
                    ms.Dispose();
                }
                catch { return source; }

                return s.ToString();
            }

            /// <summary>
            /// 解密字符串
            /// </summary>
            /// <param name="source">待解密的字符串</param>
            /// <returns></returns>
            public static string Decrypt(string source, string key, string iv)
            {
                StringBuilder s = new StringBuilder();

                try
                {
                    if ((source == "") || (source == null))
                        return "";

                    byte[] bf_1 = Encoding.ASCII.GetBytes(key);
                    byte[] bf_2 = Encoding.ASCII.GetBytes(iv);

                    byte[] bf_5 = new byte[source.Length / 2];

                    for (int i = 0; i < (source.Length / 2); i++)
                    {
                        int k = System.Convert.ToInt32(source.Substring(i * 2, 2), 0x10);
                        bf_5[i] = (byte)k;
                    }

                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                    des.Key = bf_1;
                    des.IV = bf_2;

                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                    cs.Write(bf_5, 0, bf_5.Length);
                    cs.FlushFinalBlock();
                    s.Append(Encoding.Default.GetString(ms.ToArray()));

                    cs.Close();
                    cs.Dispose();
                    ms.Close();
                    ms.Dispose();
                }
                catch { return source; }

                return s.ToString();
            }
        }

        /// <summary>
        /// MD5算法加密
        /// </summary>
        public class MD5
        {
            /// <summary>
            /// MD5不可逆加密
            /// </summary>
            /// <param name="input">要加密的字符串</param>
            /// <returns>String</returns>
            public static string Encrypt(string input)
            {
                input = mixtureSeed + input;
                System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
                byte[] datSource = System.Text.Encoding.Default.GetBytes(input);
                byte[] newSource = md5.ComputeHash(datSource);
                string byte2String = null;
                for (int i = 0; i < newSource.Length; i++)
                {
                    string thisByte = newSource[i].ToString("x");
                    if (thisByte.Length == 1) thisByte = "0" + thisByte;
                    byte2String += thisByte;
                }
                return byte2String;
            }

            /// <summary>
            /// MD5加密
            /// </summary>
            /// <param name="intput">待加密字符串</param>
            /// <param name="encoding">字符集</param>
            /// <returns></returns>
            public static string Encrypt(string intput, Encoding encoding)
            {
                var md5 = new MD5CryptoServiceProvider();

                byte[] data = encoding.GetBytes(intput);//将字符编码为一个字节序列 

                byte[] md5Data = md5.ComputeHash(data);//计算data字节数组的哈希值 

                md5.Clear();

                return md5Data.Aggregate("", (current, t) => current + t.ToString("x").PadLeft(2, '0'));
            }

            public static string EncryptNoPrefix(string input)
            {
                //input = mixtureSeed + input;
                System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
                byte[] datSource = System.Text.Encoding.Default.GetBytes(input);
                byte[] newSource = md5.ComputeHash(datSource);
                string byte2String = null;
                for (int i = 0; i < newSource.Length; i++)
                {
                    string thisByte = newSource[i].ToString("x");
                    if (thisByte.Length == 1) thisByte = "0" + thisByte;
                    byte2String += thisByte;
                }
                return byte2String;
            }
            public static string EncryptFile(string filePath)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string fileContent = sr.ReadToEnd();
                    return EncryptNoPrefix(fileContent);
                }
            }
        }
    }
}

