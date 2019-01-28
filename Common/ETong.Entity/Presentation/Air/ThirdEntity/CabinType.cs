using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Air
{
    /// <summary>
    /// 舱位枚举
    /// </summary>
    public enum CabinType
    {

        /// <summary>
        /// 所有 
        /// </summary>
        All=0,

        /// <summary>
        /// 头等舱 
        /// </summary>
        First = 1,

        /// <summary>
        /// 公务舱
        /// </summary>
        Business = 2,

        /// <summary>
        /// 经济舱
        /// </summary>
        Tourist = 3,

    }

    /// <summary>
    /// 机票查询请求来源
    /// </summary>
    public enum RequestFrom
    {

        /// <summary>
        /// ETM
        /// </summary>
        ETM = 2,

        /// <summary>
        /// APP
        /// </summary>
        APP = 3,

        /// <summary>
        /// PC
        /// </summary>
        PC = 5,
    }
}
