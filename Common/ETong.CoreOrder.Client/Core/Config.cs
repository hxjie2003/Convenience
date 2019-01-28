using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Core
{
    public class CommonConfig
    {
        public CommonConfig(CommonConfigSetting setting)
        {
            if (setting == null)
            {
                JavaOrder_Uri = ConfigurationManager.AppSettings["javaorder_uri"];
            }
            else
            {
                JavaOrder_Uri = setting.JavaOrder_Uri;

            }
            
        }
        public string JavaOrder_Uri { get; set; }
    }

    public class CommonConfigSetting
    {
        public string JavaOrder_Uri { get; set; }
    }
}
