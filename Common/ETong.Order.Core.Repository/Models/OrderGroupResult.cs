using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Order.Core.Repository.Models
{
    /// <summary>
    /// 订单信息。（创建订单返回结果）
    /// </summary>
    public class OrderGroupResult
    {
        /// <summary>
        /// 组号
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// 项目数
        /// </summary>
        public List<OrderItemResult> Items { get; set; }
        /// <summary>
        /// 总计
        /// </summary>
        public decimal TotalAmount { get; set; }
       

    }

    /// <summary>
    /// 订单项信息。（创建订单返回结果）
    /// </summary>
    public class OrderItemResult
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 项名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 商家名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string StoreId { get; set; }
    }
}
