using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Utility.WindowsRegister
{
    /// <summary>
    /// windows注册表操作
    /// </summary>
    public class RegisterEdit
    {
        /// <summary>
        /// 通过注册表设置程序开机自动启动
        /// </summary>
        /// <param name="keyName">自定义key值</param>
        /// <param name="filePath">执行程序路径</param>
        /// <returns></returns>
        public static bool SetAutoRun(string keyName, string filePath, ref string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                RegistryKey pregKey = Registry.CurrentUser;
                RegistryKey runKey = pregKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                object oldPath = runKey.GetValue(keyName);
                if (oldPath == null || oldPath.ToString() != filePath)
                    runKey.SetValue(keyName, filePath);
                runKey.Close();

            }
            catch
            {
                try
                {
                    RegistryKey pregKey = Registry.CurrentUser;
                    RegistryKey softWare = pregKey.OpenSubKey("Software", true);
                    if (softWare == null)
                    {
                        pregKey.CreateSubKey("Software");
                        softWare = pregKey.OpenSubKey("Software", true);
                    }

                    RegistryKey Microsoft = softWare.OpenSubKey("Microsoft", true);
                    if (Microsoft == null)
                    {
                        softWare.CreateSubKey("Microsoft");
                        Microsoft = softWare.OpenSubKey("Microsoft", true);
                    }

                    RegistryKey Windows = Microsoft.OpenSubKey("Windows", true);
                    if (Windows == null)
                    {
                        Microsoft.CreateSubKey("Windows");
                        Windows = Microsoft.OpenSubKey("Windows", true);
                    }


                    RegistryKey CurrentVersion = Windows.OpenSubKey("CurrentVersion", true);
                    if (CurrentVersion == null)
                    {
                        Windows.CreateSubKey("CurrentVersion");
                        CurrentVersion = Windows.OpenSubKey("CurrentVersion", true);
                    }

                    RegistryKey Run = CurrentVersion.OpenSubKey("Run", true);
                    if (CurrentVersion == null)
                    {
                        CurrentVersion.CreateSubKey("Run");
                        Run = CurrentVersion.OpenSubKey("Run", true);
                    }

                    Run.SetValue(keyName, filePath);

                    Run.Close();
                    CurrentVersion.Close();
                    Windows.Close();
                    Microsoft.Close();
                    softWare.Close();
                    pregKey.Close();
                }
                catch (Exception ex)
                {
                    errorMessage = ex.ToString();
                    return false;
                }
            }
            return true;
        }

    }
}
