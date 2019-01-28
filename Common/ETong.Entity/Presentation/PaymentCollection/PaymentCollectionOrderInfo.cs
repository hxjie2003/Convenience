using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.PaymentCollection
{
    /// <summary>
    /// 代收货款订单信息
    /// </summary>
    public class PaymentCollectionOrderInfo : OrderCommonInfo
    {
        /// <summary>
        /// 主订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单组号
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 收款类型id
        /// </summary>
        public string CollectionTypeId { get; set; }

        /// <summary>
        /// 收款账户id（电子钱包）
        /// </summary>
        public string ReceiverId { get; set; }

        /// <summary>
        /// 收款账户名称（电子钱包）
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收款账户真实姓名（电子钱包）
        /// </summary>
        public string ReceiverRealName { get; set; }

        /// <summary>
        /// 付款人手机号
        /// </summary>
        public string PayerMobile { get; set; }

        /// <summary>
        /// 电子钱包代收订单号
        /// </summary>
        public string WalletOrderId { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string VehiclePlate { get; set; }

        /// <summary>
        /// 车架号
        /// </summary>
        public string VehicleFrame { get; set; }

        /// <summary>
        /// 发动机号
        /// </summary>
        public string Engine { get; set; }

        /// <summary>
        /// 支付状态：未支付=0，部分支付=1，已支付=2，部分退款=3，全额退款=4，联合支付=5，无需支付=6
        /// </summary>
        public int PaymentStatus { get; set; }

        /// <summary>
        /// 手续费率
        /// </summary>
        public decimal FeeRate { get; set; }

        /// <summary>
        /// ETM编号
        /// </summary>
        public string ETMId
        {
            get;
            set;
        }

        /// <summary>
        /// 代收货款类型名称
        /// </summary>
        public string TypeName
        {
            get;
            set;
        }

        /// <summary>
        /// 代收货款类型代码
        /// </summary>
        public string TypeCode
        {
            get;
            set;
        }

        /// <summary>
        /// 代收金额（元）
        /// </summary>
        public decimal Amount
        {
            get;
            set;
        }

    }
}
