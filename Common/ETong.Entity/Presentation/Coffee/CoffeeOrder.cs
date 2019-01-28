using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Coffee
{
    /// <summary>
    /// 现磨咖啡提交订单类
    /// </summary>
    public class CoffeeOrder
    {
        /// <summary>
        /// 订单来源：商城=0，ETM=1，进销存=2，B2C=3，APP=4（必填）
        /// </summary>       
        public int OrderFrom { get; set; }
        /// <summary>
        /// 下单的ETMID,在手机端下单时可以为空。
        /// </summary>
        public string OrderETMID { get; set; }        
        /// <summary>
        /// 购买数量（必填）
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 订单总金额（必填）
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 创建IP
        /// </summary>
        public string CreateIP { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Fee { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 饮料集
        /// </summary>
        public List<Drink> DrinkList { get; set; }
    }   
}
