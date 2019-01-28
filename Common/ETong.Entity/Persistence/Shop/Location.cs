using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Persistence.Shop
{
    /// <summary>
    /// 地区
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 上级地区ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 地区ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 地区编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地区ID树
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 旧库地区ID
        /// </summary>
        public string OldId { get; set; }

        /// <summary>
        /// 旧库地区ID树
        /// </summary>
        public string OldPath { get; set; }
    }
}
