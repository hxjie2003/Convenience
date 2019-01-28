using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 机票城市列表信息
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable = false, ElementName = "root")]
    public partial class AirCitiesInfo
    {

        private rootCityData[] cityDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CityData")]
        public rootCityData[] CityData
        {
            get
            {
                return this.cityDataField;
            }
            set
            {
                this.cityDataField = value;
            }
        }
    }
    /// <summary>
    /// 机票城市信息（简要版）
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootCityData
    {

        private string cityCodeField;

        private string cityNameField;

        private string cityNameEField;

        /// <summary>
        /// 城市代码
        /// </summary>
        public string CityCode
        {
            get
            {
                return this.cityCodeField;
            }
            set
            {
                this.cityCodeField = value;
            }
        }

       /// <summary>
       /// 城市名称
       /// </summary>
        public string CityName
        {
            get
            {
                return this.cityNameField;
            }
            set
            {
                this.cityNameField = value;
            }
        }

       /// <summary>
       /// 城市英文名
       /// </summary>
        public string CityNameE
        {
            get
            {
                return this.cityNameEField;
            }
            set
            {
                this.cityNameEField = value;
            }
        }
    }


}
