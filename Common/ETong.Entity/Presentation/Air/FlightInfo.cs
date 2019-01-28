using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 航班信息
    /// </summary>
    public class FlightInfo
    {
        /// <summary>
        /// 机场建设费
        /// </summary>
        public decimal AirConstructionFee{ get; set; }     

        /// <summary>
        /// 航空公司代码
        /// </summary>
        public string Airways{ get; set; }

        /// <summary>
        /// 到达城市，格式：城市三字码
        /// </summary>
        public string ArrivalCity{ get; set; }

        /// <summary>
        /// 抵达航站楼
        /// </summary>
        public string ArrivalTerminal{ get; set; }

        /// <summary>
        /// 航班到达时间，格式：hh:mm,例如：20:30
        /// </summary>
        public string ArrivalTime{ get; set; }

        /// <summary>
        /// 承运航班号，格式：MU876
        /// </summary>
        public string CarrierFlightNo{ get; set; }

        /// <summary>
        /// 出发城市，格式：城市三字码
        /// </summary>
        public string DepartCity{ get; set; }

        /// <summary>
        /// 出发日期，格式：yyyy-MM-dd
        /// </summary>
        public DateTime DepartDate{ get; set; }

        /// <summary>
        /// 起飞航站楼，例如：T2
        /// </summary>
        public Object DepartTerminal{ get; set; }

        /// <summary>
        /// 出发时间，格式：07:50
        /// </summary>
        public string DepartTime{ get; set; }

        /// <summary>
        /// 电子客票，格式：E---电子客票
        /// </summary>
        public string ETicket{ get; set; }

        /// <summary>
        /// 飞机机型，格式：787
        /// </summary>
        public string FlightModel{ get; set; }

        /// <summary>
        /// 机型类型：大、中、小、其它
        /// </summary>
        public string FlightModelType { get; set; }

        /// <summary>
        /// 航班号,格式如：*CA3353 CZ3320
        /// </summary>
        public string FlightNo{ get; set; }    
  
        /// <summary>
        /// 燃油税，格式：140
        /// </summary>
        public decimal FuelTax{ get; set; }

        /// <summary>
        /// 餐食，格式：空或者0-- 无餐、1或者（B--早餐、C----快餐、D---正餐、M---餐食、S---小吃
        /// </summary>
        public byte Meal{ get; set; }

        /// <summary>
        /// 返回给[其余舱位匹配政策]做匹配条件，对应其请求的Cabins节点
        /// </summary>
        public string OtherCabin{ get; set; }

        /// <summary>
        /// 三方协议号
        /// </summary>
        public object ProtocolNum{ get; set; }

        /// <summary>
        /// Y舱全价
        /// </summary>
        public decimal StandPrice { get; set; } 

        /// <summary>
        /// 是否经停，格式：1---经停，0---不经停
        /// </summary>
        public byte StopOver{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object TXCabinDatas{ get; set; }

        /// <summary>
        /// 出发城市名称
        /// </summary>
        public string DepartCityName { get; set; }

        /// <summary>
        /// 到达城市名称
        /// </summary>
        public string ArrivalCityName { get; set; }

        /// <summary>
        /// 到达日期
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// 飞行时间
        /// </summary>
        public string FlyTime { get; set; }

        /// <summary>
        /// 航司名称
        /// </summary>
        public string AirwaysName { get; set; }

       private List<ResponseFlightDataCabinData> _carbinInfos;

        /// <summary>
        /// 舱位列表
        /// </summary>
        public List<ResponseFlightDataCabinData> CarbinInfos
        {
            get
            {
                if (_carbinInfos == null)
                    _carbinInfos = new List<ResponseFlightDataCabinData>();
                return _carbinInfos;
            }
            set { _carbinInfos = value; }
        }

        /// <summary>
        /// 出发机场名称
        /// </summary>
        public string DepartAirportName { get; set; }

        /// <summary>
        /// 到达机场名称
        /// </summary>
        public string ArrivalAirportName { get; set; }

        /// <summary>
        /// 航班索引号
        /// </summary>
        public string FlightIndex { get; set; }

        /// <summary>
        /// 航班跨天数
        /// </summary>
        public string NextDays { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string Provider { get; set; }
    }


}
