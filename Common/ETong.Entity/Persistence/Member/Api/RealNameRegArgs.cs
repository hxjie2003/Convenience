using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    public class RealNameRegArgs
    {
        /// <summary>
        /// 身份证姓名
        /// </summary>     
        public string RealName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>     
        public string IdCard { get; set; }
        /// <summary>
        /// 生日
        /// </summary>     
        public string Birthday { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string LocalIp { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Mobile { get; set; }
    }
}
