using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ETong.Cache;

namespace ETong.DAO
{
    public static class DatabaseContextFactory
    {
        public const string PROVIDER = "provider=Oracle.ManagedDataAccess.Client";

        /// <summary>
        ///     根据元数据键值获取已生成的DbContext. 使用时请模块初始化时在数据库中
        ///     插入元数据地址。
        /// </summary>
        /// <typeparam name="T">DbContext的类型</typeparam>
        /// <param name="metadatakey">
        ///     元数据地址的键名。Key：Member
        ///     Value:metadata=res://*/Models.Member.csdl|res://*/Models.Member.ssdl|res://*/Models.Member.msl
        /// </param>
        /// <returns></returns>
        public static T GetDbContext<T>(string metadatakey) where T : DbContext
        {
            T contexta = null;
            var metadatainfo = DatabaseMetadataCache.Get(metadatakey);
            if (metadatainfo == null)
            {
                var manager = new DatabaseMetadataManager();
                metadatainfo = manager.GetMetadataInfo(metadatakey);
            }
            if (metadatainfo != null)
            {
                var path = string.Format("{0};{1};{2};", metadatainfo.Metadata, PROVIDER, metadatainfo.Connectionstring);
                contexta = (T) Activator.CreateInstance(typeof (T), path);
            }
            return contexta;
        }
    }
}
