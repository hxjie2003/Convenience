using ETong.Coffee.Api.Logc;
using ETong.Common.Enum;
using ETong.Entity;
using ETong.Entity.Presentation.Coffee;
using ETong.Entity.Presentation.Order;
using ETong.Order.Core.Repository.Models;
using ETong.Utility.Log;
using ETong.WebApi.Server.Filters;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ETong.Coffee.Api.Controllers
{
    /// <summary>
    /// 现磨咖啡API
    /// </summary>
    [SignValidateActionFilter()]
    public class CoffeeController : ApiController
    {
        /// <summary>
        /// </summary>
        public const string Version = "v3";        

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="ord">提交订单入参</param>
        /// <returns>提交顶结果</returns>
        [HttpPost]
        [Route("api/Coffee/OrderPost")]
        public OrderGroupResult OrderPost([FromBody]CoffeeOrder ord)
        {
            var result = new OrderGroupResult() { };
            Logger.Write(Log.Log_Type.Info, "Create Order:" + JsonConvert.SerializeObject(ord));
            try
            {
                var logc = new CoffeeLogc();
                result = logc.CreateOrder(ord);
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Error, ex.ToString());
                throw ex;
            };
            return result;
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="groupId">订单号</param>
        /// <returns>订单详情返回</returns>
        [HttpGet]
        [Route("api/Coffee/GetOrderDetail")]
        public ResponseData<CoffeeOrder> GetOrderDetail(string groupId)
        {
            var result = new ResponseData<CoffeeOrder> { };
            Logger.Write(Log.Log_Type.Info, "Get Order detail:groupId=" + groupId);
            try
            {
                var logc = new CoffeeLogc();
                result = logc.GetOrderDetail(groupId);
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Error, ex.ToString());
                throw ex;
            };
            return result;
        }
        /// <summary>
        /// 支付回调
        /// </summary>
        /// <param name="groupId">订单号</param>
        /// <returns>回调结果</returns>
        [HttpPost]
        [Route("api/Coffee/PayCallback")]
        public ResponseData<string> PayCallback([FromBody] string groupId)
        {
            var result = new ResponseData<string> { };
            string orderId = groupId;
            Logger.Write(Log.Log_Type.Info, "支付回调:orderId=" + orderId);
            try
            {
                var logc = new CoffeeLogc();
                result = logc.PayCallback(orderId);
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Error, ex.ToString());
                throw ex;
            };
            return result;
        }
        /// <summary>
        /// 完成回调
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Coffee/FinishCallBack")]
        public ResponseData<string> FinishCallBack([FromBody] string groupId)
        {
            var result = new ResponseData<string> { };
            string orderId = groupId;
            Logger.Write(Log.Log_Type.Info, "完成回调:orderId=" + orderId);
            try
            {
                var logc = new CoffeeLogc();
                result = logc.FinishCallBack(orderId);
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Error, ex.ToString());
                result.Data = ex.Message;
                result.Message = ex.Message;
                result.Success = false;
                //throw ex;
            };
            return result;
        }

        /// <summary>
        /// 会员中心信息 订单详情
        /// </summary>
        /// <param name="groupId">订单号</param>
        /// <returns>订单详情返回</returns>
        [HttpGet]
        [Route("api/Coffee/MemberOrderDetail")]
        public MemberOrderShowInfo MemberOrderDetail(string groupId)
        {
            Logger.Write(Log.Log_Type.Info, "Get member Order detail:groupId=" + groupId);            
            MemberOrderShowInfo result = new MemberOrderShowInfo()
            {
                OrderDetailShowInfo = new List<MemberOrderShowInfoItem>(),
                OrderShowInfo = new List<MemberOrderShowInfoItem>()
            };
            try
            {
                var logc = new CoffeeLogc();
                result = logc.MemberOrderDetail(groupId);
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Error, ex.ToString());
                throw ex;
            };
            return result;         
        }
        /// <summary>
        /// 制作饮品回调
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Coffee/MakeCallBack")]
        public ResponseData<string> MakeCallBack([FromBody]MakeDrinkReq req)
        {
            Logger.Write(Log.Log_Type.Info, " MakeCallBack detail:MakeDrinkReq=" + JsonConvert.SerializeObject(req));    
            var result = new ResponseData<string> { };
            try
            {
                var logc = new CoffeeLogc();
                result = logc.MakeCallBack(req);
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Error, ex.ToString());
                throw ex;                
            }
            return result;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="EtmID"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseData<string> SendSms([FromBody]string EtmID)
        {
            Logger.Write(Log.Log_Type.Info, "发送短信:EtmID=" + EtmID);
            var result = new ResponseData<string> { };            
            try
            {
                var logc = new CoffeeLogc();
                result = logc.SendSms(EtmID);
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Error, ex.ToString());
                throw ex;
            };
            return result;
        }
    }
}
