using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class FreightDataMap
    {
        public string memberId { get; set; }
        public string areaName { get; set; }
        public FreightStoreInfo[] storeInfos { get; set; }
    }

    public class FreightStoreInfo
    {
        public string id { get; set; }
        public int qty { get; set; }
        public string[] goodsIds { get; set; }
        public string[] templateIds { get; set; }
    }

}
