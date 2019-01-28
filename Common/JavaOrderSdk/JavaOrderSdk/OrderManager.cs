using JavaOrderSdk.Members;
using JavaOrderSdk.Model;
using JavaOrderSdk.Tools;
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

namespace JavaOrderSdk
{
    public class OrderManager
    {
        private const string DateTimeFormat = "yyyyMMddHHmmss";
        private readonly ILog _log;

        public OrderManager()
        {
            _log = LogManager.GetLogger(GetType());
        }

        private string DefaultMemberId
        {
            get
            {
                var v = ConfigurationManager.AppSettings["javaorder_MemberId"];
                if (v == null)
                    throw new ApplicationException("javaorder_MemberId not set");
                return v;
            }
        }

        public string DefaultMemberPwd
        {
            get
            {
                var v = ConfigurationManager.AppSettings["javaorder_Password"];
                if (v == null)
                    throw new ApplicationException("javaorder_Password not set");
                return v;
            }
        }

        private string GetPassword(string memberid)
        {
            if (memberid.ToLower().Trim() == DefaultMemberId.ToLower().Trim())
            {
                return DefaultMemberPwd;
            }
            var member = new MemberContext().MEMBER.FirstOrDefault(o => o.MEMBER_ID == memberid);
            if (member == null)
                throw new Exception("不存在会员号:" + memberid);
            return member.PASSWD;
        }

