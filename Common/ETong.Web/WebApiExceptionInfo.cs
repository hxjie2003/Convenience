using Newtonsoft.Json;

namespace ETong.Web
{
    /// <summary>
    /// Info of exception
    /// </summary>
    public class WebApiExceptionInfo
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }

        public string StackTrace { get; set; }

        public string ExceptionType { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}