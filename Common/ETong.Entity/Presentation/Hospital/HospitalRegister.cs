// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HospitalRegister.cs" company="ETong">
//   医院预约挂号
// </copyright>
// <summary>
//   Defines the HospitalRegister type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Hospital
{
    /// <summary>
    /// 挂号实体
    /// </summary>
    public class HospitalRegister
    {
        /// <summary>
        /// 提交预约挂号返回结果实体
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 预约卡号
        /// </summary>
        public string cardId { get; set; }

        /// <summary>
        /// 注意事项
        /// </summary>
        public string attention { get; set; }
    }
}
