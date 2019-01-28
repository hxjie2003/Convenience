using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Traffic
{
    public class UpdateOrdersParam
    {
        /// <summary>
        /// 订单组ID
        /// </summary>
        public string OrdersGroupId{get;set;}
           
        /// <summary>
        /// java 平台的操作ID（ 9：已完成;11：取消办理 ;19：确认办理;(对应ETM库订单状态)）
        /// </summary>
        public int OperateId{get;set;}
    }
}
