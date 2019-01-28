// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CallbackEnum.cs" company="ETong">
//   回调类型的枚举
// </copyright>
// <summary>
//   回调类型
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 回调类型
    /// </summary>
    public enum CallbackEnum
    {
        /// <summary>
        /// 提交订单
        /// </summary>
        SumbitOrder=1,

        /// <summary>
        /// 取消订单
        /// </summary>
        CancelOrder=2
    }
}
