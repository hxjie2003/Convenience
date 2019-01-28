using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 医院科室
    /// </summary>
    public class DepartmentInfo
    {
        /// <summary>
        /// 科室ID
        /// </summary>
        public int DEPARTMENT_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 医院ID
        /// </summary>
        public int DEPARTMENT_HOSPITALID
        {
            get;
            set;
        }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string DEPARTMENT_HOSPITALNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DEPARTMENT_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 上级科室ID，来源于本表科室ID字段
        /// </summary>
        public int DEPARTMENT_PARENTID
        {
            get;
            set;
        }

        /// <summary>
        /// 上级科室名称
        /// </summary>
        public string DEPARTMENT_PARENTNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 第三方ID
        /// </summary>
        public int DEPARTMENT_PARTNERID
        {
            get;
            set;
        }

        /// <summary>
        /// 详细json数据
        /// </summary>
        public string DEPARTMENT_DESC
        {
            get;
            set;
        }

    }

}
