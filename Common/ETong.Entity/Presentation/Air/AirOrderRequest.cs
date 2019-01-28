using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Air
{
    using System.Windows.Input;

    /// <summary>
    /// 携程订单请求实体
    /// </summary>
    public class AirOrderRequest
    {
        /// <summary>
        /// 易通订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 联系人EMAIL
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// 联盟公司
        /// </summary>
        public string ContactMobile1 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// 去程
        /// </summary>
        public AirData Onward { get; set; }

        /// <summary>
        /// 返程
        /// </summary>
        public AirData Flyback { get; set; }

        /// <summary>
        /// 乘机人
        /// </summary>
        public List<TravelerInfo> Traveler { get; set; }

        /// <summary>
        /// 机型
        /// </summary>
        public string planeModel { get; set; }
    }
    /// <summary>
    /// 航程
    /// </summary>
    public class AirData
    {
        /// <summary>
        /// 到达城市三字码
        /// </summary>
        public string ArriveCityCode { get; set; }

        /// <summary>
        /// 出发城市三字码
        /// </summary>
        public string DepartCityCode { get; set; }

        /// <summary>
        /// 航班号
        /// </summary>
        public string FlightNo { get; set; }

        /// <summary>
        /// 舱位
        /// </summary>
        public string SubClass { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// 航班产品标识 指定查询时会返回此节点值
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 销售类型 指定查询时会返回此节点
        /// </summary>
        public string SaleType { get; set; }

        /// <summary>
        /// 起飞日期 格式 2015-10-30  
        /// </summary>
        public DateTime TackOffTime { get; set; }

        /// <summary>
        /// 政策ID
        /// </summary>
        public string PID { get; set; }

        /// <summary>
        /// 出发时间，格式为：HHmm，如：0810
        /// </summary>
        public string DepTime { get; set; }

        /// <summary>
        /// 抵达时间,，格式为：HHmm ，如0910
        /// </summary>
        public string ArrTime { get; set; }


        /// <summary>
        /// 机建
        /// </summary>
        public decimal AirportTax { get; set; }

        /// <summary>
        /// 燃油
        /// </summary>
        public decimal FuelTax { get; set; }
    }

    /// <summary>
    /// 乘机人
    /// </summary>
    public class TravelerInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string PersonName { get; set; }

        //public string Gender { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContacMobile { get; set; }

        /// <summary>
        /// 必传 Adult 和Child
        /// </summary>
        //public string TravelerCategory { get; set; }
       
        ///// 
        ///// 证件类型
        ///// 0       BRD             出生日期
        ///// 1       ID              身份证（N）
        ///// 2       PASSPORT        护照（N/I）   
        ///// 3       STC             学生证   
        ///// 4       MTC             军人证（N）   
        ///// 6       DRLC            驾驶证 
        ///// 7       RP              回乡证（N/I） 
        ///// 8       MTP             台胞证（N/I） 
        ///// 10      HMP             港澳通行证（N/I） 
        ///// 11      ISC             国际海员证（I）
        ///// 20      PRC             外国人永久居留证 
        ///// 21      TC              旅行证  
        ///// 22      TP              台湾通行证（I）
        ///// 23      SOC             士兵证  
        ///// 24      TID             临时身份证   
        ///// 25      RBT             户口薄（N） 
        ///// 26      PLC             警官证 
        ///// 27      BRC             出生证明（N）  
        ///// 99      OTHER           其他（N） 
        /////  
        
        /// <summary>
        /// 1 身份证； 2 护照；3 军官证；4 士兵证；5 台胞证；6 其他
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string IDCardNo { get; set; }

        /// <summary>
        /// ADU /CHI 年龄段
        /// </summary>
        //public string AgeType { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }
    }
}
