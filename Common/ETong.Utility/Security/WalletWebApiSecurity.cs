using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Utility.Security
{
    /// <summary>
    /// Wallet WebApi的安全措施
    /// </summary>
    public class WalletWebApiSecurity
    {
        /// <summary>
        /// 签名计算请求时间、会员id、etmCode，AES密钥为会员密码。
        /// </summary>
        /// <param name="requestTime">请求时间</param>
        /// <param name="memberId">会员id</param>
        /// <param name="memberLoginPwd">会员登录密码</param>
        /// <param name="etmCode">etm编号</param>
        /// <param name="apiKey">加密用的key</param>
        /// <returns></returns>
        public static string GetSign(DateTime requestTime, string memberId, string memberLoginPwd, string etmCode, string apiKey)
        {
            string requestTimeString = requestTime.ToString("yyyyMMddHHmmss");
            string sign = string.Format("requestTime={0}&memberId={1}&memberLoginPwd={2}&etmCode={3}", requestTime, memberId, memberLoginPwd, etmCode);

            sign = AES.Encrypt(sign, apiKey);
            sign = MD5.Encrypt(sign);

            return sign;
        }

        /// <summary>
        /// 签名计算请求时间、会员id、etmCode，AES密钥为会员密码。
        /// </summary>
        /// <param name="requestTime">请求时间</param>
        /// <param name="memberId">会员id</param>
        /// <param name="memberLoginPwd">会员登录密码</param>
        /// <param name="etmCode">etm编号</param>
        /// <param name="apiKey">加密用的key</param>
        /// <param name="requestSign">请求的sign参数</param>
        /// <returns></returns>
        public static bool CheckSign(DateTime requestTime, string memberId, string memberLoginPwd, string etmCode, string apiKey, string requestSign)
        {
            string requestTimeString = requestTime.ToString("yyyyMMddHHmmss");
            string sign = string.Format("requestTime={0}&memberId={1}&memberLoginPwd={2}&etmCode={3}", requestTime, memberId, memberLoginPwd, etmCode);

            sign = AES.Encrypt(sign, apiKey);
            sign = MD5.Encrypt(sign);

            return requestSign.Equals(sign);
        }

        /// <summary>
        /// 签名计算请求时间、会员id、etmCode，AES密钥为会员密码。
        /// </summary>
        /// <param name="requestTime">请求时间</param>
        /// <param name="memberId">会员id</param>
        /// <param name="etmCode">etm编号</param>
        /// <param name="apiKey">加密用的key</param>
        /// <returns></returns>
        public static string GetSignNoPwd(DateTime requestTime, string memberId, string etmCode, string apiKey)
        {
            string requestTimeString = requestTime.ToString("yyyyMMddHHmmss");
            string sign = string.Format("requestTime={0}&memberId={1}&etmCode={2}", requestTime, memberId, etmCode);

            sign = AES.Encrypt(sign, apiKey);
            sign = MD5.Encrypt(sign);

            return sign;
        }

        /// <summary>
        /// 签名计算请求时间、会员id、etmCode，AES密钥为会员密码。
        /// </summary>
        /// <param name="requestTime">请求时间</param>
        /// <param name="memberId">会员id</param>
        /// <param name="etmCode">etm编号</param>
        /// <param name="apiKey">加密用的key</param>
        /// <param name="requestSign">请求的sign参数</param>
        /// <returns></returns>
        public static bool CheckSignNoPwd(DateTime requestTime, string memberId, string etmCode, string apiKey, string requestSign)
        {
            string requestTimeString = requestTime.ToString("yyyyMMddHHmmss");
            string sign = string.Format("requestTime={0}&memberId={1}&etmCode={2}", requestTime, memberId, etmCode);

            sign = AES.Encrypt(sign, apiKey);
            sign = MD5.Encrypt(sign);

            return requestSign.Equals(sign);
        }

    }
}