using ETong.ETM.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.ETM.Sdk
{
    public class EtmDistrictUtils
    {
        /// <summary>
        /// 查询ETM设置的地理信息
        /// </summary>
        /// <param name="driverId">设备编号</param>
        /// <returns></returns>
        public static EtmLocation GetETMDistrict(string driverId)
        {
            var result = new EtmLocation();
            using (var db = new ET_BussinessEntities())
            {
                string sql = string.Format("select location_id from etm_biz_agent_dealer_driver t where driver_id='{0}'", driverId);
                var query = db.Database.SqlQueryForDataTatable(sql, new System.Data.SqlClient.SqlParameter[] { });
                if (query.Rows.Count > 0)
                {
                    string locationSql = string.Format("select f_get_location(location_id) as locationName,path from etm_sys_location where location_id='{0}'", query.Rows[0][0].ToString());
                    var locationQuery = db.Database.SqlQueryForDataTatable(locationSql, new System.Data.SqlClient.SqlParameter[] { });
                    if (locationQuery.Rows.Count > 0)
                    {
                        string strPath = locationQuery.Rows[0]["path"].ToString();  //5,153,785         
                        string strLocationName = locationQuery.Rows[0]["locationName"].ToString();  //福建,宁德市,古田县        
                        string[] charSplitPath = strPath.Split(new char[] { ',' });
                        string[] charSplitLocationName = strLocationName.Split(new char[] { ',' });
                        string areaId = string.Empty; //区域Id
                        string areaName = string.Empty;//区域名称
                        int ExecuteCount = 0;  // 执行次数
                        foreach (var item in charSplitPath)
                        {
                            string etmLocationSql = string.Format("select api_location_id,api_location_name from etm_location_to_location t where api_type=9 and location_id='{0}'", item);
                            var etmLocationQuery = db.Database.SqlQueryForDataTatable(etmLocationSql, new System.Data.SqlClient.SqlParameter[] { });
                            if (etmLocationQuery.Rows.Count > 0)
                            {
                                areaId += "," + etmLocationQuery.Rows[0]["api_location_id"].ToString(); //区域Id：153,785(分别对应下面的：宁德市,古田县)
                                areaName += "," + etmLocationQuery.Rows[0]["api_location_name"].ToString();//区域名称 宁德市,古田县

                            }
                            ExecuteCount++;
                        }

                        areaId = charSplitPath[0].ToString() + areaId; //区域Id：5,153,785(分别对应下面的：福建,宁德市,古田县)
                        areaName = charSplitLocationName[0].ToString() + areaName; // 区域名称  福建,宁德市,古田县 

                        result.AreaIdPath = areaId;
                        result.AreaNamePath = areaName;
                    }
                }
            }

            return result;
        }
    }
}
