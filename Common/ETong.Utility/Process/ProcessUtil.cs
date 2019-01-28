using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Utility.Process
{
    public class ProcessUtil
    {
        /// <summary>
        /// 此函数用于判断某一外部进程是否打开
        /// </summary>
        /// <param name="processName">参数为进程名</param>
        /// <returns>如果打开了，就返回true，没打开，就返回false</returns>
        public static bool IsProcessStarted(string processName)
        {
            System.Diagnostics.Process[] temp = System.Diagnostics.Process.GetProcessesByName(processName);
            if (temp.Length > 0) return true;
            else
                return false;
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName">进程名，不含后缀.exe</param>
        public static void killProcess(string processName)
        {
            int tryTimes = 0;
            while (tryTimes < 2)
            {
                try
                {
                    var processes = System.Diagnostics.Process.GetProcessesByName(processName);
                    if (processes != null)
                    {
                        foreach (var proc in processes)
                        {
                            proc.Kill();
                            proc.WaitForExit();
                            break;
                        }
                    }
                    break;
                }
                catch
                {
                    if (tryTimes >= 1)
                    {
                        break;
                    }
                    //出异常再试一次
                    System.Threading.Thread.Sleep(1000);
                    tryTimes++;
                }
            }
        }

        public static string GetAppPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
        }

        /// <summary>
        /// 清理IE浏览器缓存
        /// </summary>
        public static void ClearIECache()
        {
            //此方法操作系统会弹出窗口显示正在清理缓存，不太好
            RunCmd("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 8");
        }

        static void RunCmd(string cmd)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            // 关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            // 重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            // 重定向标准输出
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.WriteLine("exit");
        }

        /// <summary>
        /// 开启指定进程，不依赖调用方
        /// </summary>
        /// <param name="processNameList">要打开的进程列表</param>
        public static void OpenProcesses(List<string> processNameList)
        {
            foreach (string pName in processNameList)
            {
                if (string.IsNullOrEmpty(pName))
                    continue;

                string commandText = pName;
                if (!commandText.StartsWith("\""))
                    commandText = "\"" + commandText;
                if (!commandText.EndsWith("\""))
                    commandText += "\"";

                System.Diagnostics.Process.Start(commandText);
            }

        }

        /// <summary>
        /// 执行命令文件
        /// </summary>
        /// <param name="cmdFileName">命令文件全路径</param>
        static void RunCmdFile(string cmdFileName)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = cmdFileName;
            // 关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            // 重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            // 重定向标准输出
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

        }
    }
}
