using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class OrderApiUtils
    {
        /// <summary>
        /// 查看订单详细
        /// </summary>
        public static JavaApiRespArgs<OrderInfoDatamap> QueryOrdersById(string orderId)
        {
            var url = Config.JavaApiUri + "orders/queryOrdersById";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;

            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    memberId = memberId,
                    orderId = orderId,
                }
            };
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, OrderInfoDatamap>(args, url, memberId, memberpwd);

            return result;
        }

    }
}
