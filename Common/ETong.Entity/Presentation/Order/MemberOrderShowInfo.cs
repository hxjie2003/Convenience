using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Order
{
    public class MemberOrderShowInfo
    {
        /// <summary>
        /// 订单显示信息
        /// </summary>
        public List<MemberOrderShowInfoItem> OrderShowInfo { get; set; }
        /// <summary>
        /// 订单明细显示信息
        /// </summary>
        public List<MemberOrderShowInfoItem> OrderDetailShowInfo { get; set; }

        public MemberOrderShowInfo()
        {
            OrderShowInfo = new List<MemberOrderShowInfoItem>();
            OrderDetailShowInfo = new List<MemberOrderShowInfoItem>();
        }
    }

    public class MemberOrderShowInfoItem
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Value { get; set; }
    }
}
