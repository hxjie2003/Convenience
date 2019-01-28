// <copyright file="ErrorCodeException.cs" company="ETong">
//     Copyright (c) ETong. All rights reserved.
// </copyright>
// <author>tolf</author>
using System;

namespace ETong.Entity
{
    /// <summary>
    /// 带错误码的异常。（2XX为成功的保留码，禁止将ErrorCode设置在200~299范围内）
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