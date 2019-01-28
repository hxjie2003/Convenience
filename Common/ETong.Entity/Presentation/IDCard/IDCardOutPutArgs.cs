using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.IDCard
{
    public class IDCardOutPutArgs
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 可用于前端显示的错误信息
        /// </summary>
        public string DisplayErrorMessage { get; set; }

        /// <summary>
        /// 卡名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 卡号码
        /// </summary>
        public string IdNumber { get; set; }
    }
}
