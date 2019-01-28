using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 基础项的实体
    /// </summary>
    public class HospitalBaseItemInfo
    {
        /// <summary>
        /// 项目编码
        /// </summary>
        public string BASIS_ITEM_CODE
        {
            get;
            set;
        }

        /// <summary>
        /// 项目的名称
        /// </summary>
        public string BASIS_ITEM_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int BASIS_ITEM_ORDER
        {
            get;
            set;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string BASIS_ITEM_DESCRIPTION
        {
            get;
            set;
        }

        /// <summary>
        /// 所属父项目的编号
        /// </summary>
        public string BASIS_CODE
        {
            get;
            set;
        }
    }
}
