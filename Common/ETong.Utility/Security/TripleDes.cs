using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;

namespace ETong.Utility.Security
{
    public class TripleDes
    {
        #region CBC模式

        /// <summary>
        /// DES3 CBC模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        /// 
        public static byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        public static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;             //默认值
                tdsp.Padding = PaddingMode.PKCS7;       //默认值

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// DES3 CBC模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeCBC(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        
        /// <summary>
        /// DES3 CBC模式加密
        /// </summary>
        /// <param name="toEncrypt">待加密字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string Des3EncodeCBC(string toEncrypt, string sKey)
        {
            return ByteArrayToHexString(Des3EncodeCBC(HexStringToByteArray(MD5.Encrypt(sKey)), iv, Encoding.UTF8.GetBytes(toEncrypt)));
        }

        /// <summary>
        /// DES3 CBC模式解密
        /// </summary>
        /// <param name="toDecrypt">待解密字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string Des3DecodeCBC(string toDecrypt, string sKey)
        {
            string result = Encoding.UTF8.GetString(Des3DecodeCBC(HexStringToByteArray(MD5.Encrypt(sKey)), iv, HexStringToByteArray(toDecrypt)));
            return result.TrimEnd('\0');
        }

        #endregion

        #region ECB模式

        /// <summary>
        /// DES3 ECB模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }

        /// <summary>
        /// DES3 ECB模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        #endregion

        #region ECB模式-支持弱密钥

        /// <summary>
        /// 3DES-ECB加密，可与其他语言通用
        /// </summary>
        /// <param name="pToDecrypt">16进制待解密数据</param>
        /// <param name="sKey">16进制密钥 8字节?</param>
        /// <returns></returns>
        public static string Des3EncodeECBByAllKey(string pToDecrypt, string sKey)
        {
            TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
            tdsp.Mode = CipherMode.ECB;
            tdsp.Padding = PaddingMode.Zeros;
            byte[] inputByteArray = HexStringToByteArray(pToDecrypt);
            byte[] inputKey = HexStringToByteArray(sKey);

            MethodInfo mi = tdsp.GetType().GetMethod("_NewEncryptor", BindingFlags.NonPublic | BindingFlags.Instance);
            Object[] param = { inputKey, CipherMode.ECB, null, tdsp.FeedbackSize, 0 };
            ICryptoTransform DESEncrypt = mi.Invoke(tdsp, param) as ICryptoTransform;

            //加密得到密文的byte[]形式 
            byte[] byteResult = DESEncrypt.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);

            return ByteArrayToHexString((byteResult)).Replace(" ", "");
        }

        /// <summary>
        /// 3DES-ECB解密，可与其他语言通用
        /// </summary>
        /// <param name="pToDecrypt">16进制待解密数据</param>
        /// <param name="sKey">16进制密钥 8字节?</param>
        /// <returns></returns>
        public static string Des3DecodeECBByAllKey(string pToDecrypt, string sKey)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.Zeros;
            byte[] inputByteArray = HexStringToByteArray(pToDecrypt);
            byte[] inputKey = HexStringToByteArray(sKey);
            
            Type t = Type.GetType("System.Security.Cryptography.CryptoAPITransformMode");
            object obj = t.GetField("Decrypt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).GetValue(t);
            MethodInfo[] methods = des.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            int count = methods.Length;
            MethodInfo mi = des.GetType().GetMethod("_NewEncryptor", BindingFlags.NonPublic | BindingFlags.Instance);
            Object[] param = { inputKey, CipherMode.ECB, null, des.FeedbackSize, obj };
            ICryptoTransform DESEncrypt = mi.Invoke(des, param) as ICryptoTransform;

            //加密得到密文的byte[]形式 
            byte[] byteResult = DESEncrypt.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);

            return ByteArrayToHexString((byteResult)).Replace(" ", "");
        }

        #endregion

        #region DES加解密

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="pToEncrypt">16进制待加密数据</param>
        /// <param name="sKey">16进制密钥 8字节 超过则只传前8字节</param>
        /// <returns></returns>
        public static string DesEncrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.Zeros;
            byte[] inputByteArray = HexStringToByteArray(pToEncrypt);
            des.Key = HexStringToByteArray(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream (It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            byte[] byteResult = ms.ToArray();
            cs.Close();
            ms.Close();
            return ByteArrayToHexString(byteResult);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="pToDecrypt">16进制待解密数据</param>
        /// <param name="sKey">16进制密钥 8字节</param>
        /// <returns></returns>
        public static string DesDecrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.Zeros;
            byte[] inputByteArray = HexStringToByteArray(pToDecrypt);
            byte[] inputKey = HexStringToByteArray(sKey);
            des.Key = inputKey;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            byte[] byteResult = ms.ToArray();
            cs.Close();
            ms.Close();
            return ByteArrayToHexString(byteResult);
        }

        #endregion DES加解密

        #region 字节与16进制字符转换

        /// <summary>
        /// 字节数组转成16进制字符串
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(b.ToString("X2"));

            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// 16进制字符串转成字节数组
        /// </summary>
        /// <param name="s">16进制字符串</param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            byte[] buffer = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
                buffer[i / 2] = (byte)System.Convert.ToByte(hexString.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// 10进制数字转为16进制
        /// </summary>
        /// <param name="digitNumber">10进制数字</param>
        /// <returns></returns>
        public static string ToHexnumber(int digitNumber)
        {
            return System.Convert.ToString(digitNumber, 16);
        }

        #endregion

    }
}
