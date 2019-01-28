using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ETong.Utility.WebApi
{
    public class ApiManager
    {
        public const string Config_Api_BaseUri = "config_api_baseuri";  
        public const string ApiUrl = "ApiUrl";

        public string GetApiUrl(string modulename, string controller)
        {
            var key = ConfigurationManager.AppSettings[Config_Api_BaseUri].ToString();
            var path = string.Format("{0}/{1}/{2}/{3}", key, ApiUrl, modulename,controller);
            return string.Empty;
        }
    }
}
