using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ETong.Entity.Presentation.EtmEnvironment
{
	/// <summary>
	/// 酒店品牌模型
	/// </summary>
    public class EtmNearbyRemarkModel
	{
        public string NearbyRemarkCode { get; set; }
        public string NearbyRemark { get; set; }
	}

    public class EtmNearbyRemarkModelItemsSource : System.Collections.ObjectModel.ObservableCollection<EtmNearbyRemarkModel>
	{
        public EtmNearbyRemarkModelItemsSource()
		{
             //this.Add(new EtmNearbyRemarkModel { BrandCode = brand.Attribute("brandCode").Value, BrandName = brand.Value });
             //this.Insert(0, new EtmNearbyRemarkModel { BrandCode = "0", BrandName = "不限" });
		}
	}
}
