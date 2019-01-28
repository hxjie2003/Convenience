using ETong.Entity;
using ETong.Entity.Persistence.Infrasture;
using ETong.Utility;
using ETong.Utility.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.DAO
{
    public class DatabaseMetadataManager
    {
        public const string Config_Api_BaseUri = "config_api_baseuri";
        public const string DBConnection = "DBConnection";
        public const string DBMetadata = "DBMetadata";

        public string GetConnectionString(string databaseName)
        {
            string connectionstring = string.Empty;           
            var key = DllConfigurationManager.AppSettings[Config_Api_BaseUri].ToString();
            var path = string.Format("{0}/{1}/{2}", key, DBConnection, databaseName);

            var connectionsresult = HttpClientProxy.Get<ResultData<string>>(path);
            if (connectionsresult != null && string.IsNullOrEmpty(connectionsresult.Data))
            {
                connectionstring = connectionsresult.Data;
            }
            return connectionstring;
        }

        public DBMetadataResult GetMetadataInfo(string metadataName)
        {
            DBMetadataResult metadata = null;           
            var baseurl = DllConfigurationManager.AppSettings[Config_Api_BaseUri].ToString();
            var path = string.Format("{0}/{1}/{2}", baseurl, DBMetadata, metadataName);

            var connectionsresult = HttpClientProxy.Get<ResultData<DBMetadataResult>>(path);
            if (connectionsresult != null)
            {
                metadata = connectionsresult.Data;
            }
            return metadata;
        }
    }
}
