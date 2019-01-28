using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using System.Diagnostics;
using log4net.Util;

namespace ETong.Log.Sdk
{
    public class LoggerMgr
    {
        public static ILog GetLogger<T>() where T : class
        {
            return LogManager.GetLogger(typeof(T));
        }

        public static void Debug(string msg, bool console = false)
        {
            //调用堆栈
            StackTrace trace = new StackTrace();
            //调用本方法的方法
            MethodBase method = trace.GetFrame(1).GetMethod();
            Type type = method.DeclaringType;
            string methName = method != null ? method.Name : string.Empty;
            string message = "[" + methName + "(...)]" + msg;

            //var type = MethodBase.GetCurrentMethod().DeclaringType;
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.DebugExt(message);

            if (console)
            {
                Console.WriteLine(msg);
            }
        }

        public static void Info(string msg, bool console = false)
        {
            //调用堆栈
            StackTrace trace = new StackTrace();
            //调用本方法的方法
            MethodBase method = trace.GetFrame(1).GetMethod();
            Type type = method.DeclaringType;
            string methName = method != null ? method.Name : string.Empty;
            string message = "[" + methName + "(...)]" + msg;

            //var type = MethodBase.GetCurrentMethod().DeclaringType;
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.InfoExt(message);

            if (console)
            {
                Console.WriteLine(msg);
            }
        }

        public static void Warn(string msg, bool console = false)
        {
            //调用堆栈
            StackTrace trace = new StackTrace();
            //调用本方法的方法
            MethodBase method = trace.GetFrame(1).GetMethod();
            Type type = method.DeclaringType;
            string methName = method != null ? method.Name : string.Empty;
            string message = "[" + methName + "(...)]" + msg;

            //var type = MethodBase.GetCurrentMethod().DeclaringType;
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.WarnExt(message);

            if (console)
            {
                Console.WriteLine(msg);
            }
        }

        public static void Fatal(string msg, bool console = false)
        {
            //调用堆栈
            StackTrace trace = new StackTrace();
            //调用本方法的方法
            MethodBase method = trace.GetFrame(1).GetMethod();
            Type type = method.DeclaringType;
            string methName = method != null ? method.Name : string.Empty;
            string message = "[" + methName + "(...)]" + msg;

            //var type = MethodBase.GetCurrentMethod().DeclaringType;
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.FatalExt(message);

            if (console)
            {
                Console.WriteLine(msg);
            }
        }

        public static void Error(string msg, Exception ex = null, bool console = false)
        {
            //调用堆栈
            StackTrace trace = new StackTrace();
            //调用本方法的方法
            MethodBase method = trace.GetFrame(1).GetMethod();
            Type type = method.DeclaringType;
            string methName = method != null ? method.Name : string.Empty;
            string message = "[" + methName + "(...)]" + msg;

            //var type = MethodBase.GetCurrentMethod().DeclaringType;
            log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.ErrorExt(message, ex);

            if (console)
            {
                Console.WriteLine(msg);
            }
        }

    }
}
