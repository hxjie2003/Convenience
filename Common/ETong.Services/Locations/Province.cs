using Newtonsoft.Json;

namespace ETong.Services.Locations
{
    public class Province
    {
        /// <summary>
        ///     区域表id
        /// </summary>
        [JsonProperty("LOCATION_ID")]
        public string Id { get; set; }

        /// <summary>
        ///     区域名称
        /// </summary>
        [JsonProperty("NAME")]
        public string Name { get; set; }
    }

    public class City
    {
        /// <summary>
        ///     区域表id
        /// </summary>
        [JsonProperty("LOCATION_ID")]
        public string Id { get; set; }

        /// <summary>
        ///     区域名称
        /// </summary>
        [JsonProperty("NAME")]
        public string Name { get; set; }

        /// <summary>
        /// 父id
        /// </summary>
        [JsonProperty("PID")]
        public string ProvinceId { get; set; }
    }

    public class District
    {
        /// <summary>
        ///     区域表id
        /// </summary>
        [JsonProperty("LOCATION_ID")]
        public string Id { get; set; }

        /// <summary>
        ///     区域名称
        /// </summary>
        [JsonProperty("NAME")]
        public string Name { get; set; }

        /// <summary>
        /// 父id
        /// </summary>
        [JsonProperty("PID")]
        public string CityId { get; set; }
    }
}