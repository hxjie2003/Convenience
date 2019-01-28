using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Utilities
{
    /// <summary>
    /// 缴费省份实体
    /// </summary>
    public class UtilitiesProvince
    {
        public string location_id { get; set; }

        public string name { get; set; }

        public string path { get; set; }

        public string location_to_location_id { get; set; }

        public string api_type { get; set; }

        public string api_location_id { get; set; }

        public string api_location_name { get; set; }

        public string api_location_biztype { get; set; }
    }
}