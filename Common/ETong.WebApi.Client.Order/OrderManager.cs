

using ETong.CoreOrder.Client.Model;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ETong.WebApi.Client.Order.Model;
using ETong.WebApi.Core;
using ETong.WebApi.Server.Core;
using ETong.WebApi.Server.Models;

namespace ETong.WebApi.Client.Order
{
    /// <summary>
    /// 主订单服务
    /// </summary>
    public class OrderManager
    {
        #region 公共方法及属性
        private readonly ILog _log;

        public OrderManager()
        {
            _log = LogManager.GetLogger(GetType());
        }


        #endregion

        #region 创建订单
        public ResponseInfo<CreateOrderOrderResult> CreateOrder(OrderInfo orderinfo)
        {
            _log.Debug("order data:" + JsonConvert.SerializeObject(orderinfo));
            ApiSetting setting = new ApiSetting(null);
            if (string.IsNullOrWhiteSpace(orderinfo.memberId))
            {
                orderinfo.memberId = setting.DefaultMemberId;
                orderinfo.memberName = "匿名用户";
            }
            var datmap = new CreateOrderDatamap() { memberId = orderinfo.memberId, orderList = new OrderInfo[] { orderinfo } };

            var response = SecurityHttpClient.Post<CreateOrderDatamap, CreateOrderOrderResult>(setting.JavaOrder_Uri + "generateOrder", datmap);
            if (response == null)
                throw new ApplicationException("调用java下单接口失败！");
            if (response.respCode != "0")
                throw new ApplicationException("调用java下单接口失败！" + response.respCode + "：" + response.respMsg);
            if (response.dataMap == null)
                throw new ApplicationException("调用java下单接口失败！返回数据为null");
            response.dataMap.orderId = response.dataMap.orderIds.First().Value;

            return response;
        }

        public ResponseInfo<CreateOrderOrderResult> CreateMallOrder(MallOrderInfos orderinfos)
        {
            _log.Debug("order data:" + JsonConvert.SerializeObject(orderinfos));
            var config = new ApiSetting(null);
            var response = SecurityHttpClient.Post<MallOrderInfos, CreateOrderOrderResult>(config.JavaOrder_Uri + "generateOrder", orderinfos);
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
            return response;
        }
        #endregion

        #region 完成订单
        public ResponseInfo<FinishOrderDatamap> Finish(string orderid, string memberid, string provideid)
        {
            FinishOrderInfo info = new FinishOrderInfo() { memberId = memberid, orderId = orderid, providerId = provideid };

            var config = new ApiSetting(null);
            var response = SecurityHttpClient.Post<FinishOrderInfo, FinishOrderDatamap>(config.JavaOrder_Uri + "finishedCall", info);
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
            return response;
        }
        #endregion

        #region 取消订单
        public ResponseInfo<CancelOrderDatamap> Cancel(string orderid, string memberid)
        {
            CancelOrderInfo info = new CancelOrderInfo() { memberId = memberid, orderId = orderid };
            ApiSetting setting = new ApiSetting(null);
            var response = SecurityHttpClient.Post<CancelOrderInfo, CancelOrderDatamap>(setting.JavaOrder_Uri + "cancel", info);
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
            return response;
        }
        #endregion

        #region 退款
        public ResponseInfo<RefundOrderDatamap> Refund(string orderid, string memberid)
        {
            RefundOrderInfo info = new RefundOrderInfo() { orderId = orderid };
            var config = new ApiSetting(null);
            var response = SecurityHttpClient.Post<RefundOrderInfo, RefundOrderDatamap>(config.JavaOrder_Uri + "orderStatusRefund", info);
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
            return response;

        }
        #endregion

        #region 查询会员订单列表
        public ResponseInfo<GetOrdersDatamap> Gets(GetOrdersCondition condition)
        {
            var config = new ApiSetting(null);
            var response = SecurityHttpClient.Post<GetOrdersCondition, GetOrdersDatamap>(config.JavaOrder_Uri + "queryOrders", condition);
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
            return response;
        }
        #endregion

