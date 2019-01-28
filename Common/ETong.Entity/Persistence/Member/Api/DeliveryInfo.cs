using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    public class SearchAddressDto
    {
        public string MemberId
        {
            get;
            set;

        }

        public string DelivId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDefault { get; set; }
    }
    public class DeliveryInfo
    {
        public string DELIV_ID { get; set; }
        public string TRUE_NAME { get; set; }
        public string LOCATION_PATH { get; set; }
        public string ADDRESS { get; set; }
        public int? ZIPCODE { get; set; }
        public string MOBILE { get; set; }
        public string TEL { get; set; }
        public int? DEFAULTD { get; set; }
        public string MEMBER_ID { get; set; }
        public string COUNTRY { get; set; }
        public string PROVINCE { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
    }
}
