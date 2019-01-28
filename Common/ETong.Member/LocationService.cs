using System.Collections.Generic;
using System.IO;
using ETong.Web;

namespace ETong.Location
{
    public class LocationService
    {
        private readonly string _apiUrl;

        public LocationService(string apiUrl)
        {
            if (!apiUrl.EndsWith("/"))
            {
                apiUrl += "/";
                _apiUrl = apiUrl;
            }
        }

        public IList<Province> GetProvinces()
        {
            var url = Path.Combine(_apiUrl, "api/Location/Get");
            return WebApiHelper.Get<List<Province>>(url);
        }

        public IList<City> GetCities(string provinceId)
        {
            var url = Path.Combine(_apiUrl, " api/Location/Get");
            return WebApiHelper.Get<List<City>>(url);
        }

        public IList<City> GetDistricts(string cityId)
        {
            var url = Path.Combine(_apiUrl, " api/Location/Get");
            return WebApiHelper.Get<List<City>>(url);
        }
    }
}