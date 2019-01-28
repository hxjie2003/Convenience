using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Moblie
{
    /// <summary>
    /// 订单明细
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// 订单单号
        /// </summary>
        public string OrderId { get; set; }


        /// <summary>
        /// 手机号码
        /// </summary>
        public string AccountNo { get; set; }


        /// <summary>
        /// 充值金额
        /// </summary>
        public string Amount { get; set; }


        /// <summary>
        /// 手续费
        /// </summary>
        public string PaymentFee { get; set; }
    }

}
