using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Ads
{
    /// <summary>
    /// 广告播放列表
    /// </summary>
    public class Adplaylist
    {  
        /// <summary>
        /// ETM机编号
        /// </summary>
        public string EtmId { get; set; }
        /// <summary>
        /// 播放位置，0 外接屏幕。
        /// </summary>
        public int PlayLocation { get; set; }
        /// <summary>
        /// 播放类型，1 主播放清单，2 临时插播清单。*主播放清单只有一个，插播清单可以有多个
        /// </summary>
        public int PlayType { get; set; }
        /// <summary>
        /// 播放方式，1 循环播放，2 仅播放一次，3 随机播放。
        /// </summary>
        public int PlayMode { get; set; }
        /// <summary>
        /// 播放开始时间
        /// </summary>
        public DateTime? StarTime { get; set; }
        /// <summary>
        /// 播放结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 播放项ID
        /// </summary>
        public string ItemId;
        /// <summary>
        /// 广告素材列表
        /// </summary>
        public List<Advertised> AdList{ get; set; }      
        /// <summary>
        /// 状态，1 正常，2 已失效。
        /// </summary>
        public int ItemState { get; set; }
        /// <summary>
        /// 获取时间
        /// </summary>
        public DateTime GetTime { get; set; }
    }
}
