// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tpinfo.cs" company="ETong">
//   机票PAT价格
// </copyright>
// <summary>
//   PAT价格信息
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// PAT价格信息
    /// </summary>
    public class Tpinfo
    {
        /// <summary>
        /// Gets or sets 乘机人类型 1成人 2儿童 3婴儿
        /// </summary>
        public string PType { get; set; }

        /// <summary>
        /// Gets or sets 票面价
        /// </summary>
        public int TPrice { get; set; }

        /// <summary>
        /// Gets or sets 燃油税
        /// </summary>
        public int Yq { get; set; }

        /// <summary>
        /// Gets or sets 机场建设税
        /// </summary>
        public int Tax { get; set; }

        /// <summary>
        /// Gets or sets 客票类型 如：CD老年票 ZS青年票 成人票
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets 票价总计
        /// </summary>
        public int Total { get; set; }
    }
}
