using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Utilities
{
    /// <summary>
    /// 缴费城市实体
    /// </summary>
    public class UtilitiesCity
    {
        public string location_id { get; set; }

        public string c_name { get; set; }

        public string c_path { get; set; }

        public string location_to_location_id { get; set; }

        public string api_type { get; set; }

        public string api_location_id { get; set; }

        public string api_location_name { get; set; }

        public string api_location_biztype { get; set; }

        public string p_location_id { get; set; }

        public string p_name { get; set; }

        public string p_location_to_location_id { get; set; }

        public string p_api_type { get; set; }

        public string p_api_location_id { get; set; }

        public string p_api_location_name { get; set; }

        public string p_api_location_biztype { get; set; }

    }
}