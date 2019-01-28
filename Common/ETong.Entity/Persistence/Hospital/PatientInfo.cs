using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 患者信息
    /// </summary>
    public class PatientInfo
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string MC_ID { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string id_card { get; set; }

        /// <summary>
        /// 性别：0男，1女, 2保密
        /// </summary>
        public long six { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }


        /// <summary>
        /// 会员ID
        /// </summary>
        public string member_id { get; set; }

        /// <summary>
        /// 合作标志(0-平台，1—39，2－好医生，3－好大夫)
        /// </summary>
        public string patientmember_partnertype { get; set; }

        /// <summary>
        /// 就诊人在第三方平台ID
        /// </summary>
        public string patientmember_partnerplatfrmid { get; set; }

        /// <summary>
        /// 就诊人在第三方平台账号ID
        /// </summary>
        public string patientmember_partneraccountid { get; set; }

        /// <summary>
        /// 诊疗卡
        /// </summary>
        public string patientmember_medicalcardno { get; set; }

        /// <summary>
        /// 联系人ID,来源于tsso_memberpassenger.PATIENTMEMBER_ID
        /// </summary>
        public string patientmember_linkmanid { get; set; }

    }
}
