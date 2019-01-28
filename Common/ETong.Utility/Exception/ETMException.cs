using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Utility.Exceptions
{
    /// <summary>
    /// 自定义异常， 可以显示在界面提示用户的错误信息。如密码错误、余额不足等。推荐使用这个异常类型来抛出，方便在try...catch结构体类过滤；
    /// 错误信息用于界面显示，innerException用于记录日志
    /// </summary>
    public class ETMException : Exception
    {
        /// <summary>
        /// 错误信息用于界面显示
        /// </summary>
        /// <param name="message">错误信息</param>
        public ETMException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 错误信息用于界面显示，innerException用于记录日志
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="innerException">内部异常</param>
        public ETMException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// 不可撤销的异常，比如超时之类的异常，因状态不明不可撤销支付，则用此异常抛出以便于处理
    /// </summary>
    public class IrrevocableException : Exception
    {
        /// <summary>
        /// 不可撤销支付的异常
        /// </summary>
        public IrrevocableException()
            : base()
        {
        }

        /// <summary>
        /// 不可撤销支付的异常
        /// </summary>
        /// <param name="message">错误信息</param>
        public IrrevocableException(string message)
            : base(message)
        {
        }

    }

}
