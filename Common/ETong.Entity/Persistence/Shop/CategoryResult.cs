using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Persistence.Shop
{
    /// <summary>
    /// 商品类目
    /// </summary>
    public class CategoryResult
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 商城编号
        /// </summary>
        public string ShopId { get; set; }

        /// <summary>
        /// 父类ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 类目ID
        /// </summary>
        public string Id{get;set;}

        /// <summary>
        /// 类目名称
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl {get;set;}

        /// <summary>
        /// 链接地址(第三方)
        /// </summary>
        public string LinkUrl{get;set;}

        /// <summary>
        /// 类目级别(从0算起)
        /// </summary>
        public int Level {get;set;}

        /// <summary>
        /// 商店ID(针对无限极才有)
        /// </summary>
        public string StoreId{get;set;}

        /// <summary>
        /// 类目ID树(针对无限极才有, ","号分隔)
        /// </summary>
        public string Path{get;set;}

        /// <summary>
        /// 类目图标地址(针对无限极才有)
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 类目描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 下一级子类名称(","号分隔)
        /// </summary>
        public string ChildNames {get;set;}

        /// <summary>
        /// 子类目树
        /// </summary>
        public List<CategoryResult> Childs { get; set; }
    }
}
