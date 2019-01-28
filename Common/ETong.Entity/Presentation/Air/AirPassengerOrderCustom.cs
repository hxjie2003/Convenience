using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 乘客信息（订单自定义属性）
    /// </summary>
    public class AirPassengerOrderCustom
    {
        /// <summary>
        /// 乘客名称
        /// </summary>
        public string PassengeName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string TelephoneNo { get; set; }
        /// <summary>
        /// 票号
        /// </summary>
        public string ETicketNumber { get; set; }

        /// <summary>
        /// 出票状态
        /// </summary>
        public string TicketStatus { get; set; }
    }
}