        #region 查询会员订单详情
        public ResponseInfo<GetOrderDatamap> Get(string orderid, string memberid)
        {
            GetOrderCondition info = new GetOrderCondition() { memberId = memberid, orderId = orderid };
            var config = new ApiSetting(null);
            var response = SecurityHttpClient.Post<GetOrderCondition, GetOrderDatamap>(config.JavaOrder_Uri + "queryOrdersById", info);
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
            return response;
        }
        #endregion

        #region 获取转帐明细
        public ResponseInfo<TransferorderDatamap> GetTransferOrderDetail(string orderid, string memberid)
        {
            GetOrderCondition info = new GetOrderCondition() { memberId = memberid, orderId = orderid };
            var config = new ApiSetting(null);
            var response = SecurityHttpClient.Post<GetOrderCondition, TransferorderDatamap>(config.JavaOrder_Uri + "queryOrdersById", info);
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
            return response;
        }

        #endregion

        #region 更新供应商
        public ResponseInfo<UpdateProviderResopneBody> UpdateProvider(string orderid, string memberid, string providerid)
        {
            var info = new SendSupplierBody()
            {
                memberId = memberid,
                orderId = orderid,
                providerId = providerid
            };
            var config = new ApiSetting(null);
            var response = SecurityHttpClient.Post<SendSupplierBody, UpdateProviderResopneBody>(config.JavaOrder_Uri + "updateProviderId", info);
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
            return response;
        }
        #endregion

        #region 获取费用
        public ResponseInfo<FeeResponseDatamap> GetFee(string ordertype, string amount, string providerid, int orderfrom, string memberId = null)
        {
            var config = new ApiSetting(null);
            FeeRequestDatamap info = new FeeRequestDatamap() { orderType = ordertype, amount = amount, providerCode = providerid, memberId = memberId == null ? config.DefaultMemberId : memberId };


            var response = SecurityHttpClient.Post<FeeRequestDatamap, FeeResponseDatamap>(config.JavaFee_Uri, info, orderfrom.ToString(), "v1");
            switch (response.respCode)
            {
                case "CS00002":
                    throw new ErrorCodeException(response.respCode, "金额不能为空");
                case "CS00004":
                    throw new ErrorCodeException(response.respCode, "请求来源不能为空");
                case "CS00005":
                    throw new ErrorCodeException(response.respCode, "订单类型不能为空");
                case "00006":
                    throw new ErrorCodeException(response.respCode, "版本信息错误");
                case "00002":
                    throw new ErrorCodeException(response.respCode, "Java获取数据超时，请稍后重试！");
            }
            return response;
        }
        #endregion

        #region 发货

        public void HandleShip(string orderid,string memberid)
        {
            var config = new ApiSetting(null);
            HandleShipRequest info = new HandleShipRequest() { orderId = orderid,memberId = memberid};
            var response = SecurityHttpClient.Post<HandleShipRequest, HandleShipResponse>(config.JavaOrder_Uri + "convenShipping", info, "1", "v1");
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
        }

        #endregion

        #region 发货失败

        /// <summary>
        /// 通知发货失败
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <param name="memberid">会员号</param>
        /// <param name="errormessage">错误信息</param>
        /// <param name="isReverseFail">是否冲正失败</param>
        public void NotifyShipFail(string orderid, string memberid, string errormessage, bool isReverseFail)
        {
            var config = new ApiSetting(null);
            ShipFailRequest info = new ShipFailRequest() { orderId = orderid, memberId = memberid };
            info.orderSubStatus = "2";
            if (isReverseFail)
            {
                info.orderSubStatus = "3";
            }
            info.failReason = errormessage;
            var response = SecurityHttpClient.Post<ShipFailRequest, ShipFailResponse>(config.JavaOrder_Uri + "convenShippingFail", info, "1", "v1");
            if (response.respCode != "0")
                throw new ApplicationException(response.respMsg);
        }

        #endregion
    }
}