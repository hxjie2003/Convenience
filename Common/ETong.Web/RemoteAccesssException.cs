using System;
using System.Net;
using System.Text;

namespace ETong.Web
{
    public class RemoteAccesssException : Exception
    {
        private readonly HttpStatusCode _httpCode;
        private readonly WebApiExceptionInfo _remoteReturnValue;

        public RemoteAccesssException(HttpStatusCode httpCode, WebApiExceptionInfo remoteReturnValue)
        {
            _httpCode = httpCode;
            _remoteReturnValue = remoteReturnValue;
        }

        public override string Message
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("http code:").Append(_httpCode)
                    .Append("(").Append(Convert.ToInt32(_httpCode)).Append(")")
                    .AppendLine("Remote Server return result is :")
                    .Append(_remoteReturnValue);
                return sb.ToString();
            }
        }
    }
}