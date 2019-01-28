//-----------------------------------------------------------------------
// <copyright file="MediaTypeEnum.cs"  company="Etong">
//     定义Response的响应格式
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.WebApiUtility.Entity
{
    /// <summary>
    /// 响应格式
    /// </summary>
    public enum MediaTypeEnum
    {
        /// <summary>
        /// XML格式
        /// </summary>
        Xml,

        /// <summary>
        /// JSON格式
        /// </summary>
        Json,

        /// <summary>
        /// 原始的格式
        /// </summary>
        Plain
    }
}
