using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    /// <summary>
    /// 地区信息
    /// </summary>
    public class DistrictApiUtils
    {

        /// <summary>
        /// 查询全国省份
        /// </summary>
        public static string GetProvinces()
        {
            var url = Config.JavaApiUri + "product/template/freightTemplate/getAllArea";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;

            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    memberId = memberId,
                }
            };
            var result = HttpApiUtils.ReqJavaApiForJson<dynamic>(args, url, memberId, memberpwd);

            return result;
        }

    }
}
