using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 医生
    /// </summary>
    public class DoctorInfo
    {
        /// <summary>
        /// 医生ID
        /// </summary>
        public int DOCTOR_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 医生名称
        /// </summary>

        public string DOCTOR_NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 医生简介
        /// </summary>

        public string DOCTOR_INTRO
        {
            get;
            set;
        }

        /// <summary>
        /// 医院ID
        /// </summary>
        public int DOCTOR_HOSPITALID
        {
            get;
            set;
        }

        /// <summary>
        /// 科室ID
        /// </summary>
        public int DOCTOR_DEPARTMENTID
        {
            get;
            set;
        }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string DOCTOR_DEPARTMENTNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 医生职称，包括社会职称、临床职称、教学职称
        /// </summary>
        public string DOCTOR_TITLE
        {
            get;
            set;
        }

        /// <summary>
        /// 日号源量
        /// </summary>
        public string DOCTOR_DAYJOSS
        {
            get;
            set;
        }

        /// <summary>
        /// 医生挂号费,单位：分
        /// </summary>
        public string DOCTOR_REGFEE
        {
            get;
            set;
        }

        /// <summary>
        /// 医生擅长疾病
        /// </summary>
        public string DOCTOR_ADEPT
        {
            get;
            set;
        }

        /// <summary>
        /// 合作标志(0-平台，1—39，2－好医生，3－好大夫)
        /// </summary>
        public string DOCTOR_PARTNERTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 状态标志(0—停用，1－在用，2—试用)
        /// </summary>
        public int DOCTOR_STATUS
        {
            get;
            set;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string DOCTOR_PROFITID
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 医生相片
        /// </summary>
        public string DOCTOR_PHOTO
        {
            get;
            set;
        }
    }
}
