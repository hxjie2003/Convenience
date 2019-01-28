using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 医生排班
    /// </summary>
    public class DoctorScheduleInfo
    {
        /// <summary>
        /// 排班ID
        /// </summary>
        public int SCHEDULE_ID
        {
            get;
            set;
        }

        /// <summary>
        /// 合作方式(4：免费号源，10：免费加号号源)
        /// </summary>
        public Nullable<short> SCHEDULE_COOPERTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 合作标志(0-平台，1—39，2－好医生，3－好大夫)
        /// </summary>
        public string SCHEDULE_PARTNERTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 合作平台排班id
        /// </summary>
        public string SCHEDULE_PARTNERSCHEID
        {
            get;
            set;
        }

        /// <summary>
        /// 合作方医生id
        /// </summary>
        public int SCHEDULE_DOCTORID
        {
            get;
            set;
        }

        /// <summary>
        /// 医生挂号费,单位：分
        /// </summary>
        public Nullable<decimal> SCHEDULE_REGFEE
        {
            get;
            set;
        }

        /// <summary>
        /// 合作方医生姓名
        /// </summary>
        public string SCHEDULE_DOCTORNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 合作方科室ID
        /// </summary>
        public int SCHEDULE_DEPARTMENTID
        {
            get;
            set;
        }

        /// <summary>
        /// 合作方科室名称
        /// </summary>
        public string SCHEDULE_DEPARTMENTNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 合作方ID
        /// </summary>
        public Nullable<int> SCHEDULE_PARTNERID
        {
            get;
            set;
        }

        /// <summary>
        /// 可预约状态 1-允许预约 2-医生停诊 3-出诊但不提供预约 4-预约已满
        /// </summary>
        public short SCHEDULE_REGISTERSTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// 出诊日期
        /// </summary>
        public Nullable<System.DateTime> SCHEDULE_WORKCALENDAR
        {
            get;
            set;
        }

        /// <summary>
        /// 星期几(1—7)
        /// </summary>
        public Nullable<short> SCHEDULE_WEEKDAY
        {
            get;
            set;
        }

        /// <summary>
        /// 早午晚标志，1：上午 2：下午 3：晚上
        /// </summary>
        public Nullable<short> SCHEDULE_SHIFTTYPE
        {
            get;
            set;
        }

        public string SCHEDULE_WORKBEGINTIME
        {
            get;
            set;
        }

        /// <summary>
        /// 门诊类型，1：普通门诊 2：专家门诊 3：特需门诊 4：专科门诊 5：会诊门诊 6：夜间门诊 7：急诊
        /// </summary>
        public Nullable<short> SCHEDULE_CLINICTYPE
        {
            get;
            set;
        }

        /// <summary>
        /// 排班时间段下标（待用)
        /// </summary>
        public string SCHEDULE_FLEXTIME
        {
            get;
            set;
        }


        /// <summary>
        /// 合作方校验值
        /// </summary>
        public string SCHEDULE_PARTNERVALID
        {
            get;
            set;
        }

        /// <summary>
        /// 出诊结束时间
        /// </summary>
        public string SCHEDULE_WORKENDTIME
        {
            get;
            set;
        }
    }
}
