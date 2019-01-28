using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    /// <summary>
    /// 联系人
    /// </summary>
    public class MemberContactResult
    {
        public MemberContactResult()
        {

        }
        public MemberContactResult(MemberContactArgs value)
        {
            if (String.IsNullOrEmpty(value.MemberId))
                throw new ArgumentNullException("value", "MemberId can't be null.");
            this.ID_CARD = value.CardId;
            this.USERNAME = value.UserName;
            this.SIX = value.Sex;
            this.MOBILE = value.Mobile;
            this.EMAIL = value.Email;
            this.MEMBER_ID = value.MemberId;
            this.GMT_CREATE = value.CreateTime;
            this.GMT_MODIFY = value.ModifyTime;
            this.MC_ID = value.ContactId;
        }

        /// <summary>
        /// 流水号  
        /// </summary>
        public string MC_ID { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string USERNAME { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string ID_CARD { get; set; }
        /// <summary>
        /// 性别：0男，1女  
        /// </summary>
        public int? SIX { get; set; }
        /// <summary>
        /// 手机号码 
        /// </summary>
        public string MOBILE { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string EMAIL { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? GMT_CREATE { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? GMT_MODIFY { get; set; }
        /// <summary>
        /// 所属会员
        /// </summary>
        public string MEMBER_ID { get; set; }
        /// <summary>
        /// 火车乘客信息验证，0：未通过验证，1：已通过验证，N：未验证
        /// </summary>
        public string TRAIN_VERIFY { get; set; }
        /// <summary>
        /// 生日（MM-DD）
        /// </summary>
        public string BIRTHDAY { get; set; }
        /// <summary>
        /// 与会员之间的关系
        /// </summary>
        public string RELATIONSHIP { get; set; }
        /// <summary>
        /// 具体地址
        /// </summary>
        public string ADDRESS { get; set; }
        /// <summary>
        /// 国家ID
        /// </summary>
        public string COUNTRY { get; set; }
        /// <summary>
        /// 省ID
        /// </summary>
        public string PROVINCE { get; set; }
        /// <summary>
        /// 市ID
        /// </summary>
        public string CITY { get; set; }
        /// <summary>
        /// 县、区ID
        /// </summary>
        public string DISTRICT { get; set; }
    }
}
