using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    /// <summary>
    /// 会员车辆信息
    /// </summary>
    public class MemberTrafficInfo
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string MTRA_ID { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string PLATE_NUMBER { get; set; }
        /// <summary>
        /// 车辆类型：1大型汽车;2小型汽车3使馆汽车4领馆汽车5境外汽车6外籍汽车7两、三轮摩托车15挂车16教练车20临时入境汽车21临时入境摩托车22临时行驶汽车23公安警车26香港出入境车辆27澳门出入境车辆
        /// </summary>
        public int? CAR_TYPE { get; set; }
        /// <summary>
        /// 车架号
        /// </summary>
        public string CARFRAME_NUMBER { get; set; }
        /// <summary>
        /// 发动机号
        /// </summary>
        public string ENGINE_NUMBER { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string MEMBER_ID { get; set; }
        /// <summary>
        /// 会员手机
        /// </summary>
        public string MEMBER_MOBILE { get; set; }
        /// <summary>
        /// 会员手机(136****9632)
        /// </summary>
        public string MEMBER_MOBILE_SHOW { get; set; }
        /// <summary>
        /// 是否为该会员默认车辆信息
        /// </summary>
        public int? IS_DEFAULT { get; set; }
    }
}
