using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Common.Enum
{
    /// <summary>
    /// 订单类枚举
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public enum OrderType
        {
            NoneOrder = -1,

            /// <summary>
            /// 商城订单
            /// </summary>
            ShopOrder = 0,

            /// <summary>
            /// 彩票订单
            /// </summary>
            LotteryOrder = 1,

            /// <summary>
            /// 机票订单
            /// </summary>
            AirOrder = 2,

            /// <summary>
            /// 报刊订单
            /// </summary>
            PaperOrder = 3,

            /// <summary>
            /// 充值订单
            /// </summary>
            MobileOrder = 4,

            /// <summary>
            /// 火车票订单
            /// </summary>
            TrainOrder = 5,

            /// <summary>
            /// 交通违章订单
            /// </summary>
            TrafficOrder = 6,

            /// <summary>
            /// 景点门票订单
            /// </summary>
            SceneryOrder = 7,

            /// <summary>
            /// 旅游酒店订单
            /// </summary>
            HotelOrder = 8,

            /// <summary>
            /// 汽车票订单
            /// </summary>
            BusOrder = 9,

            /// <summary>
            /// 就医助手订单
            /// </summary>
            HospitalOrder = 10,

            /// <summary>
            /// 幸运大转盘
            /// </summary>
            LuckDialOrder = 11,

            /// <summary>
            /// 酒店预订
            /// </summary>
            HotelBookOrder = 12,

            /// <summary>
            /// 东莞通
            /// </summary>
            DGTOrder = 13,

            /// <summary>
            /// 信用卡
            /// </summary>
            CreditOrder = 14,

            /// <summary>
            /// 银行转账
            /// </summary>
            BankOrder = 15,

            /// <summary>
            /// 水费订单
            /// </summary>
            WaterOrder = 16,

            /// <summary>
            /// 电费订单
            /// </summary>
            ElectricityOrder = 17,

            /// <summary>
            /// 煤气费订单
            /// </summary>
            GasOrder = 18,

            /// <summary>
            /// 流量充值
            /// </summary>
            MobileFlowOrder = 19,

            //电影票订单
            MovieOrder = 20,
        }

        /// <summary>
        /// 查询订单条件状态标记
        /// </summary>
        public enum OrderQueryStatusTag
        {
            NoneStatus = -1,

            /// <summary>
            /// 其他
            /// </summary>
            OtherStatus = 0,

            /// <summary>
            /// 待付款
            /// </summary>
            PaymentStatus = 1,

            /// <summary>
            /// 待收货
            /// </summary>
            OrderStatus = 2,

            /// <summary>
            /// 已完成订单
            /// </summary>
            CompletedOrder = 3,

            /// <summary>
            /// 待自提
            /// </summary>
            DeliveryTypeName = 4,

            /// <summary>
            /// 待评价
            /// </summary>
            IsCommented = 5,
        }

        /// <summary>
        /// 订单回调类型
        /// </summary>
        public enum OrderCallbackType
        {
            /// <summary>
            /// 提交订单
            /// </summary>
            SumbitOrder = 1,

            /// <summary>
            /// 取消订单
            /// </summary>
            CancelOrder = 2,

            /// <summary>
            /// 退款
            /// </summary>
            MoneyBack = 3,

            /// <summary>
            /// 其他
            /// </summary>
            Misc = 4,
        }

    }
    /// <summary>
    /// 配送地区，未发货=0，部分发货=1，已发货=2
    /// </summary>
    public enum ShippingStatus
    {

        /// <summary>
        /// 未发货
        /// </summary>
        NoDelivery = 0,

        /// <summary>
        /// 部分发货
        ///  </summary>
        PartDelivery = 1,

        /// <summary>
        /// 已发货
        /// </summary>
        Delivering = 2,

    }

    /// <summary>
    /// 支付状态
    /// </summary>
    public enum PayStatus
    {
        /// <summary>
        /// 未支储
        /// </summary>
        NotToPay = 0,
        /// <summary>
        /// 部分支付
        /// </summary>
        PartPay = 1,
        /// <summary>
        /// 已支付
        /// </summary>
        Paid = 2,
        /// <summary>
        /// 部分退款
        /// </summary>
        PartRefund = 3,
        /// <summary>
        /// 全额退款
        /// </summary>
        Refund = 4,
        /// <summary>
        /// 联合支付
        /// </summary>
        UnionPay = 5,
        /// <summary>
        /// 无需支付
        /// </summary>
        NotRequiredPay = 6

    }


    public enum OrderStatus
    {
        /// <summary>
        /// 待处理0
        /// </summary>
        ToHandle = 0,
        /// <summary>
        /// 审核通过1
        /// </summary>
        AuditSucess = 1,
        /// <summary>
        /// 审核失败20
        /// </summary>
        AuditFail = 20,
        /// <summary>
        /// 等待备货4
        /// </summary>
        WaitPrepareGood = 4,
        /// <summary>
        /// 等待买家确认收货5
        /// </summary>
        WaitAccept = 5,
        /// <summary>
        /// 交易关闭10
        /// </summary>
        Closed = 10,
        /// <summary>
        /// 客户作废11
        /// </summary>
        CancelByCustomer = 11,
        /// <summary>
        /// 客户拒收12
        /// </summary>
        RejectByCustomer = 12,
        /// <summary>
        /// 异常订单13
        /// </summary>
        ExceptionOrder = 13,
        /// <summary>
        /// 无人签收3
        /// </summary>
        NoSign = 3,
        /// <summary>
        /// 已签收2
        /// </summary>
        Accepted = 2,
        /// <summary>
        /// 已完成9
        /// </summary>
        Finished = 9,
        /// <summary>
        /// 订单作废18
        /// </summary>
        Deleted = 18,
        /// <summary>
        /// 处理中19
        /// </summary>
        Handling = 19

    }
}
