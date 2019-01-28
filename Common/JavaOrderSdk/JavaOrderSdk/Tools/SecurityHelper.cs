using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace JavaOrderSdk
{
    /// <summary>
    /// ΪӦ�ó����ṩ���ݼ�������ܵȰ�ȫ����
    /// </summary>
    public class SecurityHelper
    {
        /// <summary>
        /// �����ַ���
        /// </summary>
        const string mixtureSeed = "A^9_";

        /// <summary>
        /// ����64λ�㷨���������
        /// </summary>
        public class BASE64
        {
            /// <summary>
            ///  ����64λ����
            /// </summary>
            /// <param name="input">Ҫ���ܵ��ַ���</param>
            /// <returns>String</returns>
            public static string Encrypt(string input)
            {
                input = mixtureSeed + input;
                return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
            }

            /// <summary>
            ///  ����64λ����
            /// </summary>
            /// <param name="input">Ҫ���ܵ��ַ���</param>
            /// <returns>String</returns>
            public static string Decrypt(string input)
            {
                string txt = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(input));
                return txt.Remove(0, mixtureSeed.Length);
            }
        }

        /// <summary>
        /// DES�㷨���������
        /// </summary>
        public class DES
        {
            /// <summary>
            /// �����ַ���
            /// </summary>
            /// <param name="source">�����ܵ��ַ���</param>
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
            /// �����ַ���
            /// </summary>
            /// <param name="source">�����ܵ��ַ���</param>
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
            /// �����ַ���
            /// </summary>
            /// <param name="source">�����ܵ��ַ���</param>
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
            /// �����ַ���
            /// </summary>
            /// <param name="source">�����ܵ��ַ���</param>
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
        /// MD5�㷨����
        /// </summary>
        public class MD5
        {
            /// <summary>
            /// MD5���������
            /// </summary>
            /// <param name="input">Ҫ���ܵ��ַ���</param>
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
            /// MD5����
            /// </summary>
            /// <param name="intput">�������ַ���</param>
            /// <param name="encoding">�ַ���</param>
            /// <returns></returns>
            public static string Encrypt(string intput, Encoding encoding)
            {
                var md5 = new MD5CryptoServiceProvider();

                byte[] data = encoding.GetBytes(intput);//���ַ�����Ϊһ���ֽ����� 

                byte[] md5Data = md5.ComputeHash(data);//����data�ֽ�����Ĺ�ϣֵ 

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

