using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Ads
{
    /// <summary>
    /// 单条广告
    /// </summary>
    public class Advertised
    {
        /// <summary>
        /// 广告名称
        /// </summary>
        public string AdName { get; set; }
        /// <summary>
        /// 保存路径
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 播放时长
        /// </summary>
        public int AdLength { get; set; }
        /// <summary>
        /// 广告文件的md5校验码，用于校验下载后的文件是否一致。
        /// </summary>
        public string MD5 { get; set; }
        /// <summary>
        /// 广告文件大小，单位为k
        /// </summary>
        public double FileSize { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }
    }
}
