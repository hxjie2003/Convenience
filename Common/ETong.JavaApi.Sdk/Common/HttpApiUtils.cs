using ETong.Utility.Log;
using ETong.Utility.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class HttpApiUtils
    {
        /// <summary>
        /// 输出日志以检查签名
        /// </summary>
        private static bool logForSignCheck = false;

        /// <summary>
        /// 请求java open接口
        /// </summary>
        /// <typeparam name="T">请求参数里的详细数据</typeparam>
        /// <typeparam name="Return">响应参数里的数据</typeparam>
        /// <param name="inputArgs">请求参数</param>
        /// <param name="requestUrl">请求地址</param>
        /// <returns></returns>
        public static string ReqJavaApiForJson<TArgDataMap>(JavaApiReqArgs<TArgDataMap> inputArgs, string requestUrl, string memberId, string memberPwd, int orderFrom = 1, string version = "v1")
        {
            //签名准备只用两层参数
            if (string.IsNullOrEmpty(inputArgs.reqTime))
            {
                inputArgs.reqTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            if (string.IsNullOrEmpty(inputArgs.version))
            {
                //inputArgs.version = "v1";
                inputArgs.version = version;
            }
            if (string.IsNullOrEmpty(inputArgs.reqFrom))
            {
                //inputArgs.reqFrom = "1";
                inputArgs.reqFrom = orderFrom.ToString();
            }

            string sign = string.Empty;

            SortedDictionary<string, string> bodySortDic = CaseSortedDictionary.Default;
            bodySortDic.Add("reqTime", inputArgs.reqTime);
            bodySortDic.Add("version", inputArgs.version);
            bodySortDic.Add("reqFrom", inputArgs.reqFrom);

            object temp;
            //string typeName = string.Empty;
            foreach (var p in inputArgs.dataMap.GetType().GetProperties())
            {
                temp = p.GetValue(inputArgs.dataMap);
                //typeName = p.PropertyType.Name.ToLower();
                if (temp is string || temp is int || temp is decimal || temp is double || temp is float || temp is short || temp is long)
                    bodySortDic.Add(p.Name, temp.ToString());
            }

            string formatedPassword = EncryptPwdForJavaApi(memberId, memberPwd, inputArgs.reqTime);

            sign = GenSignForJavaApi(bodySortDic, formatedPassword);

            inputArgs.sign = sign;

            string requestJson = Utility.Converts.Json.Serialize(inputArgs);
            if (logForSignCheck)
                ETong.Log.Sdk.LoggerMgr.Info(requestJson);

            var jsonResult = ETong.Utility.Comunication.HttpHelper.PostRest(requestUrl, requestJson);
            if (logForSignCheck)
                ETong.Log.Sdk.LoggerMgr.Info(jsonResult);

            var result = jsonResult;

            return result;
        }

        /// <summary>
        /// 请求java open接口
        /// </summary>
        /// <typeparam name="T">请求参数里的详细数据</typeparam>
        /// <typeparam name="Return">响应参数里的数据</typeparam>
        /// <param name="inputArgs">请求参数</param>
        /// <param name="requestUrl">请求地址</param>
        /// <returns></returns>
        public static JavaApiRespArgs<TReturn> ReqJavaApiForObj<TArgDataMap, TReturn>(JavaApiReqArgs<TArgDataMap> inputArgs, string requestUrl, string memberId, string memberPwd, int orderFrom = 1, string version = "")
        {
            var jsonResult = ReqJavaApiForJson<TArgDataMap>(inputArgs, requestUrl, memberId, memberPwd, orderFrom);

            JavaApiRespArgs<TReturn> result = default(JavaApiRespArgs<TReturn>);

            //先判断有无错误
            if (string.IsNullOrEmpty(jsonResult))
            {
                result.respMsg = "接口返回null";
            }
            else
            {
                result = Utility.Converts.Json.Deserialize<JavaApiRespArgs<TReturn>>(jsonResult);
            }

            return result;
        }

        /// <summary>
        /// 加密密码 - 访问java open plat
        /// 密码类传输过程中都需要加密，先AES128加密，再进行md5加密；AES128加密的密钥为会员ID (memberId) +请求时间(reqTime)的md5加密后的前16位
        /// </summary>
        /// <param name="password"></param>
        /// <param name="memberId"></param>
        /// <param name="tradeTime">yyyyMMddHHmmss</param>
        /// <returns></returns>
        private static string EncryptPwdForJavaApi(string memberId, string password, string tradeTime)
        {
            //先AES128加密，再进行md5加密；AES128加密的密钥为会员ID (memberId) +请求时间(reqTime)的md5加密后的前16位
            string key = MD5.Encrypt(memberId + tradeTime);

            if (logForSignCheck)
                ETong.Log.Sdk.LoggerMgr.Debug((memberId + ", " + tradeTime) + "->KEY->PWD=" + key);

            key = key.Substring(0, 16);
            string encryptResult = AES.Encrypt(password, key);

            if (logForSignCheck)
                ETong.Log.Sdk.LoggerMgr.Debug("AES->PWD=" + encryptResult);

            encryptResult = MD5.Encrypt(encryptResult);

            if (logForSignCheck)
                ETong.Log.Sdk.LoggerMgr.Debug("MD5->PWD=" + encryptResult);

            return encryptResult;
        }

        /// <summary>
        /// 获取参数签名 - 访问java open plat
        /// </summary>
        /// <param name="dicParams">参数集合，不能包含签名sign字段</param>
        /// <param name="formatPassword">加密的会员登录密码</param>
        /// <returns></returns>
        private static string GenSignForJavaApi(IDictionary<string, string> dicParams, string formattedPassword)
        {
            if (!(dicParams is SortedDictionary<string, string>))
            {
                dicParams = new SortedDictionary<string, string>(dicParams, new CaseStringComparer());
            }

            StringBuilder sbParams = new StringBuilder();
            dicParams.Aggregate<KeyValuePair<string, string>, StringBuilder>(sbParams, (o, n) =>
            {
                if (!string.IsNullOrEmpty(n.Value)) o.Append(n.Key).Append("=").Append(n.Value).Append("&");
                return o;
            });

            if (sbParams.Length == 0)
                return string.Empty;
            else if (sbParams[sbParams.Length - 1] == '&')
                sbParams.Remove(sbParams.Length - 1, 1);

            string sign = string.Format("{0}{1}", sbParams.ToString(), formattedPassword);

            if (logForSignCheck)
                ETong.Log.Sdk.LoggerMgr.Debug("SOURCE->SIGN=" + sign);

            sign = MD5.Encrypt(sign);

            if (logForSignCheck)
                ETong.Log.Sdk.LoggerMgr.Debug("MD5->SIGN=" + sign);

            return sign;
        }

    }
}
