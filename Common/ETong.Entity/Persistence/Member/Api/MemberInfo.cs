using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    /// <summary>
    /// 会员信息
    /// </summary>
    public class MemberInfo
    {
        /*Member*/

        /// <summary>
        /// 会员id
        /// </summary>
        public string MEMBER_ID { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string EMAIL { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string USERNAME { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MOBILE { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        public string PASSWD { get; set; }

        /// <summary>
        /// 会员状态，0-正常，1-禁用。
        /// </summary>
        public int? STATE { get; set; }
        /// <summary>
        /// 激活状态, 0-激活，1-未激活
        /// </summary>
        public int? ACTIVATE { get; set; }
        /// <summary>
        /// 会员类型:0-普通会员,1-商家
        /// </summary>
        public int? TYP { get; set; }

        /// <summary>
        /// 注册来源：app,etm,互联网商城
        /// </summary>
        //public int? REG_FROM { get; set; }

        /// <summary>
        /// 注册ip
        /// </summary>
        public string REG_IP { get; set; }

        /// <summary>
        /// 会员扩展字段
        /// </summary>
        //public string FEATURE { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        //public DateTime? GMT_REG { get; set; }

        /// <summary>
        /// 等级id
        /// </summary>
        public string LEVEL_ID { get; set; }

        /*Person*/

        /// <summary>
        /// 流水号
        /// </summary>
        public string PERSON_ID { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TRUE_NAME { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string ID_CARD { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string BIRTHDAY { get; set; }
        /// <summary>
        /// 性别：0男，1女, 2保密
        /// </summary>
        public int? SEX { get; set; }

        /// <summary>
        /// 证件A面文件URL
        /// </summary>
        //public string CARD_FRONT { get; set; }

        /// <summary>
        /// 证件B面文件URL
        /// </summary>
        //public string CARD_BACK { get; set; }

        /// <summary>
        /// 实名审核状态,0=待处理，1=审核通过，2=审核不通过。
        /// </summary>
        //public int? AUDIT_STATUS { get; set; }

        /*MEMBER_LEVEL*/

        /// <summary>
        /// 会员等级名称
        /// </summary>
        public string LEVEL_NAME { get; set; }

        /// <summary>
        /// 是否默认等级
        /// </summary>
        public int? IS_DEFAULT { get; set; }

        /// <summary>
        /// 所需积分
        /// </summary>
        public int? SCORE { get; set; }

        /// <summary>
        /// 会员登录次数
        /// </summary>
        public int? LOGIN_NUMBER { get; set; }

        /// <summary>
        /// 最后登录日期
        /// </summary>
        public DateTime? GMT_LOGIN { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LOGIN_IP { get; set; }

        /// <summary>
        /// 是否已经实名注册
        /// </summary>
        public int? AUDIT_STATUS { get; set; }  
    }
}
