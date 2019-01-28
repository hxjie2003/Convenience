using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Traffic
{
    /// <summary>
    /// 交通违章扣分费用
    /// </summary>
    public class TrafficPoundage
    {

        /// <summary>
        /// 地点(省份或城市)
        /// </summary>
        public string Situs { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string SitusCode { get; set; }

        /// <summary>
        /// 低于6分的手续费
        /// </summary>
        public decimal LowScore { get; set; }

        /// <summary>
        /// 7--11分的手续费
        /// </summary>
        public decimal MediumScore { get; set; }

        /// <summary>
        /// 12时的手续费
        /// </summary>
        public decimal HighScore { get; set; }

        /// <summary>
        /// 非扣分手续费
        /// </summary>
        public decimal NoScore { get; set; }
    }

    public class OnlinePoundage
    {
        /// <summary>
        /// 在线易通手续费
        /// </summary>
        public decimal Poundage { get; set; }
    }

    public class Poundages
    {
        /// <summary>
        /// 总手续费（第三方+易通）
        /// </summary>
        public decimal? TotalPoundage { get; set; }
    }
}
