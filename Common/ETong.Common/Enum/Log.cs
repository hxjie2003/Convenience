using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Common.Enum
{
    public class Log
    {
        public enum Log_Type
        {
            /// <summary>
            /// 致命错误
            /// </summary>
            Fatal,

            /// <summary>
            /// 一般错误
            /// </summary>
            Error,

            /// <summary>
            /// 警告
            /// </summary>
            Warn,
            /// <summary>
            /// 一般信息
            /// </summary>
            Info,

            /// <summary>
            /// 调试信息
            /// </summary>
            Debug
        }
    }
}
