using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeOrderSdk.Common
{
    /// <summary>
    /// 订单状态
    /// </summary>
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
