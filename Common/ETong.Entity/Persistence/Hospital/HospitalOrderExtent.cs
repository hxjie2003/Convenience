using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 就医助手扩展信息表
    /// </summary>
    public class HospitalOrderExtent
    {
        /// <summary>
        /// 医院ID
        /// </summary>
        public string REGISTER_HOSPITALID { get; set; }

        /// <summary>
        /// 科室ID
        /// </summary>
        public string REGISTER_DEPARTMENTID { get; set; }

        /// <summary>
        /// 医生ID
        /// </summary>
        public string REGISTER_DOCTORID { get; set; }

        /// <summary>
        /// 就诊人帐号ID
        /// </summary>
        public string REGISTER_PARTNERACCOUNTID { get; set; }

        /// <summary>
        /// 外链识别字符串(待用)
        /// </summary>
        public string REGISTER_FORIGNLINK { get; set; }

        /// <summary>
        /// 合作方式
        /// </summary>
        public string REGISTER_COOPERTYPE { get; set; }

        /// <summary>
        /// 就诊人ID
        /// </summary>
        public string REGISTER_PATIENTID { get; set; }

        /// <summary>
        /// 就诊人姓名
        /// </summary>
        public string REGISTER_PATIENTNAME { get; set; }

        /// <summary>
        /// 用户身份证号码
        /// </summary>
        public string REGISTER_IDCARDNO { get; set; }

        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string REGISTER_MOBILE { get; set; }

        /// <summary>
        /// 用户地址
        /// </summary>
        public string REGISTER_ADDRESS { get; set; }

        /// <summary>
        /// 用户邮箱(
        /// </summary>
        public string REGISTER_EMAIL { get; set; }

        /// <summary>
        /// 合作方ID
        /// </summary>
        public int REGISTER_PARTNERID { get; set; }

        /// <summary>
        /// 预约出诊时间
        /// </summary>
        public DateTime REGISTER_TIME { get; set; }

        /// <summary>
        /// 排班表的时间段
        /// </summary>
        public string REGISTER_SCHEDULETIME { get; set; }

        /// <summary>
        /// 出诊开始时间
        /// </summary>
        public string REGISTER_DOCTORBEGTIME { get; set; }

        /// <summary>
        /// 出诊结束时间
        /// </summary>
        public string REGISTER_DOCTORENDTIME { get; set; }

        /// <summary>
        /// 医生挂号费
        /// </summary>
        public string REGISTER_DOCTORREGFEE { get; set; }

        /// <summary>
        /// 所患疾病
        /// </summary>
        public string REGISTER_DISEASE { get; set; }

        /// <summary>
        /// 预约目的
        /// </summary>
        public string REGISTER_GOAL { get; set; }

        /// <summary>
        /// 病情描述
        /// </summary>
        public string REGISTER_DISDESC { get; set; }

        /// <summary>
        /// 预约流水号ID
        /// </summary>
        public string REGISTER_SERIALNO { get; set; }

        /// <summary>
        /// 预约卡号
        /// </summary>
        public string REGISTER_CARDNO { get; set; }

        /// <summary>
        /// 注意事项
        /// </summary>
        public string REGISTER_OTHER { get; set; }

        /// <summary>
        /// 审核标志
        /// </summary>
        public string REGISTER_AUDITSTATUS { get; set; }

        /// <summary>
        /// 审核结果
        /// </summary>
        public string REGISTER_AUDITRESULT { get; set; }

        /// <summary>
        /// 审核意见
        /// </summary>
        public string REGISTER_OPINION { get; set; }

        /// <summary>
        /// 退号标志
        /// </summary>
        public string REGISTER_REFUNDSTATUS { get; set; }

        /// <summary>
        /// 退号类型
        /// </summary>
        public string REGISTER_REFUNDTYPE { get; set; }

        /// <summary>
        /// 退号原因
        /// </summary>
        public string REGISTER_REFUNDREASON { get; set; }

        /// <summary>
        /// 预约记录状态标识
        /// </summary>
        public string REGISTER_STATUS { get; set; }
    }
}
