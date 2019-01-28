// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberRateInfoWithList.cs" company="ETong">
//   会员收费单位列表
// </copyright>
// <summary>
//   Defines the MemberRateInfoWithList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Utilities
{
    /// <summary>
    /// 用户收费单位的列表
    /// </summary>
    public class MemberRateInfoWithList
    {
        /// <summary>
        /// 记录分类,0:水费，1:电费，2:燃气费
        /// </summary>
        public string RATE_TYPE { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string RATE_NUMBER { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string RATE_USERNAME { get; set; }

        /// <summary>
        /// 地址详细
        /// </summary>
        public string RATE_ADDRESS { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string MEMBER_RATE_ID { get; set; }

        /// <summary>
        /// 区域的ID路径
        /// </summary>
        public string LOCATION_ID { get; set; }

        /// <summary>
        /// 缴费单位编号
        /// </summary>
        public string UNITS_NO { get; set; }

        /// <summary>
        /// 缴费单位名称
        /// </summary>

        public string UNITS_NAME { get; set; }

        /// <summary>
        /// 联系手机号码
        /// </summary>
        public string RECEIPT_MOB { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string CONTENTS { get; set; }

    }
}
