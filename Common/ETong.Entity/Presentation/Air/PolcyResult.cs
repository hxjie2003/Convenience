// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolcyResult.cs" company="ETong">
//   机票的实时政策
// </copyright>
// <summary>
//   实时政策
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 实时政策实体
    /// </summary>
    public class PolcyResult
    {
        /// <summary>
        /// 本地政策列表
        /// </summary>
        public List<LocalData> LocalData { get; set; }

        /// <summary>
        /// 平台政策列表
        /// </summary>
        public List<PlatData> PlatData { get; set; }
    }

    /// <summary>
    /// 平台政策
    /// </summary>
    public class PlatData
    {
        /// <summary>
        /// 平台名称，如果是本地政策显示(本地政策)，如果是平台，则显示哪个
        /// </summary>
        public string PlatName { get; set; }

        /// <summary>
        /// 政策验证码,政策验证码
        /// </summary>
        public string PolicyGuid { get; set; }

        /// <summary>
        /// 返点如5 表示0.05个点
        /// </summary>
        public double RateShow { get; set; }

        /// <summary>
        /// 留钱，没有就没空或0
        /// </summary>
        public string lq { get; set; }

        /// <summary>
        /// 是否特殊政策1是  其他不是
        /// </summary>
        public string isSpecmark { get; set; }

        /// <summary>
        /// 是否换编码1是  其他不是
        /// </summary>
        public string ChangeRecord { get; set; }

        /// <summary>
        /// 政策类型如B2B BSP
        /// </summary>
        public string PolicyType { get; set; }

        /// <summary>
        /// 工作时间如08:00-23:00
        /// </summary>
        public string WorkTime { get; set; }

        /// <summary>
        /// 退废票时间如09:00-21:00或文字描叙
        /// </summary>
        public string ChooseOutWorkTime { get; set; }

        /// <summary>
        /// 政策的Office号
        /// </summary>
        public string Office { get; set; }

        /// <summary>
        /// 政策说明
        /// </summary>
        public string Note { get; set; }
    }

    /// <summary>
    /// 本地政策
    /// </summary>
    public class LocalData
    {
        /// <summary>
        /// 平台名称，如果是本地政策显示(本地政策)，如果是平台，则显示哪个
        /// </summary>
        public string PlatName { get; set; }

        /// <summary>
        /// 政策验证码,政策验证码
        /// </summary>
        public string PolicyGuid { get; set; }

        /// <summary>
        /// 返点如5 表示0.05个点
        /// </summary>
        public double RateShow { get; set; }

        /// <summary>
        /// 留钱，没有就没空或0
        /// </summary>
        public string lq { get; set; }

        /// <summary>
        /// 是否特殊政策1是  其他不是
        /// </summary>
        public string isSpecmark { get; set; }

        /// <summary>
        /// 是否换编码1是  其他不是
        /// </summary>
        public string ChangeRecord { get; set; }

        /// <summary>
        /// 政策类型如B2B BSP
        /// </summary>
        public string PolicyType { get; set; }

        /// <summary>
        /// 工作时间如08:00-23:00
        /// </summary>
        public string WorkTime { get; set; }

        /// <summary>
        /// 退废票时间如09:00-21:00或文字描叙
        /// </summary>
        public string ChooseOutWorkTime { get; set; }

        /// <summary>
        /// 政策的Office号
        /// </summary>
        public string Office { get; set; }

        /// <summary>
        /// 政策说明
        /// </summary>
        public string Note { get; set; }
    }
}
