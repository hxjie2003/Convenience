using ETong.District.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.District.Sdk
{
    public class DistrictUtils
    {
        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        public List<ETM_LOCATION_TO_LOCATION> GetLocationOfProvinces()
        {
            var result = new List<ETM_LOCATION_TO_LOCATION>();

            var context = new ET_BusinessEntities();
            // 内联(第三方城市表)-(本地数据库城市表)，筛选出本地库的城市路径记录
            var cityIds = (from k in context.ETM_SYS_LOCATION
                           join j in context.ETM_LOCATION_TO_LOCATION
                           on k.LOCATION_ID equals j.LOCATION_ID
                           where j.API_LOCATION_PARENTID == null
                           select k.PATH).Distinct();

            // 取回本地库的所有省份，因为省份只有34条，所以相对不影响性能。
            var proviteAll = context.ETM_SYS_LOCATION.Where(x => x.PID == null).ToList();

            var proviteList = new List<ETM_SYS_LOCATION>();

            // 根据城市路径，筛选出省份
            cityIds.ToList().ForEach(x =>
            {
                // 城市路径是使用逗号进行分隔，依次是 省,市,区
                var cityid = x.Split(',').FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(cityid))
                {
                    if (!proviteList.Any(k => k.LOCATION_ID == cityid))
                    {
                        var entity = proviteAll.SingleOrDefault(k => k.LOCATION_ID == cityid);
                        if (entity != null)
                        {
                            proviteList.Add(entity);
                        }
                    }
                }
            });

            if (proviteList.Count() > 0)
            {
                proviteList.ToList().ForEach(x =>
                {
                    result.Add(new ETM_LOCATION_TO_LOCATION
                    {
                        LOCATION_ID = x.LOCATION_ID,
                        API_LOCATION_NAME = x.NAME
                    });
                });
            }

            return result;
        }

        /// <summary>
        /// 根据省份编号返回城市列表
        /// <param name="locationid">省份编码/id</param>
        /// </summary>
        public List<ETM_LOCATION_TO_LOCATION> GetLocationOfCity(string ProvinceId)
        {
            // 在1个dbContext中进行多表查询
            var context = new ET_BusinessEntities();

            //多表筛选
            var location_cityList = from j in context.ETM_SYS_LOCATION
                                    join k in context.ETM_LOCATION_TO_LOCATION
                                    on j.LOCATION_ID equals k.LOCATION_ID
                                    where j.PID == ProvinceId && k.API_LOCATION_PARENTID == null
                                    select k;
            return location_cityList.ToList();
        }

        /// <summary>
        /// 根据locationid返回看购网的订座城市/区/镇
        /// </summary>
        /// <returns></returns>
        public List<ETM_LOCATION_TO_LOCATION> GetLocationOfArea(string locationid)
        {
            var context = new ET_BusinessEntities();
            return context.ETM_LOCATION_TO_LOCATION.Where(x => x.API_LOCATION_PARENTID == locationid).ToList();
        }

        /// <summary>
        /// 获取本地区位信息
        /// </summary>
        /// <param name="locationid">本地id</param>
        /// <returns>区域实体</returns>
        public ETM_LOCATION_TO_LOCATION GetLocationEntity(string locationid)
        {
            var context = new ET_BusinessEntities();
            return context.Set<ETM_LOCATION_TO_LOCATION>()
                  .FirstOrDefault(x => x.API_LOCATION_ID.Equals(locationid, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// 获取本地区信息
        /// </summary>
        /// <param name="locationid"></param>
        /// <returns></returns>
        public List<ETM_LOCATION_TO_LOCATION> GetLocationList(string locationid)
        {
            var context = new ET_BusinessEntities();
            return context.Set<ETM_LOCATION_TO_LOCATION>()
                     .Where(x => x.API_LOCATION_ID.Equals(locationid, StringComparison.CurrentCultureIgnoreCase))
                     .ToList();
        }

        /// <summary>
        /// 获取本地区位信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public List<ETM_LOCATION_TO_LOCATION> GetLocationForName(string name)
        {
            var context = new ET_BusinessEntities();
            return context.Set<ETM_LOCATION_TO_LOCATION>()
                    .Where(x => x.API_LOCATION_NAME.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
        }

        /// <summary>
        /// 获取本地区位信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="pid">父id</param>
        /// <returns></returns>
        public List<ETM_LOCATION_TO_LOCATION> GetLocationToSearch(string name, string pid)
        {
            var context = new ET_BusinessEntities();
            return context.Set<ETM_LOCATION_TO_LOCATION>()
                    .Where(x => x.API_LOCATION_NAME.Equals(name, StringComparison.CurrentCultureIgnoreCase) && x.API_LOCATION_PARENTID.Equals(pid, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
        }

    }
}
