using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{

    /// <summary>
    /// 订单明细
    /// </summary>
    public class ThirdAirOrderInfo
    {
        #region
        /*
             * 参数名                      字段类型    长度   是否必填    说明  
                LegType                    String      1      Y           航程类型：1单程，2往返程，3联程。往返程和联程需定同一航空公司的。
                OrderType                  String      1      Y           订单类型：1--普通订单，A—匹配 HL政策订单，默认为1
                PolicyId                   String      60     N           匹配本地政策ID，数据来源于航班查询接口[searchTicket]返回的PolicyId
                ContactMobile              String      60     Y           联系人手机
                ContactName                String      200    Y           联系人姓名
                ContactPhone               String      60     Y           联系人电话
                PlatOth                    String             Y           预订字符串，数据来源于航班查询接口[searchTicket]返回的PlatOth，必传，往返机票任传一个      
                Legs                       String                         航段, json数组字符串
                Passengers                 String                         乘客, json数组字符串 
             
                Qty                        int                Y           乘客人数
              
                orderId                    String             Y           易通的订单编号
                
                航段信息说明
                DepDate                    String      10     Y           出发日期，例如：2013-01-05
                DepCity                    String      10     Y           出发城市，城市三字码，例如：XIY
                ArrCity                    String      10     Y           到达城市，城市三字码，例如：WUH
                DepTime                    String      20     Y           出发时间，例如：07:30
                ArrTime                    String      20     Y           到达时间，例如：20:45
                FlightNo                   String      20     Y           航班号，例如：CA2310；带*号为共享航班号 ，例如：*MU2013
                Cabin                      String      10     Y           舱位，例如：Y（Y舱）
                Discount                   String             Y           舱位折扣，例如：0.6（60折）
                FlightMod                  String      10     N           飞机机型，例如：747
             
                TicketPrice                                               机票价格
                FuelTax                                                   燃油附加税
                ConstructionFee                                           机场建设费
                RewardRates                decimal                        奖励费率, 百分号前的数字 

                乘客信息说明
                PassenType                 String      1      Y           乘机人类型，1成人，2儿童，3婴儿
                Name                       String      60     Y           乘机人姓名
                Sex                        String      2      N           性别，M男，F 女，默认M 
                DocType                    String      30                 证件类型，NI身份证，P护照，NI其他证件
                DocName                    String      30                 证件号码，成人必传，其他可不传 
                MobileNum                  String      60                 手机号码 
             */
        #endregion

        /// <summary>
        ///  航程类型：1单程，2往返程，3联程。往返程和联程需定同一航空公司的。
        /// </summary>
        public string LegType { get; set; }
        /// <summary>
        ///  订单类型：1--普通订单，A—匹配 HL政策订单，默认为1
        /// </summary>
        public string OrderType { get; set; }
        /// <summary>
        ///  匹配本地政策ID，数据来源于航班查询接口[searchTicket]返回的PolicyId
        /// </summary>
        public string PolicyId { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string ContactMobile { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 预订字符串，数据来源于航班查询接口[searchTicket]返回的PlatOth，必传，往返机票任传一个
        /// </summary>
        public string PlatOth { get; set; }
        /// <summary>
        /// 航段, json数组字符串
        /// </summary>
        public string LegsString { get; set; }
        /// <summary>
        /// 乘客, json数组字符串 
        /// </summary>
        public string PassengersString { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 乘客人数
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 易通的订单编号
        /// </summary>
        public string OrderId { get; set; }
    }
}
