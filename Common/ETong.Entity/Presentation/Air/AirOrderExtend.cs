using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 机票订单信息。（扩展属性）
    /// </summary>
    public class AirOrderExtend
    {
        /// <summary>
        /// 机票订单号1
        /// </summary>
        public string OrderSn { get; set; }
        /// <summary>
        /// 航班号2
        /// </summary>
        public string FlightNo { get; set; }
        /// <summary>
        /// 航程类型3
        /// </summary>
        public string VoyageType { get; set; }
        /// <summary>
        /// 起飞城市4
        /// </summary>
        public string TakeOffCity { get; set; }
        /// <summary>
        /// 降落城市5
        /// </summary>
        public string LandingCity { get; set; }
        /// <summary>
        /// 起飞时间6
        /// </summary>
        public string TakeOffDate { get; set; }
        /// <summary>
        /// 降落时间7
        /// </summary>
        public string LandingDate { get; set; }
        /// <summary>
        /// 返程航班号8
        /// </summary>
        public string ReturnFlightNo { get; set; }
        /// <summary>
        /// 返程起飞城市9
        /// </summary>
        public string ReturnTakeOffCity { get; set; }
        /// <summary>
        /// 返程起飞时间10
        /// </summary>
        public string ReturnTakeOffDate { get; set; }
        /// <summary>
        /// 返程降落城市11
        /// </summary>
        public string ReturnLandingCity { get; set; }
        /// <summary>
        /// 返程降落时间12
        /// </summary>
        public string ReturnLandingDate { get; set; }
        /// <summary>
        /// 支付方式名称13
        /// </summary>
       // public string PaymentConfigName { get; set; }
        /// <summary>
        /// 联系人姓名14
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 电话15
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 备注16
        /// </summary>
       //public string Remarks { get; set; }
        /// <summary>
        /// 成本总价(元,成本价+机建费+燃油税)17
        /// </summary>
        public string TotalCost { get; set; }
        /// <summary>
        /// 返程保险公司25
        /// </summary>
        //public string ReturnInsuredCompany { get; set; }
        /// <summary>
        /// 返程舱位等级26
        /// </summary>
        //public string ReturnTicketClass { get; set; }
        /// <summary>
        /// 返程燃油附加费27
        /// </summary>
        //public string ReturnBaf { get; set; }
        /// <summary>
        /// 返程保险费用24
        /// </summary>
        //public string ReturnInsuredAmount { get; set; }
        /// <summary>
        /// 返程机票价格28
        /// </summary>
        //public string ReturnTicketPrice { get; set; }
        /// <summary>
        /// 返程发票抬头29
        /// </summary>
        //public string ReturnInvoiceTitle { get; set; }
        /// <summary>
        /// 折扣30
        /// </summary>
        //public string Discount { get; set; }
        /// <summary>
        /// 航空公司31
        /// </summary>
        public string AirwaysName { get; set; }
        /// <summary>
        /// 机型32 (开始是存了的，后面不存了，不知道原因EXT32：第三方订单提交必须)
        /// </summary>
        public string FlightModel { get; set; }
        /// <summary>
        /// 返程折扣33
        /// </summary>
        //public string ReturnDiscount { get; set; }
        /// <summary>
        /// 返程航空公司34
        /// </summary>
        public string ReturnAirwaysName { get; set; }

        /// <summary>
        /// 返程机型35
        /// </summary>
        public string ReturnFlightModel { get; set; }

        /// <summary>
        /// 保险费用18
        /// </summary>
        //public string InsuredAmount { get; set; }
        /// <summary>
        /// 保险公司19
        /// </summary>
        //public string InsuredCompany { get; set; }
        /// <summary>
        /// 舱位等级20
        /// </summary>
        //public string TicketClass { get; set; }
        /// <summary>
        /// 燃油附加费21
        /// </summary>
        //public string Baf { get; set; }
        /// <summary>
        /// 机票价格22
        /// </summary>
        //public string TicketPrice { get; set; }
        /// <summary>
        /// 发票抬头23
        /// </summary>
        //public string InvoiceTitle { get; set; }


        /// <summary>
        /// 当前舱位的所有信息
        /// </summary>
        public string AirData { get; set; }


        /// <summary>
        /// 供应商来源 40
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// 供应商ID For分润系统
        /// </summary>
        public string ProviderId { get; set; }
        /// <summary>
        /// 供应商名称 For分润系统
        /// </summary>
        public string ProviderName { get; set; }
    }
}
