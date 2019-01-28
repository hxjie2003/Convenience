//using ETong.Entity.Persistence.Shop;
using ETong.Utility.Converts;
//using ETong.WebApiUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace ETong.JavaApi.Sdk
{
    /// <summary>
    /// 自定义频道(商城)
    /// </summary>
    public class ChannelApiUtils
    {
        public static JavaApiRespArgs<ChannelDatamap> GetChannel(string channel)
        {
            string url = Config.JavaApiUri + "channel/channelMsg";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;
            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    requestFrom = 1,
                    code = channel,
                }
            };
            Log.Sdk.LoggerMgr.Info("请求参数=>" + ETong.Utility.Converts.Json.Serialize(args));
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, ChannelDatamap>(args, url, memberId, memberpwd);
            Log.Sdk.LoggerMgr.Info("返回结果=>" + result);

            return result;
        }

        public static JavaApiRespArgs<ChannelCategoryDatamap> GetTopCategory(string channel)
        {
            string url = Config.JavaApiUri + "channel/category/channelCategoryMsg";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;
            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    requestFrom = 1,
                    code = channel,
                }
            };
            Log.Sdk.LoggerMgr.Info("请求参数=>" + ETong.Utility.Converts.Json.Serialize(args));
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, ChannelCategoryDatamap>(args, url, memberId, memberpwd);
            Log.Sdk.LoggerMgr.Info("返回结果=>" + result);

            return result;
        }

        public static JavaApiRespArgs<ChannelCategoryDatamap> GetChildCategory(string parentId)
        {
            string url = Config.JavaApiUri + "channel/category/childCategoryMsg";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;
            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    requestFrom = 1,
                    categoryId = parentId,
                }
            };
            Log.Sdk.LoggerMgr.Info("请求参数=>" + ETong.Utility.Converts.Json.Serialize(args));
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, ChannelCategoryDatamap>(args, url, memberId, memberpwd);
            Log.Sdk.LoggerMgr.Info("返回结果=>" + result);

            return result;
        }

        public static JavaApiRespArgs<ChannelCategoryDatamap> GetAllChildCategory(string parentId)
        {
            string url = Config.JavaApiUri + "channel/category/allChildCategoryMsg";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;
            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    requestFrom = 1,
                    categoryId = parentId,
                }
            };
            Log.Sdk.LoggerMgr.Info("请求参数=>" + ETong.Utility.Converts.Json.Serialize(args));
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, ChannelCategoryDatamap>(args, url, memberId, memberpwd);
            Log.Sdk.LoggerMgr.Info("返回结果=>" + result);

            return result;
        }

        public static JavaApiRespArgs<ChannelGoodsListDatamap> GetCategoryGoods(string categoryId, int pageSize, int pageNo)
        {
            string url = Config.JavaApiUri + "channel/goods/categoryGoodsPage";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;
            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    requestFrom = 1,
                    categoryId = categoryId,
                    pageSize = pageSize,
                    curPage = pageNo
                }
            };
            Log.Sdk.LoggerMgr.Info("请求参数=>" + ETong.Utility.Converts.Json.Serialize(args));
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, ChannelGoodsListDatamap>(args, url, memberId, memberpwd);
            Log.Sdk.LoggerMgr.Info("返回结果=>" + result);

            return result;
        }

        public static JavaApiRespArgs<ChannelGoodsListDatamap> GetSearchGoods(string channel, string searchKeyword, int pageSize, int pageNo)
        {
            string url = Config.JavaApiUri + "channel/goods/searchGoodsPage";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;
            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    requestFrom = 1,
                    code = channel,
                    pageSize = pageSize,
                    curPage = pageNo,
                    searchParam = searchKeyword
                }
            };
            Log.Sdk.LoggerMgr.Info("请求参数=>" + ETong.Utility.Converts.Json.Serialize(args));
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, ChannelGoodsListDatamap>(args, url, memberId, memberpwd);
            Log.Sdk.LoggerMgr.Info("返回结果=>" + result);

            return result;
        }

        public static JavaApiRespArgs<ChannelGoodsListDatamap> GetIndexGoods(string channel, int pageSize, int pageNo)
        {
            string url = Config.JavaApiUri + "channel/goods/indexGoodsPage";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;
            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    requestFrom = 1,
                    code = channel,
                    pageSize = pageSize,
                    curPage = pageNo
                }
            };
            Log.Sdk.LoggerMgr.Info("请求参数=>" + ETong.Utility.Converts.Json.Serialize(args));
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, ChannelGoodsListDatamap>(args, url, memberId, memberpwd);
            Log.Sdk.LoggerMgr.Info("返回结果=>" + result);

            return result;
        }

        public static JavaApiRespArgs<ChannelGoodsDetailDatamap> GetGoodsDetail(string channel, string goodsId)
        {
            string url = Config.JavaApiUri + "product/common/queryGoodsDetail";
            var memberId = Config.JavaAnonymousMemberId;
            var memberpwd = Config.JavaAnonymousMemberPwd;
            var args = new JavaApiReqArgs<dynamic>()
            {
                dataMap = new
                {
                    channType = "5",//"频道类型Id"(String类型,必填,2为农民兄弟,5为自定义频道)
                    code = channel,
                    goodsId = goodsId
                }
            };
            Log.Sdk.LoggerMgr.Info("请求参数=>" + ETong.Utility.Converts.Json.Serialize(args));
            var result = HttpApiUtils.ReqJavaApiForObj<dynamic, ChannelGoodsDetailDatamap>(args, url, memberId, memberpwd);
            Log.Sdk.LoggerMgr.Info("返回结果=>" + result);

            return result;
        }
    }
}