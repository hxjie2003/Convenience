// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterUserResult.cs" company="ETong">
//   第三方平台注册会员返回结果
// </copyright>
// <summary>
//   Defines the RegisterUserResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Hospital
{
    /// <summary>
    /// 第三方平台注册会员返回结果
    /// </summary>
    public class RegisterUserResult
    {
        /// <summary>
        /// 就诊人ID
        /// </summary>
        public string registerUserId { get; set; }

        /// <summary>
        /// 账号ID
        /// </summary>
        public string uid { get; set; }
    }
}
