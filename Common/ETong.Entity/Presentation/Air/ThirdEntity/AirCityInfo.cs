using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 机票城市信息
    /// </summary>
    public class AirCityInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string BH { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public string EnName { get; set; }

        /// <summary>
        /// 所在省份
        /// </summary>
        public string HostCountry { get; set; }

        /// <summary>
        /// 第三方代码
        /// </summary>
        public string CityThreeCode { get; set; }

        /// <summary>
        /// 是否为国内，1国内，0国外
        /// </summary>
        public string DomesticOrInternational { get; set; }

        /// <summary>
        /// 是否为国际航班
        /// </summary>
        public string InternationalFlight { get; set; }

        /// <summary>
        /// 是否有机场
        /// </summary>
        public string ExistAirport { get; set; }

        /// <summary>
        /// 机场名称
        /// </summary>
        public string AirportName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string OperationTime { get; set; }

        /// <summary>
        /// 地理名称
        /// </summary>
        public string GeographicalNames { get; set; }

        /// <summary>
        /// 地理名称拼音
        /// </summary>
        public string GeographicalNamesJc { get; set; }

        /// <summary>
        /// 城市编号
        /// </summary>
        public string CSBH { get; set; }

        /// <summary>
        /// CityThreeCodeTyc
        /// </summary>
        public string CityThreeCodeTyc { get; set; }
    }
}
