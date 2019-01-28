using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    [Obsolete]
    public class DeliveryInfoResult
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? Defaultd { get; set; }
        public string Delivery_ID { get; set; }
        public string District { get; set; }
        public DateTime? Gmt_Create { get; set; }
        public DateTime? Gmt_Modify { get; set; }
        public string Location_Path { get; set; }
        public string Member_Id { get; set; }
        public string Mobile { get; set; }
        public string Province { get; set; }
        public string Tel { get; set; }
        public string True_Name { get; set; }
        public int? ZipCode { get; set; }
    }
}
