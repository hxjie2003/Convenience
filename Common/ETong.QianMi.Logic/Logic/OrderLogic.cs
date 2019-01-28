using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qianmi.Api;
using Qianmi.Api.Request;
using Qianmi.Api.Response;

namespace ETong.QianMi.Logic
{
    public class OrderLogic
    {

        /// <summary>
        /// 支付订单接口，充值订单下单完成，必须在30分钟内调用此接口，否则必须重新下单
        /// </summary>
        /// <param name="billId">订单编号</param>
        /// <returns>返回支付成功的订单详情</returns>
        public string PayBill(string billId)
        {
            string jsonResult = string.Empty;

            try
            {
                IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL, ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

                RechargeBasePayBillRequest req = new RechargeBasePayBillRequest();

                req.BillId = billId;

                RechargeBasePayBillResponse response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);

                if (!response.IsError)
                {
                    jsonResult = response.Body;
                }
            }
            catch (Exception ex)
            {

            }

            return jsonResult;        
        }

        /// <summary>
        /// 订单列表查询
        /// </summary>
        /// <param name="rechargeAccount">充值账号</param>
        /// <param name="pageNo">页码，从0开始</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="orderState">订单状态，1 成功 2 充值中 3 已撤销 4 未付款</param>
        /// <param name="orderTime">订单时间，按日查询或者按月查询，yyyy-MM或者yyyy-MM-dd</param>
        /// <returns></returns>
        public string GetOrderList(string rechargeAccount = "", string pageNo = "0", string pageSize = "100", string orderState = "0" , string orderTime = "2015-12-18")
        {
            string jsonResult = string.Empty;

            try
            {
                IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL, ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

                RechargeOrderListRequest req = new RechargeOrderListRequest();

                if (rechargeAccount != "")
                {
                    req.RechargeAccount = rechargeAccount;
                }

                if (pageNo != "")
                {
                    req.PageNo = pageNo;
                }

                req.PageSize = pageSize;

                if (rechargeAccount != "")
                {
                    req.RechargeAccount = rechargeAccount;
                }

                if (orderState != "")
                {
                    req.OrderState = orderState;
                }

                if (orderTime != "")
                {
                    req.OrderTime = orderTime;
                }

                RechargeOrderListResponse response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);

                if (!response.IsError)
                {
                    jsonResult = response.Body;
                }
            }
            catch (Exception ex)
            {

            }

            return jsonResult;    
        }

        /// <summary>
        /// 获取单笔订单详情
        /// </summary>
        /// <param name="billId">订单编号</param>
        /// <returns>单笔订单详情</returns>
        public string GetOrderDetail(string billId)
        {
            string jsonResult = string.Empty;

            try
            {
                IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL, ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

                RechargeOrderInfoRequest req = new RechargeOrderInfoRequest();
                req.BillId = billId;

                RechargeOrderInfoResponse response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);

                if (!response.IsError)
                {
                    jsonResult = response.Body;
                }
            }
            catch (Exception ex)
            {

            }

            return jsonResult;
        }
    }
}
