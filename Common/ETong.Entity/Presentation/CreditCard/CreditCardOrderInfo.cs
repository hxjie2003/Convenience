using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.CreditCard
{
    /// <summary>
    /// Java订单信息(包括详情)
    /// </summary>
    public class CreditCardInfo : OrderCommonInfo
    {
        /// <summary>
        /// 订单明细
        /// </summary>
        public  CreditCardDetails OrderDetails { get; set; }
    }
}
