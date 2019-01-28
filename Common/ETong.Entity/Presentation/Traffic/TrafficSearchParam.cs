using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Traffic
{
    /// <summary>
    /// 违章查询实体
    /// </summary>
    public class TrafficSearchParam
    {
        /// <summary>
        /// 违章车牌号
        /// </summary>
        public string CarNumber { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string CarType { get; set; }
        /// <summary>
        /// 车架号
        /// </summary>
        public string CarCode { get; set; }
        /// <summary>
        /// 发动机号
        /// </summary>
        public string CarDriveNumber { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

    }
}
