using ETong.Coffee.Api.Logc.EntityModels;
using ETong.Common.Enum;
using ETong.CoreOrder.Client.Model;
using ETong.Entity;
using ETong.Entity.Persistence.Message;
using ETong.Entity.Presentation.Coffee;
using ETong.Entity.Presentation.Order;
using ETong.Order.Core.Repository.Models;
using ETong.Utility.Log;
using ETong.Utility.Message;
using ETong.Utility.Xml;
using ETong.WebApi.Client.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Coffee.Api.Logc
{
    public class CoffeeLogc
    {
         private int OrderType
         {
             get { return 24; }
         }
         private OrderStoreInfo GetStoreInfo()
         {
             var StoreInfo = new OrderStoreInfo();
             StoreInfo.StoreName = "咖啡饮品";
             StoreInfo.StoreId = "BM00000024";
             return StoreInfo;
         }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="ord"></param>
        /// <returns></returns>
        public OrderGroupResult CreateOrder(CoffeeOrder ord)
        {            
            if (ord == null)
                throw new ArgumentNullException("order");
            var s = new OrderManager();
            string orderDescribe = "";
            //验证产品单价
            var list = ObjectXmlSerializer.LoadFromXml<List<CoffeeInit>>(System.Web.HttpContext.Current.Server.MapPath("~/cache/Coffee.xml"));
            var ordDetails = ord.DrinkList.GroupBy(o => o.Value).Select(o => (new Drink()
            {
                Name = o.Min(item => item.Name),
                Value = o.Key,
                Number = o.Sum(item => item.Number),
                Price = o.Sum(item => item.Number * item.Price),
                Materials = null                
            }));            
            foreach (var item in ordDetails)
            {
                if (item.Price != list[0].DrinkList.Find(o => o.Value == item.Value).Price * item.Number)
                    throw new Exception("产品单价有误！");
                orderDescribe = orderDescribe == "" ? orderDescribe : orderDescribe + "@#";
                orderDescribe += String.Format("名称:{0}@#金额:{1}元@#数量:{2}", item.Name, item.Price, item.Number);
            }
            //验证订单金额金额
            if (ord.TotalAmount != ord.DrinkList.Sum(o => o.Price * o.Number) + ord.Fee)
                throw new Exception("订单金额有误！");
            var orderinfo = new OrderInfo
            {
                memberId = ord.MemberId,
                message = "",
                orderAmount = ord.Amount.ToString(CultureInfo.InvariantCulture),
                orderDescribe = orderDescribe,
                orderFrom = ord.OrderFrom.ToString(),
                orderType = OrderType.ToString(),
                storeId = this.GetStoreInfo().StoreId,
                storeName = this.GetStoreInfo().StoreName,
                totalAmount = (ord.TotalAmount).ToString(CultureInfo.InvariantCulture),
                orderEtm = ord.OrderETMID,
                deleiveryFee = ord.Fee,
                memberName = ord.MemberName
            };
            var mresult = s.CreateOrder(orderinfo);
            Logger.Write(Log.Log_Type.Info, string.Format("主订单创建成功，order={0}", JsonConvert.SerializeObject(mresult)));
            var context = new CoffeeOrderContext();
            for (int i = 0; i < ord.DrinkList.Count; i++)
            {
                var item = ord.DrinkList[i];
                var coffeeDetail = new BM_COFFEE_DETAIL()
                {
                    ORDER_ID = mresult.dataMap.orderId,
                    ID = mresult.dataMap.orderId + i.ToString(),
                    ADD_FEE = 0,
                    AMOUNT = item.Number * item.Price,
                    CAPACITY = item.Capacity,
                    COFFEE_TYPE = item.Value,
                    COFFEE_TYPENAME = item.Name,
                    CREATE_DATE = DateTime.Now,
                    PRICE = item.Price,
                    DESCRIPTION = "",
                    QUANTITY = item.Number,
                    TOTAL = item.Number * item.Price,
                    MATERIALS = JsonConvert.SerializeObject(item.Materials),
                    ISSUED = 0
                };
                Logger.Write(Log.Log_Type.Info, string.Format("订单详情，Detail={0}", JsonConvert.SerializeObject(coffeeDetail)));
                context.BM_COFFEE_DETAIL.Add(coffeeDetail);
            }   
            context.SaveChanges();
            OrderGroupResult result = new OrderGroupResult();
            result.GroupId = mresult.dataMap.orderId;
            result.Items = new List<OrderItemResult>();
            result.Items.Add(new OrderItemResult()
            {
                Amount = ord.TotalAmount,
                ItemName = orderinfo.orderDescribe,
                OrderId = mresult.dataMap.orderId,
                Qty = ord.Quantity,
                StoreId = orderinfo.storeId,
                StoreName = orderinfo.storeName               
            });
            result.TotalAmount = ord.TotalAmount;           
            return result;
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public ResponseData<CoffeeOrder> GetOrderDetail(string groupId)
        {
            var result = new ResponseData<CoffeeOrder>()
            {
                Code = "1",
                Data = null,
                Message = "",
                Success = false
            };
            if (groupId == null || groupId == "")
            {
                result.Message = "参数不能为空";
                return result;                
            }
            var context = new CoffeeOrderContext();
            var ord = context.PUB_ORDER.Where(o => o.ORDER_ID == groupId).FirstOrDefault();
            var ordDetail = context.BM_COFFEE_DETAIL.Where(o => o.ORDER_ID == groupId).ToList();
            if (ord == null || ordDetail == null || ordDetail.Count<=0)
            {
                result.Message = "未找到订单信息";
                return result; 
            }
            result.Data = new CoffeeOrder()
            {
                Amount = (decimal)ord.ORDER_AMOUNT,
                CreateIP = ord.CREATOR_IP,
                Fee = (decimal)ord.DELIVERY_FEE,
                MemberId = ord.MEMBER_ID,
                MemberName = ord.MEMBER_NAME,
                OrderETMID = ord.ORDER_ETM,
                OrderFrom = ord.ORDER_FROM,
                TotalAmount = ord.TOTAL_AMOUNT,
                Quantity = (int)ordDetail.Sum(o => o.QUANTITY),
                DrinkList = ordDetail.GroupBy(o => o.COFFEE_TYPE).Select(o => (new Drink()
                {
                    Name = o.Min(item => item.COFFEE_TYPENAME),
                    Value = o.Key,
                    Number = o.Sum(item => (int)item.QUANTITY),
                    Price = o.Min(item => (int)item.PRICE),
                    Materials = null
                })).ToList()
            };
            result.Success = true;
            result.Code = "0";
            return result;
        }

        /// <summary>
        /// 制作饮品回调
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ResponseData<string> MakeCallBack(MakeDrinkReq req)
        {
            var result = new ResponseData<string> {
                Code = "0",
                Data = "成功",
                Message = "成功",
                Success = true
            };
            var context = new CoffeeOrderContext();           
            var materials = JsonConvert.SerializeObject(req.Drink.Materials);
            var ordDetail = context.BM_COFFEE_DETAIL.Where(o => o.ORDER_ID == req.OrderId && o.COFFEE_TYPE == req.Drink.Value && o.MATERIALS == materials).FirstOrDefault(); 
            ordDetail.ISSUED += req.Drink.Number;           
            context.SaveChanges();
            //判断是否已出完咖啡
            var ordDetailList = context.BM_COFFEE_DETAIL.Where(o => o.ORDER_ID == req.OrderId).ToList();
            if (ordDetailList.Sum(o => o.QUANTITY) == ordDetailList.Sum(o=>o.ISSUED))            
            {
                FinishCallBack(req.OrderId);
            }
            return result;
        }
        

        /// <summary>
        /// 支付回调
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public ResponseData<string> PayCallback(string OrderID)
        {
            var result = new ResponseData<string>()
            {
                Code = "0",
                Data = "失败",
                Message = "订单未支付，请先支付",
                Success = true
            };
            //先做支付验证
            if (!VerifyOrder(OrderID))
            {

                Logger.Write(Log.Log_Type.Info, string.Format("订单验证不通过!,未支付订单，OrderId的值为:{0}。", OrderID));                
                throw new Exception("订单未支付，请先支付！");
                //未通过支付验证
                return result;
            }
            var context = new CoffeeOrderContext();
            var ord = context.PUB_ORDER.Where(o => o.ORDER_ID == OrderID).FirstOrDefault();
            Logger.Write(Log.Log_Type.Info, string.Format("开始更新订单状态--  订单号：{0}，{1},{2}。", OrderID, ord.MEMBER_ID, ord.PROVIDER_ID));    
            OrderManager manager = new OrderManager();
            //开始发货
            manager.HandleShip(OrderID, ord.MEMBER_ID);
            Logger.Write(Log.Log_Type.Info, string.Format("发货中，OrderId的值为:{0}。", OrderID));

            result = new ResponseData<string>()
            {
                Code = "1",
                Data = "成功",
                Message = "成功",
                Success = true
            };
            return result;
        }

        /// <summary>
        /// 完成回调
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public ResponseData<string> FinishCallBack(string OrderID)
        {
            var context = new CoffeeOrderContext();
            var ord = context.PUB_ORDER.Where(o => o.ORDER_ID == OrderID && o.ORDER_TYPE == 24).FirstOrDefault();
            Logger.Write(Log.Log_Type.Info, string.Format("开始更新订单状态--  订单号：{0}，{1},{2}。", OrderID, ord.MEMBER_ID, ord.PROVIDER_ID));
            OrderManager manager = new OrderManager();
            manager.Finish(OrderID, ord.MEMBER_ID, ord.PROVIDER_ID);
            var result = new ResponseData<string>()
            {
                Code = "1",
                Data = "成功",
                Message = "成功",
                Success = true
            };
            return result;
        }

        /// <summary>
        /// 会员中心信息 订单详情
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public MemberOrderShowInfo MemberOrderDetail(string groupId)
        {
            MemberOrderShowInfo result = new MemberOrderShowInfo()
            {
                OrderDetailShowInfo = new List<MemberOrderShowInfoItem>(),
                OrderShowInfo = new List<MemberOrderShowInfoItem>()
            };
            var context = new CoffeeOrderContext();
            var ord = context.PUB_ORDER.Where(o => o.ORDER_ID == groupId).FirstOrDefault();
            var ordDetail = context.BM_COFFEE_DETAIL.Where(o => o.ORDER_ID == groupId).ToList();
            if (ord == null || ordDetail == null || ordDetail.Count<=0)
            {
                Logger.Write(Log.Log_Type.Debug, string.Format("没有找到订单详情--  订单号：{0}。", groupId));
                return null;
            }
            //订单信息
            result.OrderShowInfo.Add(new MemberOrderShowInfoItem() { Name = "订单编号", Value = ord.ORDER_ID });
            result.OrderShowInfo.Add(new MemberOrderShowInfoItem() { Name = "下单时间", Value = ord.CREATE_DATE.ToString("yyyy年MM月dd日 HH:mm:ss") });
            result.OrderShowInfo.Add(new MemberOrderShowInfoItem() { Name = "订单金额", Value = ord.TOTAL_AMOUNT.ToString("F2") + "元" });
            result.OrderShowInfo.Add(new MemberOrderShowInfoItem() { Name = "订单名称", Value = GetStoreInfo().StoreName });
            result.OrderShowInfo.Add(new MemberOrderShowInfoItem() { Name = "订单数量", Value = ordDetail.Sum(o => o.QUANTITY).ToString() });
            //订单明细
            foreach (var item in ordDetail.GroupBy(o => o.COFFEE_TYPE).Select(o => (new Drink()
                                                                                    {
                                                                                        Name = o.Min(item => item.COFFEE_TYPENAME),
                                                                                        Value = o.Key,
                                                                                        Number = o.Sum(item => (int)item.QUANTITY),
                                                                                        Price = o.Min(item => (int)item.PRICE),
                                                                                        Materials = null
                                                                                    })).ToList())
            {
                result.OrderDetailShowInfo.Add(new MemberOrderShowInfoItem() { Name = "名称", Value = item.Name + " " + item.Number.ToString() + "杯" });
                result.OrderDetailShowInfo.Add(new MemberOrderShowInfoItem() { Name = "单价", Value = item.Price.ToString("F2") + "元" });
                //result.OrderDetailShowInfo.Add(new MemberOrderShowInfoItem() { Name = "数量", Value = item.Number.ToString() });
                result.OrderDetailShowInfo.Add(new MemberOrderShowInfoItem() { Name = "金额", Value = (item.Price * item.Number).ToString("F2") + "元" });
            }                    
            return result;      
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="EtmID"></param>
        /// <returns></returns>
        public ResponseData<string> SendSms(string EtmID)
        {
            var context = new ETMContext();
            var EtmInfo = context.ETM_BIZ_AGENT_DEALER_DRIVER.FirstOrDefault(o => o.DRIVER_ID == EtmID);
            if (EtmInfo == null)
            {
                Logger.Write(Log.Log_Type.Debug, string.Format("没有找到ETM信息--  EtmID：{0}。", EtmID));
                return null;                
            }
            var smsContent = string.Format(ConfigurationManager.AppSettings["SmsMessage"], EtmID, EtmInfo.ADDRESS_PROVINCE + EtmInfo.ADDRESS_CITY + EtmInfo.ADDRESS_AREA + EtmInfo.ADDRESS_LOCATION);
            Logger.Write(Log.Log_Type.Info, string.Format("发送SMS：{0}。", smsContent));
            SendSms(smsContent, EtmInfo.CONTACT_MOBILE);
            var result = new ResponseData<string>()
            {
                Code = "0",
                Data = "已发送",
                Message = "已发送",
                Success = true
            };
            return result;
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="smsContent"></param>
        /// <param name="Mobile"></param>
        private void SendSms(string smsContent, string Mobile)
        {
            Logger.Write(Log.Log_Type.Debug,"发送SMS");
            if (smsContent == null || Mobile==null)
                throw new ArgumentNullException("smsContent");
            try
            {
                var s = new SmsClient();
                var argsu = new SmsMessageArgs
                {
                    Content = smsContent,
                    Mobiles = Mobile,
                };
                var result = s.SendSms(argsu);
                if (result == null)
                {
                    throw new ArgumentNullException("发送失败，返回空数据");                    
                }
                if (!result.Success)
                    throw new ArgumentNullException(result.Code, result.Message);
                Logger.Write(Log.Log_Type.Debug, "发送SMS success");                
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Debug, "发送sms失败"); 
            }
        }


        /// <summary>
        /// 验证订单支付状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        private bool VerifyOrder(string orderId)
        {
            var te = new CoffeeOrderContext();
            return te.PUB_ORDER.Any(o => o.ORDER_ID == orderId && o.PAYMENT_STATUS == 2);
        }
    }
}
