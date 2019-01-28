// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AirlineTicketInfo.cs" company="ETong">
//   机票信息
// </copyright>
// <summary>
//   机票信息类
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 机票信息类
    /// </summary>
    public class AirlineTicketInfo
    {
        /// <summary>
        /// 第三方订单号
        /// </summary>
        public string ThirdPartyOrderId { get; set; }

        /// <summary>
        /// 航班号
        /// </summary>
        public string FligthNo { get; set; }

        /// <summary>
        /// 航程类型
        /// </summary>
        public string VoyageType { get; set; }

        /// <summary>
        /// 起飞城市
        /// </summary>
        public string TakeOffCity { get; set; }

        /// <summary>
        /// 起飞时间
        /// </summary>
        public string TakeOffTime { get; set; }

        /// <summary>
        /// 降落城市
        /// </summary>
        public string LandingCity { get; set; }

        /// <summary>
        /// 返程航班号
        /// </summary>
        public string ReturnFlightNo { get; set; }

        /// <summary>
        /// 返程起飞城市
        /// </summary>
        public string ReturnTakeOffCity { get; set; }

        /// <summary>
        /// 返程起飞时间
        /// </summary>
        public string ReturnTakeOffTime { get; set; }

        /// <summary>
        /// 返程降落城市
        /// </summary>
        public string ReturnLandingCity { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LinkmanName { get; set; }

        /// <summary>
        /// 联系人手机号
        /// </summary>
        public string LinkPhone { get; set; }

        /// <summary>
        /// 成本价(结算价)+机场建设费+燃油税
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// 第三方支付交易流水号
        /// </summary>
        public string payNo { get; set; }

        /// <summary>
        /// 易通订单支付状态
        /// </summary>
        public int ETPayStatus { get; set; }

        /// <summary>
        /// 获取订单的供应商
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// 是否已向供应商支付过
        /// </summary>
        public bool Pay2Provider { get; set; }

        /// <summary>
        /// 向供应商已支付的金额
        /// </summary>
        public decimal PayAmount { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberId { get; set; }
    }
}
