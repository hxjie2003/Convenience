using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Utility.Exceptions
{
    /// <summary>
    /// 生成参数异常
    /// </summary>
    public static class ExceptionExt
    {
        public  static Exception CreateExcetion(string format,params object[] args)
        {
            var message = string.Format(format, args);
            return  new Exception(message);

        }
    }
}
