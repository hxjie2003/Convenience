using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.PhoneBroadband
{
    /// <summary>
    /// 订单扩展项
    /// </summary>
    public class OrderExtend
    {
        /// <summary>
        /// 充值类型 	ExtCol01	//充值类型：0宽带充值、1固话充值。
        /// </summary>
        public string RechargeType { get; set; }
        /// <summary>
        ///运营商   	ExtCol02	//运营商：0联通、1电信。
        /// </summary>
        public string OperateShop { get; set; }
        /// <summary>
        ///充值账号	    ExtCol03	
        /// </summary>
        public string RechargeNumber { get; set; }
        /// <summary>
        ///充值金额  	ExtCol04
        /// </summary>
        public string RechargeAmount { get; set; }
        /// <summary>
        ///第三方订单号  ExtCol05
        /// </summary>
        public string ThridOrderId { get; set; }

        /// <summary>
        ///模拟欧飞单。值为："模拟"，"真实" ExtCol06
        /// </summary>
        public string Simulate { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public string Fee { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public string Amount { get; set; }
    }
}
