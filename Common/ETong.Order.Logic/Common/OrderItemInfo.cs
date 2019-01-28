using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Order.Logic.Common
{
    /// <summary>
    /// 订单明细项
    /// </summary>
    /// <typeparam name="CustomerOrderExtend">扩展信息</typeparam>
    /// <typeparam name="CustomerOrderDetail">自定义信息</typeparam>
    public class OrderItemInfo<CustomerOrderExtend, CustomerOrderDetail>
    {
        /// <summary>
        /// 订单号，原来的订单组号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 订单共公信息。
        /// </summary>
        public OrderCommon OrderCommon { get; set; }
        /// <summary>
        /// 订单扩展信息。
        /// </summary>
        public CustomerOrderExtend OrderExtend { get; set; }
        /// <summary>
        /// 订单自定义信息(自定义表)
        /// </summary>
        public CustomerOrderDetail OrderDetail { get; set; }       
    }
}
