using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    /// <summary>
    /// 运费模板
    /// </summary>
    public class FreightApiUtils
    {
        /// <summary>
        /// 获取默认的运费模板Id
        /// </summary>
        public static string GetDefaultTemplateId()
        {
            var url = Config.JavaApiUri + "product/template/freightTemplate/getDefaultTemplate";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;

            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    memberId = memberId,
                }
            };
            var freight = HttpApiUtils.ReqJavaApiForObj<dynamic, dynamic>(args, url, memberId, memberpwd);
            var result = freight.dataMap.result_key;

            return result;
        }

        /// <summary>
        /// 跟据模板、运送方式和省份计算最终的运费
        /// </summary>
        public static string GetDefaultTemplate()
        {
            var url = Config.JavaApiUri + "product/template/freightTemplate/getDefaultTemplate";
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

        /// <summary>
        /// 购物车中多个商品有多个模板时,查询运费最高的模板接口
        /// </summary>
        public static string GetTopFreightTemplate(string[] templateIds)
        {
            var url = Config.JavaApiUri + "product/template/freightTemplate/getTopFreightTemplate";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;

            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    memberId = memberId,
                    templateIds = templateIds
                }
            };
            var result = HttpApiUtils.ReqJavaApiForJson<dynamic>(args, url, memberId, memberpwd);

            return result;
        }

        /// <summary>
        /// 根据模板ID和城市名称(或城市的ID)查询快递方式列表
        /// </summary>
        public static string GetFreightTypeByTemplateIdAndArea(string goodsId, string templateId, string areaName)
        {
            var url = Config.JavaApiUri + "product/template/freightTemplate/getFreightTypeByTemplateIdAndArea";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;

            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    area = areaName,
                    memberId = memberId,
                    goodsId = goodsId,
                    templateId = templateId
                }
            };
            var result = HttpApiUtils.ReqJavaApiForJson<dynamic>(args, url, memberId, memberpwd);

            return result;
        }

        /// <summary>
        /// 最终的运费计算接口
        /// </summary>
        public static string CountTemplateCost(string templateId, string areaName, string freightTypeId)
        {
            var url = Config.JavaApiUri + "product/template/freightTemplate/countTemplateCost";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;

            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    memberId = memberId,
                    areaName = areaName,
                    freightTypeId = freightTypeId,
                    orderCount = 5,
                    templateId = templateId
                }
            };
            var result = HttpApiUtils.ReqJavaApiForJson<dynamic>(args, url, memberId, memberpwd);

            return result;
        }

        /// <summary>
        /// 跟据店铺信息列表得到每个店铺的运费信息
        /// </summary>
        /// <param name="orderStoreInfo"></param>
        /// <returns></returns>
        public static string CountTemplateOrder(string areaName, dynamic[] storeInfos)
        {
            var url = Config.JavaApiUri + "product/template/freightTemplate/countAllTemplateTypeCharge";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;

            var args = new JavaApiReqArgs<dynamic>()
            {                
                dataMap = new
                {
                    memberId = memberId,
                    areaName = areaName,
                    storeInfos = storeInfos
                }
            };
            var result = HttpApiUtils.ReqJavaApiForJson<dynamic>(args, url, memberId, memberpwd);

            return result;
        }

    }
}
