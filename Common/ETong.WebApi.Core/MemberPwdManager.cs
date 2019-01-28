using ETong.WebApi.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.WebApi.Core
{
    public class MemberPwdManager
    {
        public static string GetPassword(string memberid)
        {
            ApiSetting setting = new ApiSetting(null);
            if (memberid.ToLower().Trim() == setting.DefaultMemberId.ToLower().Trim())
            {
                return setting.DefaultMemberPwd;
            }
            string password;
            using (var membercontext = new MemberDbContext())
            {
                var member = membercontext.MEMBER.FirstOrDefault(o=>o.MEMBER_ID==memberid);
                if (member == null)
                    throw new Exception("不存在会员号:" + memberid);
                password = member.PASSWD;
            }
            return password;
        }
    }
}
