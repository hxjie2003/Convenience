using System;
using System.Collections.Generic;
using System.IO;
using ETong.Web;

namespace ETong.Services.Locations
{
    public class LocationService
    {
        private readonly string _apiUrl;

        public LocationService(string apiUrl)
        {
            if (apiUrl == null) throw new ArgumentNullException("apiUrl");

            _apiUrl = apiUrl.TrimEnd('/') + "/api/Location/Get"; ;
        }

        public IList<Province> GetProvinces()
        {
            return WebApiHelper.Get<List<Province>>(_apiUrl);
        }

        public IList<City> GetCities(string provinceName)
        {
            if (provinceName == null) throw new ArgumentNullException("provinceName");

            return WebApiHelper.Get<List<City>>(_apiUrl, new { provinceName });
        }

        public IList<City> GetDistricts(string provinceName, string cityName)
        {
            if (provinceName == null) throw new ArgumentNullException("provinceName");
            if (cityName == null) throw new ArgumentNullException("cityName");
            //string provinceName, string cityName, bool isHot
            return WebApiHelper.Get<List<City>>(_apiUrl, new
            {
                provinceName = provinceName,
                cityName = cityName,
                isHot = false
            });
        }
    }
}