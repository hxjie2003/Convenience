using System;
using System.Collections.Generic;

namespace ETong.Entity.Presentation.Coffee
{
    /// <summary>
    /// web端的传入参数类型
    /// </summary>
    [Serializable]
    public class WebInputArgs
    {
        /// <summary>
        /// 需要制作的饮品列表
        /// </summary>
        public List<Drink> Drinks { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallBackUrl { get; set; }

        /// <summary>
        /// 开门的回调地址
        /// </summary>
        public string OpenDoorUrl { get; set; }

        /// <summary>
        /// 订单单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 修改订单状态的地址
        /// </summary>
        public string OrderStatusUrl { get; set; }

    }
}
