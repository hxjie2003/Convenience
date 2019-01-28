using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Qianmi.Api;
using ETong.QianMi.Logic;
using log4net;
using log4net.Util;
using Qianmi.Api.Util;

namespace ETong.QianMi.Logic
{
    public class Authorize
    {
        private ILog _log = ETong.Log.Sdk.LoggerMgr.GetLogger<Authorize>();

        #region Public Properties

        /// <summary>
        /// Authorize Code
        /// d7face25232695f1f2b78043ad19f0e0
        /// </summary>
        public static string AUTHORIZE_CODE = "d7face25232695f1f2b78043ad19f0e0";

        /// <summary>
        /// Access Token
        /// 9fff6b60891d45e4bdc018cd4a1b6427
        /// </summary>
        //public static string ACCESS_TOKEN = "41f86158ae364fe88205ca23cc48bc65";

        /// <summary>
        /// 千米接口的配置文件路径，其所在目录必须有读写权限
        /// 内容必须包括Access Token和Refresh Token，用逗号隔开
        /// 如：dbf242e6baf348a6b7dd9df1d099d2f8,5dbc3853fa4b499eb9555a23e5cee122
        /// </summary>
        private static string ConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "App_Data\\QianMiConfig.txt");
            // ConfigurationManager.AppSettings["QianMiConfigPath"];
        
        public static string ACCESS_TOKEN
        {
            get
            {
                return File.ReadAllText(ConfigPath).Split(',')[0];
            }
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        public static string REFRESH_TOKEN
        {
            get
            {
                return File.ReadAllText(ConfigPath).Split(',')[1];
            }
        }
        //public static string REFRESH_TOKEN = "587b6ff02b7545b7b942a3320535a9a5";

        /// <summary>
        /// QianMi open Api URL
        /// </summary>
        public const string API_SERVER_URL = "http://gw.api.qianmi.com/api";

        /// <summary>
        /// QianMi oauth URL
        /// </summary>
        public const string CODE_AUTH_URL = "http://oauth.qianmi.com/authorize";

        /// <summary>
        /// QianMi oauth Redirect URI
        /// </summary>
        public const string REDIRECT_URI = "http://qianmi.com&state=1&view=web";

        /// <summary>
        /// QianMi open APi User Key
        /// </summary>
        public const string APP_KEY = "10000898";

        /// <summary>
        /// QianMi open Api Secret Number
        /// </summary>
        public const string APP_SECRET = "8RF6URVW5SRH5DpC0Yh5DQMHN841geiQ";

        #endregion

        #region private Properties
        

        #endregion

        #region Public Methods

        /// <summary>
        /// 获取授权码code, 目前不使用。
        /// </summary>
        /// <returns></returns>
        public static string GetAuthorizeCode()
        {
            string codeQianMi = string.Empty;

            try
            {
                string parameterAuth = string.Format("?client_id={0}&response_type=code&redirect_uri={2}", APP_KEY, APP_SECRET, REDIRECT_URI);

                codeQianMi = HttpRequestLogic.GetHttpRequestInfo(CODE_AUTH_URL + parameterAuth);
            }
            catch (Exception ex)
            {
                //返回授权码的重置登录页面而已，没有实际作用
                ETong.Log.Sdk.LoggerMgr.GetLogger<Authorize>().ErrorExt("获取授权码时返回异常：" + ex);
            }

            return codeQianMi;
        }

        /// <summary>
        /// 获取AccessToken, RefreshToken
        /// </summary>
        public static string GetToken()
        {
            try
            {
                QianmiContext context = OAuthUtils.GetToken(APP_KEY, APP_SECRET, AUTHORIZE_CODE);

                return string.Format("{0},{1}", context.Token.AccessToken, context.Token.RefreshToken);
            }
            catch (Exception ex)
            {
                ETong.Log.Sdk.LoggerMgr.GetLogger<Authorize>().ErrorExt("获取token时返回异常：" + ex);
            }
            return string.Empty;
        }

        /// <summary>
        /// 刷新AccessToken, RefreshToken
        /// </summary>
        public static void RefreshToken()
        {
            try
            {
                QianmiContext context = OAuthUtils.RefreshToken(APP_KEY, APP_SECRET, REFRESH_TOKEN);

                var accessToken = context.Token.AccessToken;

                var refreshToken = context.Token.RefreshToken;
                UpdateToken(accessToken, refreshToken);
            }
            catch (Exception ex)
            {
                ETong.Log.Sdk.LoggerMgr.GetLogger<Authorize>().ErrorExt("刷新token时返回异常：" + ex); 
            }
        }

        private static void UpdateToken(string accessToken, string refreshToken)
        {
            File.WriteAllText(ConfigPath, accessToken + "," + refreshToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentToken()
        {
            string result = string.Empty;

            try
            {
                result = "AUTHORIZE_CODE:" + AUTHORIZE_CODE;
                result = ",ACCESS_TOKEN:" + ACCESS_TOKEN;
                result = ",REFRESH_TOKEN:" + REFRESH_TOKEN;
            }
            catch (Exception ex)
            {
                ETong.Log.Sdk.LoggerMgr.GetLogger<Authorize>().ErrorExt("读取text中当前token时返回异常：" + ex);
            }

            return result;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
