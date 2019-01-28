using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace ETong.Coffee.Web.Models
{
    public class Config
    {
        public static string GetApiFullPath(string path)
        {
            var baseUrl = ConfigurationManager.AppSettings["ApiUri"];
            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }
            return Path.Combine(baseUrl, path);
        }
    }
}