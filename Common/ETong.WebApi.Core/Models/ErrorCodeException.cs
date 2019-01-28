using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.WebApi.Server.Models
{
    /// <summary>
    /// 带错误码的异常。
    /// </summary>
    [Serializable]
    public class ErrorCodeException : Exception
    {
        public ErrorCodeException()
        {
        }

        public ErrorCodeException(string code, string message)
            : this(code, message, message)
        {
        }

        public ErrorCodeException(string code, string message, Exception innerException)
            : base(message, innerException)
        {
            this.ErrorCode = code;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="displaymessage"></param>
        public ErrorCodeException(string code, string message, string displaymessage)
            : base(message)
        {
            this.ErrorCode = code;
            this.DisplayMessage = displaymessage;
        }

        public string ErrorCode { get; set; }

        public string DisplayMessage { get; set; }
    }
}
