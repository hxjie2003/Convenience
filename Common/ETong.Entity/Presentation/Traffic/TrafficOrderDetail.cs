using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Traffic
{
    /// <summary>
    /// 违单明细项
    /// </summary>
    public class TrafficOrderDetail
    {
        /// <summary>
        /// 违章id 	
        /// </summary>
        public string Violation_Id { get; set; }
        /// <summary>
        ///违章时间   	
        /// </summary>
        public DateTime Gmt_Violation { get; set; }
        /// <summary>
        ///违章地址 违章详情   	
        /// </summary>
        public string Violation_Address { get; set; }
        /// <summary>
        ///代办日志表id  (订单ID)
        /// </summary>
        public string Traffice_Order_Log_Id { get; set; }
        /// <summary>
        ///罚款金额
        /// </summary>
        public decimal Fine_Fee { get; set; }
        /// <summary>
        ///第三方(百事帮)的手续费	
        /// </summary>
        public decimal Deal_Fee { get; set; }
        /// <summary>
        ///滞留金额
        /// </summary>
        public decimal Late_Fee { get; set; }
        /// <summary>
        ///回执邮寄金额
        /// </summary>
        public decimal Mail_Fee { get; set; }
        /// <summary>
        ///代办周期
        /// </summary>
        public decimal Deal_Times { get; set; }
        /// <summary>
        ///总手续费（含百事帮和易通的手续费）
        /// </summary>
        public decimal T_Fee { get; set; }
        
        /// <summary>
        /// 违章地址(把Violation_Address 包含的地址和违章内容分开)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 违章详情
        /// </summary>
        public string Violation_Detail { get; set; }
       
        /// <summary>
        /// 是否可以在线办理（1：是 ; 0: 否）
        /// </summary>
        public int? IS_ONLINE_PROCESSING { get; set; }

        /// <summary>
        /// 扣分
        /// </summary>
        public int? Deduct_Points { get; set; }

        /// <summary>
        /// 易通手续费
        /// </summary>
        public decimal ET_Fee { get; set; }
    }
}
