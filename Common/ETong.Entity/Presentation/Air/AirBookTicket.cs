// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AirBookTicket.cs" company="ETong">
//   提交机票的参数 / 第三方接口返回的参数
// </copyright>
// <summary>
//   Defines the AirBookTicket type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 预订机票提交的实体
    /// </summary>
    public class AirBookTicket
    {
        /// <summary>
        /// 航程类型：1单程，2往返程，3联程。往返程和联程需定同一航空公司的。
        /// </summary>
        public string legType { get; set; }

        /// <summary>
        /// 订单类型：1--普通订单，A—匹配 HL政策订单，默认为1
        /// </summary>
        public string orderType{ get; set; }

        /// <summary>
        /// 匹配本地政策ID，数据来源于航班查询接口[searchTicket]返回的PolicyId
        /// </summary>
        public string policyId{ get; set; }

        /// <summary>
        /// 联系人手机
        /// </summary>
        public string contactMobile{ get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string contactName{ get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        public string contactPhone{ get; set; }

        /// <summary>
        /// 预订字符串，数据来源于航班查询接口[searchTicket]返回的PlatOth，必传，往返机票任传一个      
        /// </summary>
        public string platOth{ get; set; }

        /// <summary>
        /// 航段, json数组字符串
        /// </summary>
        public string Legs { get; set; }

        /// <summary>
        /// 乘客, json数组字符串
        /// </summary>
        public string Passengers { get; set; }

        /// <summary>
        /// 提交的订单价格
        /// </summary>
        public string price { get; set; }
    }

    /// <summary>
    /// 第三方接口返回的预订信息
    /// </summary>
    public class AirBookTicketReponse
    {
        /// <summary>
        /// 生成订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 生成的PNR
        /// </summary>
        public string Pnrno { get; set; }

        /// <summary>
        /// 结算价
        /// </summary>
        public string JsPrice { get; set; }
    }
}
