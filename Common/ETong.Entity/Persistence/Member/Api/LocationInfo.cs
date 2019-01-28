using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    public class LocationInfo
    {
        /// <summary>
        /// 区域表id
        /// </summary>
        public string LOCATION_ID { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public string PID { get; set; }
        /// <summary>
        /// 区域id树
        /// </summary>
        public string PATH { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public int? CODE { get; set; }
        public string OLD_ID { get; set; }
        public string OLD_PATH { get; set; }
    }
}
