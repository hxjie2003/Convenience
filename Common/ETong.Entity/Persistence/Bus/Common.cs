namespace ETong.Entity.Persistence.Bus
{
    /// <summary>
    /// 订单类型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 商城订单
        /// </summary>
        Mall = 0,

        /// <summary>
        /// ETM机
        /// </summary>
        Etm = 1,

        /// <summary>
        /// 机票订单
        /// </summary>
        AirTicket = 2,

        /// <summary>
        /// 报刊订阅
        /// </summary>
        Paper = 3,

        /// <summary>
        /// 火车票(赶火车)订单
        /// </summary>
        TrainGanHuoChe = 5,

        /// <summary>
        /// 交通违章(百事帮)
        /// </summary>
        TrafficBaiShiBang = 6,

        /// <summary>
        /// 汽车票(广州交投)
        /// </summary>
        BusJiaoTou = 9,

        /// <summary>
        /// 39 就医助手订单
        /// </summary>
        Hospital39 = 10
    }

    /// <summary>
    /// 订单第三方状态
    /// </summary>
    public enum OrderThirdStatus
    {
        /// <summary>
        /// 未向第三方提交订单
        /// </summary>
        None = 0,

        /// <summary>
        /// 成功向第三方提交订单
        /// </summary>
        Submited = 1,

        /// <summary>
        /// 成功向第三方取消订单
        /// </summary>
        Canceled = 2
    }

    /// <summary>
    /// 订单支付状态
    /// </summary>
    public enum OrderPaymentStatus
    {
        /// <summary>
        /// 未支付
        /// </summary>
        NotPaied = 0,

        /// <summary>
        /// 部分支付
        /// </summary>
        LessPaied = 1,

        /// <summary>
        /// 已支付
        /// </summary>
        Paied = 2,

        /// <summary>
        /// 部分退款
        /// </summary>
        LessReAmt = 3,

        /// <summary>
        /// 全额退款
        /// </summary>
        ReAmt = 4,

        /// <summary>
        /// 积分部分支付
        /// </summary>
        LessScorePaied = 5,

        /// <summary>
        /// 不需要支付
        /// </summary>
        NoPaied = 6
    }

    public class CommonBasic
    {
        /// <summary>
        /// 根据到站站点名称判断是否优惠票
        /// </summary>
        /// <param name="stationName">到站站点名称</param>
        /// <returns></returns>
        public static bool IsSpecialTicket(string stationName)
        {
            return stationName.Contains("学生") || stationName.Contains("优惠") || stationName.Contains("儿童");
        }
    }
}