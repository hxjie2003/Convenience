using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class AddFeeUtils
    {
        /// <summary>
        /// 手续费
        /// </summary>
        /// <returns></returns>
        public static double? GetAddFee(int orderFrom, int orderType, double fee)
        {
            string javafee_uri = Config.JavaApiUri + "business/fee/getFee/";
            string memberId = Config.JavaAnonymousMemberId;
            string memberPwd = Config.JavaAnonymousMemberPwd;

            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    memberId = memberId,
                    orderType = orderType.ToString(),
                    //providerCode = "P0004",
                    amount = fee.ToString()
                }
            };

            double? amount = null;//值为null,代表获取手续费失败
            try
            {
                var resp = HttpApiUtils.ReqJavaApiForObj<dynamic, AddFeeDatamap>(args, javafee_uri, memberId, memberPwd, orderFrom);
                amount = resp.dataMap.amount;//手续费可以负数
            }
            catch (Exception ex)
            {
                ETong.Log.Sdk.LoggerMgr.Error("获取手续费失败！", ex);
            }
            var result = amount;

            return result;
        }
    }
}