        public CreateOrderResponse CreateOrder(OrderInfo orderinfo)
        {
            _log.Debug("order data:" + JsonConvert.SerializeObject(orderinfo));

            //orderinfo.memberId = "LM00013564";

            if (string.IsNullOrWhiteSpace(orderinfo.memberId))
            {
                orderinfo.memberId = DefaultMemberId;
                orderinfo.memberName = "匿名用户";
            }
            var password = GetPassword(orderinfo.memberId);

            var datetime = DateTime.Now;
            var datmap = new CreateOrderDatamap() { memberId = orderinfo.memberId, orderList = new OrderInfo[] { orderinfo } };

            var request = new CreateOrderRequest
            {
                dataMap = datmap,
                sign = BuildSign(datmap, datetime, password),
                reqTime = datetime.ToString(DateTimeFormat)
            };          
            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);
            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "generateOrder");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<CreateOrderResponse>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            obj.dataMap.orderId = obj.dataMap.orderIds.First().Value;
            return obj;
        }

        public CreateOrderResponse CreateMallOrder(MallOrderInfos orderinfos)
        {
            _log.Debug("order data:" + JsonConvert.SerializeObject(orderinfos));

            //orderinfo.memberId = "LM00013564";

            if (string.IsNullOrWhiteSpace(orderinfos.memberId))
            {
                orderinfos.memberId = DefaultMemberId;
            }
            var password = GetPassword(orderinfos.memberId);

            var datetime = DateTime.Now;

            var request = new CreateOrderMallRequest
            {
                dataMap = orderinfos,
                sign = BuildSign(orderinfos, datetime, password),
                reqTime = datetime.ToString(DateTimeFormat)
            };

            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);
            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "generateOrder");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<CreateOrderResponse>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            return obj;
        }

        public FinishOrderResponse Finish(string orderid, string memberid,string provideid)
        {
            FinishOrderInfo info = new FinishOrderInfo() { memberId = memberid, orderId = orderid ,providerId=provideid};
            string mid = memberid;
            if (string.IsNullOrWhiteSpace(mid))
                mid = DefaultMemberId;
            info.memberId = mid;
            var password = GetPassword(mid);
            var datetime = DateTime.Now;
            var request = new ConfirmOrderRequest
            {
                dataMap = info,
                sign = BuildSign(info, datetime, password),
                reqTime = datetime.ToString(DateTimeFormat)
            };
            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);

            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "finishedCall");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<FinishOrderResponse>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            return obj;

        }

        public CancelOrderResponse Cancel(string orderid, string memberid)
        {

            CancelOrderInfo info = new CancelOrderInfo() { memberId = memberid, orderId = orderid };
            string mid = memberid;
            if (string.IsNullOrWhiteSpace(mid))
                mid = DefaultMemberId;
            info.memberId = mid;
            var password = GetPassword(mid);
            var datetime = DateTime.Now;
            var request = new CancelOrderRequest
            {
                dataMap = info,
                sign = BuildSign(info, datetime, password),
                reqTime = datetime.ToString(DateTimeFormat)
            };

            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);
            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "cancel");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<CancelOrderResponse>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            return obj;

        }

        public RefundOrderResponse Refund(string orderid, string memberid)
        {

            RefundOrderInfo info = new RefundOrderInfo() {orderId = orderid };
            string mid = memberid;
            if (string.IsNullOrWhiteSpace(mid))
                mid = DefaultMemberId;           
            var password = GetPassword(mid);
            var datetime = DateTime.Now;
            var request = new RefundOrderRequest
            {
                dataMap = info,
                sign = "",//此接口不用签名验证
                reqTime = datetime.ToString(DateTimeFormat)
            };

            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);
            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "orderStatusRefund");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<RefundOrderResponse>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            return obj;

        }

        public GetOrdersResponse Gets(GetOrdersCondition condition)
        {
            string mid = condition.memberId;
            if (string.IsNullOrWhiteSpace(mid))
                mid = DefaultMemberId;

            var password = GetPassword(mid);
            var datetime = DateTime.Now;
            var request = new GetOrdersRequest
            {
                dataMap = condition,
                sign = BuildSign(condition, datetime, password),
                reqTime = datetime.ToString(DateTimeFormat)
            };

            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);
            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "queryOrders");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<GetOrdersResponse>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            return obj;


        }

        public GetOrderResponse Get(string orderid, string memberid)
        {
            GetOrderCondition info = new GetOrderCondition() { memberId = memberid, orderId = orderid };
            var password = GetPassword(info.memberId);
            var datetime = DateTime.Now;
            var request = new GetOrderRequest
            {
                dataMap = info,
                sign = BuildSign(info, datetime, password),
                reqTime = datetime.ToString(DateTimeFormat)
            };
            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);
            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "queryOrdersById");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<GetOrderResponse>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            return obj;
        }

        public GetTransferOrderResponse GetTransferOrderDetail(string orderid, string memberid)
        {
            GetOrderCondition info = new GetOrderCondition() { memberId = memberid, orderId = orderid };
            var password = GetPassword(info.memberId);
            var datetime = DateTime.Now;
            var request = new GetOrderRequest
            {
                dataMap = info,
                sign = BuildSign(info, datetime, password),
                reqTime = datetime.ToString(DateTimeFormat)
            };
            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);
            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "queryOrdersById");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<GetTransferOrderResponse>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            return obj;
        }


        public UpdateProviderRespone UpdateProvider(string orderid, string memberid, string providerid)
        {
                  var password = GetPassword(memberid);
            var datetime = DateTime.Now;
            var info=new SendSupplierBody()
            {
                 memberId=memberid,
                  orderId=orderid,
                  providerId=providerid
            };
            var request = new UpdateProvierRequest()
            {
                dataMap = info,
                sign = BuildSign(info, datetime, password),
                reqTime = datetime.ToString(DateTimeFormat)
            };

            var jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            var content = JsonConvert.SerializeObject(request, jSetting);
            _log.Debug("Post data:" + content);
            var config = new CommonConfig(null);

            var req = (HttpWebRequest)WebRequest.Create(config.JavaOrder_Uri + "updateProviderId");
            req.Method = "POST";
            req.ContentType = "Application/Json";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Timeout = 300000;
            // 如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
            //req.ServicePoint.Expect100Continue = false;
            WriteRequestData(req, content);
            var response = req.GetResponse();
            if (response == null)
            {
                throw new Exception("请求失败！");
            }
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("请求Stream为空！");
            }
            var sr = new StreamReader(stream, Encoding.UTF8);
            var retXml = sr.ReadToEnd();
            sr.Close();
            _log.Debug(retXml);
            var obj = JsonConvert.DeserializeObject<UpdateProviderRespone>(retXml);
            if (obj.respCode != "0")
                throw new ApplicationException(obj.respMsg);
            return obj;
 
        }



        private void WriteRequestData(HttpWebRequest request, string resultxml)
        {
            var data = Encoding.UTF8.GetBytes(resultxml);
            request.ContentLength = data.Length;
            var writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
        }

        private string BuildSign(object orderinfo, DateTime signTime, string password)
        {
            var values = new SortedList<string, object>();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(orderinfo))
            {
                var v = descriptor.GetValue(orderinfo);
                if (v != null)
                    //descriptor.SetValue(orderinfo, "empty");
                    values.Add(descriptor.Name, v);
            }
            var memberprodes = TypeDescriptor.GetProperties(orderinfo).Find("memberId", true);
            if (memberprodes == null)
                throw new Exception("不存在会员ID信息，无法创建签名！");
            string memberid = memberprodes.GetValue(orderinfo).ToString();
            var datetime = signTime.ToString(DateTimeFormat);
            values.Add("reqTime", datetime);
            //values.Add("", password);
            var stringtosign = string.Empty;
            var x = values.OrderBy(o => o.Key);
            foreach (var keyvaluepair in x)
            {
                if (keyvaluepair.Value is string)
                {
                    string value = "";
                    value = keyvaluepair.Value.ToString();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        if (!string.IsNullOrWhiteSpace(stringtosign))
                            stringtosign += "&";
                        stringtosign += keyvaluepair.Key + "=" + value;
                    }
                }
            }
            var encyptstring =
                MD5.Encrypt(AES.Encrypt(password, MD5.Encrypt(memberid + datetime).Substring(0, 16)));
            stringtosign += encyptstring;

            var sign = MD5.Encrypt(stringtosign);
            return sign;
        }
    }
}