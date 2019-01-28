//-----------------------------------------------------------------------
// <copyright file="ResponseData.cs" company="Etong">
//     API返回结果实体
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ETong.Entity
{
    using System.Xml.Serialization;

    /// <summary>
    /// API response data entity
    /// </summary>
    /// <typeparam name="T">
    /// 泛型T，指定输出数据的类型
    /// </typeparam>
    public class ResponseData<T>
    {
        /// <summary>
        /// Gets or sets response code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets response message
        /// </summary>
        public string Message { get; set; }
            
        /// <summary>
        /// Gets or sets response Data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the success is output result
        /// </summary>
        public bool Success { get; set; }
    }
}
