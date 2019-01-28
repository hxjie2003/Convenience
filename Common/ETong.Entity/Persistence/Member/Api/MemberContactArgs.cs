using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{

    /// <summary>
    /// 会员联系信息
    /// </summary>
    public class MemberContactArgs
    {
        public MemberContactArgs()
        {

        }

        public MemberContactArgs(MemberContactResult result)
        {
            this.CardId = result.ID_CARD;
            this.UserName = result.USERNAME;
            this.Sex = result.SIX ?? 2;
            this.Mobile = result.MOBILE;
            this.Email = result.EMAIL;
            this.MemberId = result.MEMBER_ID;
            this.CreateTime = result.GMT_CREATE;
            this.ModifyTime = result.GMT_MODIFY;
            this.ContactId = result.MC_ID;

        }
        /// <summary>
        /// 流水号  
        /// </summary>
        public string ContactId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 性别：1男，0女  
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 手机号码 
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 所属会员
        /// </summary>
        public string MemberId { get; set; }

    }
}