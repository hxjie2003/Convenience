using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Traffic
{
    /// <summary>
    /// 交通违章扩展项
    /// </summary>
    public class TrafficOrderExtend
    {
        /// <summary>
        /// 代办备注 	ExtCol01	
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        ///扩展字段   	ExtCol02	
        /// </summary>
        public string Feature { get; set; }
        /// <summary>
        ///车辆信息id	( 车牌号码)    ExtCol03	
        /// </summary>
        public string Vehicle_Id { get; set; }

        /// <summary>
        ///第三方订单号     	ExtCol04
        /// </summary>
        public string ThirdOrdersCode { get; set; }
        /// <summary>
        ///手机号码  	ExtCol05
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        ///车辆类型  	ExtCol07	
        /// </summary>
        public string CarType { get; set; }
        /// <summary>
        ///车架号    	ExtCol08	
        /// </summary>
        public string CarCode { get; set; }
        /// <summary>
        ///发动机号       ExtCol09
        /// </summary>
        public string CarDriveNumber { get; set; }
        /// <summary>
        ///接口来源     	ExtCol06
        /// </summary>
        public string InterfaceSource { get; set; }

        /// <summary>
        /// 登录会员的手机号码
        /// </summary>
        public string MemberMobile { get; set; }



        /// <summary>
        /// 登录会员的邮箱
        /// </summary>
        public string MemberEmail { get; set; }

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
