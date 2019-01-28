// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HospitalDoctorPartner.cs" company="ETong">
//   预约医生实体
// </copyright>
// <summary>
//      bm_hospital_doctor 与 bm_hospital_doctor_partner的关联查询
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Hospital
{
    /// <summary>
    /// 可预约医生的实体
    /// </summary>
    public class DoctorPartner
    {
        /// <summary>
        /// Gets or sets 医生ID
        /// </summary>
        public int DOCTOR_ID { get; set; }

        /// <summary>
        /// Gets or sets 医生姓名
        /// </summary>
        public string DOCTOR_NAME { get; set; }

        /// <summary>
        /// Gets or sets 医生简称
        /// </summary>
        public string DOCTOR_INTRO { get; set; }

        /// <summary>
        /// Gets or sets 医院ID
        /// </summary>
        public int DOCTOR_HOSPITALID { get; set; }

        /// <summary>
        /// Gets or sets 医院名称
        /// </summary>
        public string DOCTOR_HOSPITALNAME { get; set; }

        /// <summary>
        /// Gets or sets 科室ID
        /// </summary>
        public int DOCTOR_DEPARTMENTID { get; set; }

        /// <summary>
        /// Gets or sets 科室名称
        /// </summary>
        public string DOCTOR_DEPARTMENTNAME { get; set; }

        /// <summary>
        /// Gets or sets 医生职称，包括社会职称、临床职称、教学职称
        /// </summary>
        public string DOCTOR_TITLE { get; set; }

        /// <summary>
        /// Gets or sets 日号源量
        /// </summary>
        public int? DOCTOR_DAYJOBS { get; set; }


        /// <summary>
        /// Gets or sets 医生挂号费,单位：分
        /// </summary>
        public decimal? DOCTOR_REGFEE { get; set; }


        /// <summary>
        /// Gets or sets 医生擅长疾病
        /// </summary>
        public string DOCTOR_ADEPT { get; set; }


        /// <summary>
        /// Gets or sets 合作标志(0-平台，1—39，2－好医生，3－好大夫)
        /// </summary>
        public string DOCTOR_PARTNERTYPE { get; set; }


        /// <summary>
        /// Gets or sets 状态标志(0—停用，1－在用，2—试用)
        /// </summary>
        public short? DOCTOR_STATUS { get; set; }

        /// <summary>
        /// Gets or sets 分润ID(待用)
        /// </summary>
        public int? DOCTOR_PROFITID { get; set; }

        /// <summary>
        /// Gets or sets 医生照片，文件URL
        /// </summary>
        public string DOCTOR_PHOTO { get; set; }

        /// <summary>
        /// Gets or sets 平台医生ID, 来源于T_Med_Doctor.Doctor_ID
        /// </summary>
        public int? DOCTORPARTNER_DOCTORID { get; set; }

        /// <summary>
        /// Gets or sets 合作标志(0-平台，1—39，2－好医生，3－好大夫)
        /// </summary>
        public string DOCTORPARTNER_PARTNERTYPE { get; set; }

        /// <summary>
        /// Gets or sets 合作方医生ID
        /// </summary>
        public int? DOCTORPARTNER_PARTNERDOCTORID { get; set; }

        /// <summary>
        /// Gets or sets 合作方科室ID
        /// </summary>
        public int? DOCTORPARTNER_PARTNERDEPTID { get; set; }

        /// <summary>
        /// Gets or sets 合作方医院ID
        /// </summary>
        public int? DOCTORPARTNER_PARTNERHOSPITID { get; set; }
    }
}
