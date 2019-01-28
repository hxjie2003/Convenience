using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 机票费率
    /// </summary>
    public class AirFee
    {
        /// <summary>
        /// 单笔手续费金额
        /// </summary>
        public decimal FeePrice { get; set; }

        /// <summary>
        /// 单笔手续费成交价的百分比
        /// </summary>
        public double FeePercentage { get; set; }
    }
}
