using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Traffic
{
    /// <summary>
    /// 能在线办理且又正在本地库中的订单集合
    /// </summary>
    public class OnLinePayfineList
    {
        /// <summary>
        /// 第3方违章ID
        /// </summary>
        public string violationID { get; set; }

        /// <summary>
        /// 状态，是否可以在线办理
        /// </summary>
        public bool status { get; set; }


        /// <summary>
        /// 状态，是否可以下线办理
        /// </summary>
        public bool offlineStatus { get; set; }

        /// <summary>
        /// 状态文本，是否可以下线办理
        /// </summary>
        public string offlineStatusText { get; set; }


        /// <summary>
        /// 车牌号码
        /// </summary>
        public string carNumber { get; set; }

        /// <summary>
        /// 是否在线办理（1：是在线；2：特殊）
        /// </summary>
        public int is_online_processing { get; set; }

        /// <summary>
        /// 违章时间
        /// </summary>
        public DateTime violation_date { get; set; }

        /// <summary>
        /// 第三方手续费
        /// </summary>
        public decimal? dealFee { get; set; }
    }
}
