using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Transfer
{
    /// <summary>
    /// 城市信息类
    /// </summary>
    public class CityInfo
    {
        /// <summary>
        /// 城市代码(地区id)
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 所属省份信息
        /// </summary>
        public ProvinceInfo Province { get; set; }

    }
}
