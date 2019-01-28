using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Transfer
{
    /// <summary>
    /// 转账订单信息
    /// </summary>
    public class TransferOrderInfo : OrderCommonInfo
    {
        /// <summary>
        /// 订单明细
        /// </summary>
        public TransferInfo OrderDetails { get; set; }

        /// <summary>
        /// 转账认证信息
        /// </summary>
        public TransferAuthInfo AuthInfo { get; set; }
    }
}
