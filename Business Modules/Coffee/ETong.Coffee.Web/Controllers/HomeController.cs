using ETong.Common.Enum;
using ETong.Entity;
using ETong.Entity.Presentation.Coffee;
using ETong.Order.Core.Repository.Models;
using ETong.Utility.Log;
using ETong.Utility.Xml;
using ETong.WebApi.Client;
using ETong.WebApiUtility;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ETong.Coffee.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewData["backFromConfirm"] = "false";
            if (Request.UrlReferrer != null && Request.UrlReferrer.ToString().ToLower().Contains("/confirm"))
                ViewData["backFromConfirm"] = "true";
            return View();
        }

        public ActionResult ProductShow()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();            
        }

        public ActionResult Car()
        {
            return View();               
        }

        public ActionResult UpdateOrderStatus()
        {
            
            string OrderId = Request.QueryString["OrderId"];
            Logger.Write(Log.Log_Type.Info, string.Format("更新订单{0}", OrderId));
            if (!string.IsNullOrWhiteSpace(OrderId))
            {
                const string takedateUrl = "api/Coffee/FinishCallBack";
                var fullPath = ETong.Coffee.Web.Models.Config.GetApiFullPath(takedateUrl);
                var client = new HttpClientUtility(new Uri(fullPath));
                Logger.Write(Log.Log_Type.Info, string.Format("调用{0}", fullPath));
                var result = SecurityHttpClient.Post<string, ResponseData<string>>(fullPath, OrderId);
                Logger.Write(Log.Log_Type.Info, string.Format("{0}结束,result={1}", fullPath, Json(result.dataMap)));
                ViewData["pageData"] = result;
            }
            return View();               
        }

        /// <summary>
        /// 会员中心支付页面
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public ActionResult Pay(string groupId)
        {
            ViewData["backToPage"] = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : Url.Action("Index");
            ViewData["groupId"] = groupId;
            ViewData["OrderRes"] = GetOrder(groupId).Data;
            return View();
        }


        /// <summary>
        /// 获取订单
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public ResponseData<CoffeeOrder> GetOrder(string groupId)
        {

            string takedateUrl = string.Format("api/Coffee/GetOrderDetail?groupId={0}", groupId);
            var fullPath = ETong.Coffee.Web.Models.Config.GetApiFullPath(takedateUrl);
            var client = new HttpClientUtility(new Uri(fullPath));
            Logger.Write(Log.Log_Type.Info, string.Format("调用{0}", fullPath));
            var result = SecurityHttpClient.Get<ResponseData<CoffeeOrder>>(fullPath);
            Logger.Write(Log.Log_Type.Info, string.Format("{0}结束,result={1}", fullPath, Json(result.dataMap)));
            return result.dataMap;
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <param name="ord"></param>
        /// <returns></returns>
        [HttpPost]
        [EtmClientInfoFilter]
        public ActionResult OrderPost(CoffeeOrder ord)
        {            
            var clientInfo = this.TempData["ClientInfo"] as ClientInfo;
            ord.CreateIP = clientInfo.Ip;
            ord.OrderETMID = clientInfo.EtmCode;
            //ord.OrderETMID = "ETM0027";
            //ord.OrderFrom = 1;
            const string takedateUrl = "api/Coffee/OrderPost";
            var fullPath = ETong.Coffee.Web.Models.Config.GetApiFullPath(takedateUrl);
            var client = new HttpClientUtility(new Uri(fullPath));
            Logger.Write(Log.Log_Type.Info, string.Format("调用{0}", fullPath));
            var result = SecurityHttpClient.Post<CoffeeOrder, OrderGroupResult>(fullPath, ord);
            Logger.Write(Log.Log_Type.Info, string.Format("{0}结束,result={1}", fullPath, Json(result.dataMap)));
            return Json(result);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [EtmClientInfoFilter]
        public ActionResult Init()
        {
            var clientInfo = this.TempData["ClientInfo"] as ClientInfo;            
            string EtmID = clientInfo.EtmCode;
            //string EtmID = "ETM0027";
            var list = ObjectXmlSerializer.LoadFromXml<List<CoffeeInit>>(Server.MapPath("~/cache/Coffee.xml"));
            var result = list.Find(o => o.EtmID == EtmID);
            if (result == null)
            {
                var defaultResult = list.Find(o => o.EtmID == "ETMDefault");
                result = (CoffeeInit)Copy(defaultResult);
                result.EtmID = EtmID;
                result.DrinkList = null;                
                list.Add(result);
                ObjectXmlSerializer.SaveToXml<List<CoffeeInit>>(Server.MapPath("~/cache/Coffee.xml"), list);
            }
            result.DrinkList = list.Find(o => o.EtmID == "ETMDefault").DrinkList;            
            return this.Json(result); 
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [EtmClientInfoFilter]
        public ActionResult Rest()
        {
            var clientInfo = this.TempData["ClientInfo"] as ClientInfo;            
            string EtmID = clientInfo.EtmCode;
            //string EtmID = "ETM0027";
            var list = ObjectXmlSerializer.LoadFromXml<List<CoffeeInit>>(Server.MapPath("~/cache/Coffee.xml"));
            list.Find(o => o.EtmID == EtmID).SendSMS = "0";
            list.Find(o => o.EtmID == EtmID).CupNumber = list.Find(o => o.EtmID == "ETMDefault").CupNumber;
            ObjectXmlSerializer.SaveToXml<List<CoffeeInit>>(Server.MapPath("~/cache/Coffee.xml"), list);
            return this.Json(new { retCode = 0, Message = "" });
        }
        /// <summary>
        /// 减库存
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [EtmClientInfoFilter]
        public ActionResult LostCoffee(CoffeeInit req)
        {
            var clientInfo = this.TempData["ClientInfo"] as ClientInfo;            
            string EtmID = clientInfo.EtmCode;
            //string EtmID = "ETM0027";
            var list = ObjectXmlSerializer.LoadFromXml<List<CoffeeInit>>(Server.MapPath("~/cache/Coffee.xml"));
            if (list.Find(o => o.EtmID == EtmID).CupNumber < req.CupNumber)
                return this.Json(new { retCode = 1, Message = "提交失败，饮品剩余数量不足！" });
            list.Find(o => o.EtmID == EtmID).CupNumber -= req.CupNumber;
            //检测剩余杯数，发短信
            try
            {
                if (list.Find(o => o.EtmID == EtmID).CupNumber <= int.Parse(ConfigurationManager.AppSettings["EnableSmsCupNumber"]) && list.Find(o => o.EtmID == EtmID).SendSMS == "0" && ConfigurationManager.AppSettings["EnableSms"] == "true")
                {
                    list.Find(o => o.EtmID == EtmID).CupNumber = 1;
                    const string takedateUrl = "api/Coffee/SendSms";
                    var fullPath = ETong.Coffee.Web.Models.Config.GetApiFullPath(takedateUrl);
                    var client = new HttpClientUtility(new Uri(fullPath));
                    Logger.Write(Log.Log_Type.Info, string.Format("调用{0}", fullPath));
                    var resultT = SecurityHttpClient.Post<string, ResponseData<string>>(fullPath, EtmID);
                    Logger.Write(Log.Log_Type.Info, string.Format("{0}结束,result={1}", fullPath, Json(resultT.dataMap)));
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Log.Log_Type.Info, string.Format("短信发送失败etmid={0},err={1}", EtmID, ex.ToString()));
            }
            Logger.Write(Log.Log_Type.Info, string.Format("减库存etmid={0},CupNumber={1}", EtmID, req.CupNumber));
            ObjectXmlSerializer.SaveToXml<List<CoffeeInit>>(Server.MapPath("~/cache/Coffee.xml"), list);
            return this.Json(new { retCode = 0, Message = "成功" });
        }

        /// <summary>
        /// 支付回调
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PayCallback(string groupId)
        {
            const string takedateUrl = "api/Coffee/PayCallback";
            var fullPath = ETong.Coffee.Web.Models.Config.GetApiFullPath(takedateUrl);
            var client = new HttpClientUtility(new Uri(fullPath));
            Logger.Write(Log.Log_Type.Info, string.Format("调用{0}", fullPath));
            var result = SecurityHttpClient.Post<string, ResponseData<string>>(fullPath, groupId);
            Logger.Write(Log.Log_Type.Info, string.Format("{0}结束,result={1}", fullPath, Json(result.dataMap)));
            return Json(result.dataMap);
        }

        /// <summary>
        /// 制作饮品回调
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MakeCallBack(MakeDrinkReq req)
        {           
            const string takedateUrl = "api/Coffee/MakeCallBack";
            var fullPath = ETong.Coffee.Web.Models.Config.GetApiFullPath(takedateUrl);
            var client = new HttpClientUtility(new Uri(fullPath));
            Logger.Write(Log.Log_Type.Info, string.Format("调用{0}", fullPath));
            var result = SecurityHttpClient.Post<MakeDrinkReq, ResponseData<string>>(fullPath, req);
            Logger.Write(Log.Log_Type.Info, string.Format("{0}结束,result={1}", fullPath, Json(result.dataMap)));
            return Json(result);
        }

        /// <summary>
        /// 完成回调
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>        
        public ActionResult FinishCallBack(string groupId)
        {
            const string takedateUrl = "api/Coffee/FinishCallBack";
            var fullPath = ETong.Coffee.Web.Models.Config.GetApiFullPath(takedateUrl);
            var client = new HttpClientUtility(new Uri(fullPath));
            Logger.Write(Log.Log_Type.Info, string.Format("调用{0}", fullPath));
            var result = SecurityHttpClient.Post<string, ResponseData<string>>(fullPath, groupId);
            Logger.Write(Log.Log_Type.Info, string.Format("{0}结束,result={1}", fullPath, Json(result.dataMap)));
            return Json(result.dataMap);
        }

        /// <summary>
        /// 对像复制
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private object Copy(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();
            Object p = t.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);
            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    object value = pi.GetValue(o, null);
                    pi.SetValue(p, value, null);
                }
            }
            return p;
        }
    }
}