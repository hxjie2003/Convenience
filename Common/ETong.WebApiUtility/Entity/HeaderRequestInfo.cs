//-----------------------------------------------------------------------
// <copyright file="HeaderRequestInfo.cs" company="Etong">
//     http输入的头实体，在request中提供系统级的参数
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace ETong.WebApiUtility.Entity
{
    /// <summary>
    /// Http response header.
    /// </summary>
    public class HeaderRequestInfo
    {
        /// <summary>
        /// Gets or sets Application ID.
        /// </summary>
        public string AppId { get;  set; }

        /// <summary>
        /// Gets or sets time stamp
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets sign
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// Gets or sets OS.
        /// </summary>
        public OperatingSystemEnum OperatingSystem { get; set; }

        /// <summary>
        /// Gets or sets API version.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets Specify the response format,Option Values(xml,JSON).
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets Assigned to the user's authorization  Session key,By logging in authorized access
        /// </summary>
        public string Session { get; set; }
    }
}
