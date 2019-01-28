using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NativeOrderSdk.Common
{
    /// <summary>
    /// 发货信息。
    /// </summary>
    public class OrderDeliveryInfo
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string ShipProvince { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string ShipCity { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string ShipRegion { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string ShipAddress { get; set; }
        /// <summary>
        /// 运送方式ID
        /// </summary>
        public string DeliveryTypeId{ get; set; }
        /// <summary>
        /// 运送方式名称
        /// </summary>
        public string DeliveryTypeName { get; set; }
    }
}
