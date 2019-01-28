using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Moblie
{

    /// <summary>
    /// 手机订单扩展信息
    /// </summary>
    public class MobileOrderExtend
    {
        /// <summary>
        /// 充值类型    	ExtCol01
        /// </summary>
        public string RechargeType { get; set; }
        /// <summary>
        /// 充值号码	    ExtCol02
        /// </summary>
        public string AccountNo { get; set; }
        /// <summary>
        /// 手机号码类型	ExtCol03
        /// </summary>
        public string MobileType { get; set; }
        /// <summary>
        /// 充值时间	    ExtCol04
        /// </summary>
        public string RechargeDate { get; set; }
        /// <summary>
        /// 充值金额	    ExtCol05
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 支付手续费	    ExtCol06
        /// </summary>
        public string PaymentFee { get; set; }
        /// <summary>
        /// 支付方式名   	ExtCol07
        /// </summary>
        public string PaymentConfigName { get; set; }
        /// <summary>
        /// 卡编码	        ExtCol08
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 卡值	        ExtCol09
        /// </summary>
        public string CardNum { get; set; }
        /// <summary>
        /// 赠送积分    	ExtCol10
        /// </summary>
        public string Integral { get; set; }
        /// <summary>
        /// 服务器提供商	ExtCol11
        /// </summary>
        public string Services { get; set; }
        /// <summary>
        /// 卡的成本价   	ExtCol12
        /// </summary>
        public string Cost_price { get; set; }
        /// <summary>
        /// 订单备注	    ExtCol13
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 手工操作记录	ExtCol14
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string ProviderName{ get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public string ProviderID { get; set; }
        /// <summary>
        /// 第三方订单号
        /// </summary>
        public string ThirdOrderId { get; set; }
    }
}
