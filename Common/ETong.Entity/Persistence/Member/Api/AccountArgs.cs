using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    [Serializable]
    public class AccountArgs
    {

        //ID
        public string OftenAccountId { get; set; }

        //会员ID
        public string MemberId { get; set; }
        // 账号类型，0:借记卡,1:信用卡,2：存折,默认值为0
        public int AccountType { get; set; }
        // 联系电话号码
        public string PayeeMobile { get; set; }
        // 账户名
        public string PayeeName { get; set; }
        // 转入银行城市(市、县)
        public string PayeeCity { get; set; }
        // 转入账户银行
        public string PayeeBank { get; set; }
        // 转入银行账（卡）号
        public string PayeeAccount { get; set; }
        // 信息标记，0：转入账户，1：转出账户
        public string AccountMark { get; set; }
        //城市名
        public string CityName { get; set; }
        // 省份
        public string CityPath { get; set; }
        // 转入银行行号
        public string PayeeBankNo { get; set; }

        // （标示为默认账户，0：不是默认账户 1：默认账户）
        public int PayeeDefaultAccount { get; set; }
    }
}
