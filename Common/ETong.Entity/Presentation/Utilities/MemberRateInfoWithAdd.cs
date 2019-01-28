// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberRateInfoWithAdd.cs" company="ETong">
//   收费信息
// </copyright>
// <summary>
//   用户收费单位信息，用于新增数据传输实体
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Utilities
{
    /// <summary>
    /// 用户收费单位信息
    /// </summary>
    public class MemberRateInfoWithAdd
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string memberid { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string ratenumber{ get; set; }

        /// <summary>
        /// 记录分类,0:水费，1:电费，2:燃气费 
        /// </summary>
        public string ratetype{ get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string username{ get; set; }

        /// <summary>
        /// 地址详细
        /// </summary>
        public string address{ get; set; }

        /// <summary>
        /// 联系手机号码
        /// </summary>
        public string mobile{ get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string tel{ get; set; }

        /// <summary>
        /// 是否默认,0:非默认，1：默认
        /// </summary>
        public string isdefault{ get; set; }

        /// <summary>
        /// 缴费单位编号
        /// </summary>
        public string unitsno{ get; set; }

        /// <summary>
        /// 缴费单位名称
        /// </summary>
        public string unitsname{ get; set; }

        /// <summary>
        /// 区域id
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string contents { get; set; }

    }
}
