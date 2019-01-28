using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    /// <summary>
    /// 水电煤常用账户
    /// 生活费用代缴信息表
    /// </summary>
    public class MemberRateInfo
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string MEMBER_RATE_ID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string RATE_USERNAME { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string RATE_NUMBER { get; set; }
        /// <summary>
        /// 地址详细
        /// </summary>
        public string RATE_ADDRESS { get; set; }
        /// <summary>
        /// 记录分类,0:水费，1:电费，2:燃气费
        /// </summary>
        public int RATE_TYPE { get; set; }
        /// <summary>
        /// 联系手机号码
        /// </summary>
        public string RECEIPT_MOB { get; set; }
        /// <summary>
        /// 固定电话
        /// </summary>
        public string RECEIPT_TEL { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public int? INFO_DEFAULT { get; set; }
        /// <summary>
        /// 会员id
        /// </summary>
        public string MEMBER_ID { get; set; }
        /// <summary>
        /// 缴费单位编号
        /// </summary>
        public string UNITS_NO { get; set; }
        /// <summary>
        /// 缴费单位名称
        /// </summary>
        public string UNITS_NAME { get; set; }
        /// <summary>
        /// 平台地理ID, ETM_SYS_LOCATION.Location_ID
        /// </summary>
        public string LOCATION_ID { get; set; }
    }
}
