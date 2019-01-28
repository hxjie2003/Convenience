using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Payment
{
    /// <summary>
    /// 更新订单支付状态用的实体类
    /// </summary>
    public class OrderPayStatusUpdateEntity
    {
        /// <summary>
        /// 要更新的id集合
        /// </summary>
        public string[] OrderIds{get; set;}
        
        /// <summary>
        /// 支付状态:未支付=0，部分支付=1，已支付=2，部分退款=3，全额退款=4，积分部分支付=5
        /// </summary>
        public int PayStatus{get; set;}

        /// <summary>
        /// etmId
        /// </summary>
        public string EtmId { get; set; }

        /// <summary>
        /// 交易总金额（元）
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
