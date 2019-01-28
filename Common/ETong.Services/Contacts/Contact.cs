using System;
using Newtonsoft.Json;

namespace ETong.Services.Contacts
{
    public class Contact
    {
        /// <summary>
        /// 流水号  
        /// </summary>
        [JsonProperty("ContactId")]
        public string Id { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
         [JsonProperty("CardId")]
        public string IdCard { get; set; }

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