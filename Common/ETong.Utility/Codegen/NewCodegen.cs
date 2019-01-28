using ETong.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ETong.Utility.Codegen
{
    public class NewCodegen
    {
        public const string Config_Api_BaseUri = "config_api_baseuri";  
        public static string GetNewID(string type)
        {
            string newid=string.Empty;
            var url=  ConfigurationManager.AppSettings[Config_Api_BaseUri].ToString();
            url+="/api/NewID/"+type;
            url = url.Replace("//", "/");
            url = url.Replace("http:/", "http://");
             newid = HttpClientProxy.Get<string>(url);
            return newid;
        }
         
        public static string GetNewIDByBM(string bmno)
        {
            string newid = string.Empty;
            var url = ConfigurationManager.AppSettings[Config_Api_BaseUri].ToString();
            url += "/api/NewID?ruleno=" + bmno;
            url=url.Replace("//", "/");
            url = url.Replace("http:/", "http://");
             newid = HttpClientProxy.Get<string>(url);
            return newid;
        }

        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
