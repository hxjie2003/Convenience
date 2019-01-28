using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{


    /// <summary>
    /// 航班响应信息
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Response
    {

        private byte statusField;

        private ResponseFlightData[] flightDatasField;

        /// <remarks/>
        public byte Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("FlightData", IsNullable = false)]
        public ResponseFlightData[] FlightDatas
        {
            get
            {
                return this.flightDatasField;
            }
            set
            {
                this.flightDatasField = value;
            }
        }
    }

    /// <summary>
    /// 航班数据
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseFlightData
    {

        private ResponseFlightDataCabinData[] cabinDatasField;

        private string departCityField;

        private System.DateTime departDateField;

        private string departTimeField;

        private byte mealField;

        private string carrierFlightNoField;

        private string arrivalCityField;

        private string arrivalTimeField;

        private string eTicketField;

        private string flightModelField;

        private string flyTimeField;

        private string flightNoField;

        private string airwaysField;

        private string departTerminalField;

        private string arrivalTerminalField;

        private decimal airConstructionFeeField;

        private byte stopOverField;

        private string otherCabinField;

        private object tXCabinDatasField;

        private decimal fuelTaxField;

        private object protocolNumField;

        private decimal standPriceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("CabinData", IsNullable = false)]
        public ResponseFlightDataCabinData[] CabinDatas
        {
            get
            {
                return this.cabinDatasField;
            }
            set
            {
                this.cabinDatasField = value;
            }
        }

        /// <remarks/>
        public string DepartCity
        {
            get
            {
                return this.departCityField;
            }
            set
            {
                this.departCityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime DepartDate
        {
            get
            {
                return this.departDateField;
            }
            set
            {
                this.departDateField = value;
            }
        }

        /// <remarks/>
        public string DepartTime
        {
            get
            {
                return this.departTimeField;
            }
            set
            {
                this.departTimeField = value;
            }
        }

        /// <remarks/>
        public byte Meal
        {
            get
            {
                return this.mealField;
            }
            set
            {
                this.mealField = value;
            }
        }

        /// <remarks/>
        public string CarrierFlightNo
        {
            get
            {
                return this.carrierFlightNoField;
            }
            set
            {
                this.carrierFlightNoField = value;
            }
        }

        /// <remarks/>
        public string ArrivalCity
        {
            get
            {
                return this.arrivalCityField;
            }
            set
            {
                this.arrivalCityField = value;
            }
        }

        /// <remarks/>
        public string ArrivalTime
        {
            get
            {
                return this.arrivalTimeField;
            }
            set
            {
                this.arrivalTimeField = value;
            }
        }

        /// <remarks/>
        public string ETicket
        {
            get
            {
                return this.eTicketField;
            }
            set
            {
                this.eTicketField = value;
            }
        }

        /// <remarks/>
        public string FlightModel
        {
            get
            {
                return this.flightModelField;
            }
            set
            {
                this.flightModelField = value;
            }
        }

        /// <remarks/>
        public string FlyTime
        {
            get
            {
                return this.flyTimeField;
            }
            set
            {
                this.flyTimeField = value;
            }
        }

        /// <remarks/>
        public string FlightNo
        {
            get
            {
                return this.flightNoField;
            }
            set
            {
                this.flightNoField = value;
            }
        }

        /// <remarks/>
        public string Airways
        {
            get
            {
                return this.airwaysField;
            }
            set
            {
                this.airwaysField = value;
            }
        }

        /// <remarks/>
        public string DepartTerminal
        {
            get
            {
                return this.departTerminalField;
            }
            set
            {
                this.departTerminalField = value;
            }
        }

        /// <remarks/>
        public string ArrivalTerminal
        {
            get
            {
                return this.arrivalTerminalField;
            }
            set
            {
                this.arrivalTerminalField = value;
            }
        }

        /// <remarks/>
        public decimal AirConstructionFee
        {
            get
            {
                return this.airConstructionFeeField;
            }
            set
            {
                this.airConstructionFeeField = value;
            }
        }

        /// <remarks/>
        public byte StopOver
        {
            get
            {
                return this.stopOverField;
            }
            set
            {
                this.stopOverField = value;
            }
        }

        /// <remarks/>
        public string OtherCabin
        {
            get
            {
                return this.otherCabinField;
            }
            set
            {
                this.otherCabinField = value;
            }
        }

        /// <remarks/>
        public object TXCabinDatas
        {
            get
            {
                return this.tXCabinDatasField;
            }
            set
            {
                this.tXCabinDatasField = value;
            }
        }

        /// <remarks/>
        public decimal FuelTax
        {
            get
            {
                return this.fuelTaxField;
            }
            set
            {
                this.fuelTaxField = value;
            }
        }

        /// <remarks/>
        public object ProtocolNum
        {
            get
            {
                return this.protocolNumField;
            }
            set
            {
                this.protocolNumField = value;
            }
        }

        /// <remarks/>
        public decimal StandPrice
        {
            get
            {
                return this.standPriceField;
            }
            set
            {
                this.standPriceField = value;
            }
        }
    }

    /// <summary>
    /// 航班舱位信息
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseFlightDataCabinData
    {

        private decimal aDTPriceField;

        private decimal aDTTaxField;

        private int aDTYqField;

        private string foreignRemarkField;

        private string cabinField;

        private int cabinTypeField;

        private string cabinNameField;

        private string rewardRatesField;

        private object hkForeignRemarkField;

        private object hkRewardRatesField;

        private decimal hkPriceField;

        private decimal hkCashBackField;

        private object hkPolicyIdField;

        private decimal hkDiscountField;

        private object hlForeignRemarkField;

        private object hlRewardRatesField;

        private decimal hlPriceField;

        private decimal hlCashBackField;

        private object hlLastSeatNumField;

        private object hlNoteField;

        private object hlPolicyIdField;

        private decimal hlDiscountField;

        private int isPublishTariffField;

        private decimal iNFPriceField;

        private decimal iNFTaxField;

        private decimal iNFYqField;

        private decimal jsPriceField;

        private decimal priceField;

        private decimal settlePriceField;

        private object isSpecialPolicyField;

        private decimal platStayMoneyField;

        private object platPolicyTypeField;

        private object platPolicyIdField;

        private object platPolicyRemarkField;

        private string platPolicyRewardRatesField;

        private string platOthField;
        private decimal commissionRatioField;
        private decimal cashBackField;

        private object teamForeignRemarkField;

        private object teamRewardRatesField;

        private decimal teamPriceField;

        private object teamPnrField;

        private decimal teamCashBackField;

        private object teamNoteField;

        private object teamPolicyIdField;

        private decimal teamDiscountField;

        private int teamLastSeatNumField;

        private object teamTotalSeatNumField;

        private string noteField;

        private string policyIdField;

        private decimal discountField;

        private string seatNumField;


        /// <summary>
        /// 儿童运价
        /// </summary>
        public decimal ADTPrice
        {
            get
            {
                return this.aDTPriceField;
            }
            set
            {
                this.aDTPriceField = value;
            }
        }



        /// <summary>
        /// 儿童基建
        /// </summary>
        public decimal ADTTax
        {
            get
            {
                return this.aDTTaxField;
            }
            set
            {
                this.aDTTaxField = value;
            }
        }

        /// <summary>
        /// 儿童燃油
        /// </summary>
        public int ADTYq
        {
            get
            {
                return this.aDTYqField;
            }
            set
            {
                this.aDTYqField = value;
            }
        }

        /// <summary>
        /// 销售说明
        /// </summary>
        public string ForeignRemark
        {
            get
            {
                return this.foreignRemarkField;
            }
            set
            {
                this.foreignRemarkField = value;
            }
        }

        /// <summary>
        /// 舱位代号，例如：Y（Y舱）
        /// </summary>
        public string Cabin
        {
            get
            {
                return this.cabinField;
            }
            set
            {
                this.cabinField = value;
            }
        }

        /// <summary>
        /// 舱位类型，格式：0 经济舱   1单程特价舱  2往返特价舱  3联程特价舱  4单程往返特价舱    5单程联程特价舱    6头等舱    7公务舱    8往返联程特价舱 9非销售舱位
        /// </summary>
        public int CabinType
        {
            get
            {
                return this.cabinTypeField;
            }
            set
            {
                this.cabinTypeField = value;
            }
        }

        /// <summary>
        /// 舱位名称，例如：经济舱全价
        /// </summary>
        public string CabinName
        {
            get
            {
                return this.cabinNameField;
            }
            set
            {
                this.cabinNameField = value;
            }
        }

        /// <summary>
        /// 奖励费率，格式：3%
        /// </summary>
        public string RewardRates
        {
            get
            {
                return this.rewardRatesField;
            }
            set
            {
                this.rewardRatesField = value;
            }
        }

        /// <summary>
        /// K位销售说明
        /// </summary>
        public object HkForeignRemark
        {
            get
            {
                return this.hkForeignRemarkField;
            }
            set
            {
                this.hkForeignRemarkField = value;
            }
        }

        /// <summary>
        /// K位奖励费率，格式：4%
        /// </summary>
        public object HkRewardRates
        {
            get
            {
                return this.hkRewardRatesField;
            }
            set
            {
                this.hkRewardRatesField = value;
            }
        }


        /// <summary>
        /// K位价格，格式：320（320元）如价格不等于0则表示是特殊产品-K位产品
        /// </summary>
        public decimal HkPrice
        {
            get
            {
                return this.hkPriceField;
            }
            set
            {
                this.hkPriceField = value;
            }
        }

        /// <summary>
        /// 匹配HK政策返现
        /// </summary>
        public decimal HkCashBack
        {
            get
            {
                return this.hkCashBackField;
            }
            set
            {
                this.hkCashBackField = value;
            }
        }

        /// <summary>
        /// 匹配K位政策，政策编号
        /// </summary>
        public object HkPolicyId
        {
            get
            {
                return this.hkPolicyIdField;
            }
            set
            {
                this.hkPolicyIdField = value;
            }
        }

        /// <summary>
        /// K位折扣，格式：0.6（60折）
        /// </summary>
        public decimal HkDiscount
        {
            get
            {
                return this.hkDiscountField;
            }
            set
            {
                this.hkDiscountField = value;
            }
        }


        /// <summary>
        /// HL销售说明
        /// </summary>
        public object HlForeignRemark
        {
            get
            {
                return this.hlForeignRemarkField;
            }
            set
            {
                this.hlForeignRemarkField = value;
            }
        }


        /// <summary>
        /// HL奖励费率，格式：5%
        /// </summary>
        public object HlRewardRates
        {
            get
            {
                return this.hlRewardRatesField;
            }
            set
            {
                this.hlRewardRatesField = value;
            }
        }

        /// <summary>
        /// HL价格，格式：320（320元）如价格不等于0则表示是特殊产品-HL产品
        /// </summary>
        public decimal HlPrice
        {
            get
            {
                return this.hlPriceField;
            }
            set
            {
                this.hlPriceField = value;
            }
        }

        /// <summary>
        /// 匹配HL政策返现
        /// </summary>
        public decimal HlCashBack
        {
            get
            {
                return this.hlCashBackField;
            }
            set
            {
                this.hlCashBackField = value;
            }
        }

        /// <summary>
        /// HL剩余座位数，格式：10
        /// </summary>
        public object HlLastSeatNum
        {
            get
            {
                return this.hlLastSeatNumField;
            }
            set
            {
                this.hlLastSeatNumField = value;
            }
        }

        /// <summary>
        /// HL退改签规定
        /// </summary>
        public object HlNote
        {
            get
            {
                return this.hlNoteField;
            }
            set
            {
                this.hlNoteField = value;
            }
        }

        /// <summary>
        /// 匹配HL政策，政策编号
        /// </summary>
        public object HlPolicyId
        {
            get
            {
                return this.hlPolicyIdField;
            }
            set
            {
                this.hlPolicyIdField = value;
            }
        }

        /// <summary>
        /// HL折扣，格式：0.6（60折）
        /// </summary>
        public decimal HlDiscount
        {
            get
            {
                return this.hlDiscountField;
            }
            set
            {
                this.hlDiscountField = value;
            }
        }

        /// <summary>
        /// 是否公布运价，0非公布运价，1公布运价
        /// </summary>
        public int IsPublishTariff
        {
            get
            {
                return this.isPublishTariffField;
            }
            set
            {
                this.isPublishTariffField = value;
            }
        }

        /// <summary>
        /// 婴儿运价
        /// </summary>
        public decimal INFPrice
        {
            get
            {
                return this.iNFPriceField;
            }
            set
            {
                this.iNFPriceField = value;
            }
        }

        /// <summary>
        /// 婴儿基建
        /// </summary>
        public decimal INFTax
        {
            get
            {
                return this.iNFTaxField;
            }
            set
            {
                this.iNFTaxField = value;
            }
        }

        /// <summary>
        /// 婴儿燃油
        /// </summary>
        public decimal INFYq
        {
            get
            {
                return this.iNFYqField;
            }
            set
            {
                this.iNFYqField = value;
            }
        }

        /// <summary>
        /// 结算价
        /// </summary>
        public decimal JsPrice
        {
            get
            {
                return this.jsPriceField;
            }
            set
            {
                this.jsPriceField = value;
            }
        }

        /// <summary>
        /// 第三方接口返回的票面价
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }


        /// <summary>
        /// 结算价
        /// </summary>
        public decimal SettlePrice
        {
            get
            {
                return this.settlePriceField;
            }
            set
            {
                this.settlePriceField = value;
            }
        }

        /// <summary>
        /// 是否特殊平台政策，0普通，1特殊
        /// </summary>
        public object IsSpecialPolicy
        {
            get
            {
                return this.isSpecialPolicyField;
            }
            set
            {
                this.isSpecialPolicyField = value;
            }
        }

        /// <summary>
        /// 服务费，格式：5（5元）
        /// </summary>
        public decimal PlatStayMoney
        {
            get
            {
                return this.platStayMoneyField;
            }
            set
            {
                this.platStayMoneyField = value;
            }
        }

        /// <summary>
        /// 平台类型
        /// </summary>
        public object PlatPolicyType
        {
            get
            {
                return this.platPolicyTypeField;
            }
            set
            {
                this.platPolicyTypeField = value;
            }
        }

        /// <summary>
        /// 匹配平台政策，政策编码
        /// </summary>
        public object PlatPolicyId
        {
            get
            {
                return this.platPolicyIdField;
            }
            set
            {
                this.platPolicyIdField = value;
            }
        }

        /// <summary>
        /// 平台政策退改签规定
        /// </summary>
        public object PlatPolicyRemark
        {
            get
            {
                return this.platPolicyRemarkField;
            }
            set
            {
                this.platPolicyRemarkField = value;
            }
        }

        /// <summary>
        /// 平台奖励费率，格式：7%
        /// </summary>
        public string PlatPolicyRewardRates
        {
            get
            {
                return this.platPolicyRewardRatesField;
            }
            set
            {
                this.platPolicyRewardRatesField = value;
            }
        }

        /// <summary>
        /// 预订接口[bookTicket]需要值
        /// </summary>
        public string PlatOth
        {
            get
            {
                return this.platOthField;
            }
            set
            {
                this.platOthField = value;
            }
        }
        /// <summary>
        /// 返佣比例，格式：0.1
        /// </summary>
        public decimal CommissionRatio
        {
            get
            {
                return this.commissionRatioField;
            }
            set
            {
                this.commissionRatioField = value;
            }
        }
        /// <summary>
        /// 返现金额，格式：5（5元）
        /// </summary>
        public decimal CashBack
        {
            get
            {
                return this.cashBackField;
            }
            set
            {
                this.cashBackField = value;
            }
        }

        /// <summary>
        /// 团队销售说明
        /// </summary>
        public object TeamForeignRemark
        {
            get
            {
                return this.teamForeignRemarkField;
            }
            set
            {
                this.teamForeignRemarkField = value;
            }
        }

        /// <summary>
        /// 团队奖励费率，格式：3%
        /// </summary>
        public object TeamRewardRates
        {
            get
            {
                return this.teamRewardRatesField;
            }
            set
            {
                this.teamRewardRatesField = value;
            }
        }

        /// <summary>
        /// 散充团队价格，格式：650（650元） 如价格不等于0则表示是特殊产品-散充团产品
        /// </summary>
        public decimal TeamPrice
        {
            get
            {
                return this.teamPriceField;
            }
            set
            {
                this.teamPriceField = value;
            }
        }

        /// <summary>
        /// 团队编码(PNR)
        /// </summary>
        public object TeamPnr
        {
            get
            {
                return this.teamPnrField;
            }
            set
            {
                this.teamPnrField = value;
            }
        }

        /// <summary>
        /// 匹配团队政策返现
        /// </summary>
        public decimal TeamCashBack
        {
            get
            {
                return this.teamCashBackField;
            }
            set
            {
                this.teamCashBackField = value;
            }
        }

        /// <summary>
        /// 团队退改签规定
        /// </summary>
        public object TeamNote
        {
            get
            {
                return this.teamNoteField;
            }
            set
            {
                this.teamNoteField = value;
            }
        }

        /// <summary>
        /// 匹配团队政策，政策编号
        /// </summary>
        public object TeamPolicyId
        {
            get
            {
                return this.teamPolicyIdField;
            }
            set
            {
                this.teamPolicyIdField = value;
            }
        }

        /// <summary>
        /// 团队舱位折扣，格式：0.6（60折）
        /// </summary>
        public decimal TeamDiscount
        {
            get
            {
                return this.teamDiscountField;
            }
            set
            {
                this.teamDiscountField = value;
            }
        }

        /// <summary>
        /// 团队剩余座位数，格式：23
        /// </summary>
        public int TeamLastSeatNum
        {
            get
            {
                return this.teamLastSeatNumField;
            }
            set
            {
                this.teamLastSeatNumField = value;
            }
        }

        /// <summary>
        /// 团队政策总共座位数，格式：50
        /// </summary>
        public object TeamTotalSeatNum
        {
            get
            {
                return this.teamTotalSeatNumField;
            }
            set
            {
                this.teamTotalSeatNumField = value;
            }
        }

        /// <summary>
        /// 退改签规定
        /// </summary>
        public string Note
        {
            get
            {
                return this.noteField;
            }
            set
            {
                this.noteField = value;
            }
        }

        /// <summary>
        /// 政策ID
        /// </summary>
        public string PolicyId
        {
            get
            {
                return this.policyIdField;
            }
            set
            {
                this.policyIdField = value;
            }
        }

        /// <summary>
        /// 舱位折扣，格式：0.8（80折）
        /// </summary>
        public decimal Discount
        {
            get
            {
                return this.discountField;
            }
            set
            {
                this.discountField = value;
            }
        }

        /// <summary>
        /// 舱位座位数，数据格式为，0至9、以及A（A代表9个座位以上）
        /// </summary>
        public string SeatNum
        {
            get
            {
                return this.seatNumField;
            }
            set
            {
                this.seatNumField = value;
            }
        }

      /// <summary>
        /// 政策的PID字段，用来获取到唯一ProductID
        /// </summary>
        public string PID { get; set; }

        /// <summary>
        /// 销售类型，见携程API文档
        /// </summary>
        public string SaleType { get; set; }
        
        /// <summary>
        /// 成人退改签
        /// </summary>
        public PolicyRule AdultRule { get; set; }

        /// <summary>
        /// 儿童退改签
        /// </summary>
        public PolicyRule ChildRule { get; set; }

        /// <summary>
        /// 退改签数据集
        /// </summary>
        public class PolicyRule
        {
            /// <summary>
            /// 规则索引
            /// </summary>
            public string Index { get; set; }

            /// <summary>
            /// 乘客类型
            /// </summary>
            public string TravelerCategory { get; set; }

            /// <summary>
            /// 退票规则
            /// </summary>
            public RuleEntity RefundRule { get; set; }

            /// <summary>
            /// 更改规则
            /// </summary>
            public RuleEntity ChangeRule { get; set; }

            /// <summary>
            /// 转签规则
            /// </summary>
            public RuleEntity EndorseRule { get; set; }

            /// <summary>
            /// 基建费用
            /// </summary>
            public decimal TAXfee { get; set; }

            /// <summary>
            /// 燃油附加费
            /// </summary>
            public decimal BAFfee { get; set; }
        }

        /// <summary>
        /// 退改签规则实体
        /// </summary>
        public class RuleEntity
        {
            /// <summary>
            /// 限制规则
            /// </summary>
            public string RuleRestriction { get; set; }

            /// <summary>
            /// 内容
            /// </summary>
            public string RuleNote { get; set; }

            /// <summary>
            /// 内容EN
            /// </summary>
            public string RuleNote_En { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            public string RuleRemarks { get; set; }

            /// <summary>
            /// 备注英文
            /// </summary>
            public string RuleRemarks_En { get; set; }
        }
    }



}
