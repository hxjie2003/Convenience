using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.IDCard
{
    /// <summary>
    /// 身份证信息
    /// </summary>
    public class CitizenInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别代码
        /// </summary>
        public string SexCode { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 民族代码
        /// </summary>
        public string NationCode { get; set; }

        /// <summary>
        /// 民族名称
        /// </summary>
        public string NationName { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 签发机关
        /// </summary>
        public string IssuingAuthority { get; set; }

        /// <summary>
        /// 身份证有效起始日期
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 身份证有效截止日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 有效期限代码，许多原来系统上面为了一代证考虑，常常存在这样的字段，二代证中已经没有了
        /// </summary>
        public string PeriodOfValidityCode { get; set; }

        /// <summary>
        /// 有效期限
        /// </summary>
        public string PeriodOfValidityName { get; set; }

        /// <summary>
        /// 照片二进制
        /// </summary>
        public byte[] PictureByte { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        public Image PictureImage { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public ImageSource ImageSource { get; set; } 
        
    }
}
