using System.Management;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Reflection;

namespace ETong.Utility.OS
{
    /// <summary>
    /// 获取/设置当前计算机/程序信息
    /// </summary>
    public class EvnInfo
    {
        /// <summary>
        /// 计算机名称
        /// </summary>
        public static string MachineName
        {
            get
            {
                return System.Environment.MachineName;
            }
            set
            {
                Registry.SetValue
                    (@"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\services\Tcpip\Parameters", "Hostname", value);
            }//NV Hostname
        }

        /// <summary>
        /// 计算机描述
        /// </summary>
        public static string Description
        {
            get
            {
                return (string)Registry.GetValue
                    (@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\LanmanServer\Parameters", "srvcomment", null);
            }
            set
            {
                Registry.SetValue
                    (@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\services\LanmanServer\Parameters", "srvcomment", value);
            }
        }

        /// <summary>
        /// 计算机IP地址
        /// </summary>
        public static string IPAddress
        {
            get
            {

                string hostname = Dns.GetHostName();
                IPAddress[] ips = Dns.GetHostAddresses(hostname);
                string patten = @"\d+.\d+.\d+.\d+";
                Regex regex = new Regex(patten);

                foreach (IPAddress ip in ips)
                {
                    string ipAddress = ip.ToString();
                    if (ipAddress.Split('.').Length == 4)
                        return ipAddress;
                }

                return null;
            }
        }

        /// <summary>
        /// 计算机操作系统版本号
        /// </summary>
        public static string OSVersion
        {
            get
            {
                return (string)Registry.GetValue
                    (@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", null) + "（" + System.Environment.OSVersion.VersionString + "）";
            }
        }

        /// <summary>
        /// 系统框架版本号
        /// </summary>
        public static string CLRVersion
        {
            get
            {
                return System.Environment.Version.ToString();
            }
        }

        /// <summary>
        /// 网卡MAC地址
        /// </summary>
        public static string MacAddress
        {
            get
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        return mo["MacAddress"].ToString();
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// CPU编号
        /// </summary>
        public static string ProcessorId
        {
            get
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    return mo.Properties["ProcessorId"].Value.ToString();
                }

                return null;
            }
        }

        /// <summary>
        /// 当前运行的系统版本号
        /// </summary>
        public static string APPVersion
        {
            get
            {
                return Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
        }


        /// <summary>
        /// 浏览器IE9启用信息
        /// </summary>
        public static string WebBrowserRegisterValue
        {
            get
            {
                object val = Registry.GetValue(WebBrowserRegisterPath, System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", null);
                return val == null ? null : val.ToString();

            }
            set
            {
                Registry.SetValue(WebBrowserRegisterPath, System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", value, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// 根据系统分开32位和64位的路径
        /// </summary>
        private static string WebBrowserRegisterPath
        {
            get
            {
                string path = string.Empty;
                if (System.Environment.Is64BitOperatingSystem)
                {
                    path  = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
                }
                else
                {
                    path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
                }
                return path;
            }
        }

        /// <summary>
        /// 跨域的注册表地址
        /// </summary>
        private static string AccessDomainRegisterPath
        {
            get
            {
                string path = string.Empty;

                path = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3";

                return path;
            }
        }


        /// <summary>
        /// 浏览器IE9启用跨域
        /// </summary>
        public static string WebBrowserRegisterAccessDomain
        {
            get
            {
                object val = Registry.GetValue(AccessDomainRegisterPath, ((int)ETong.Common.Enum.Browser.Browser_SettingType.AccessDomain).ToString(), null);
                return val == null ? null : val.ToString();
            }
            set
            {
                Registry.SetValue(AccessDomainRegisterPath, ((int)ETong.Common.Enum.Browser.Browser_SettingType.AccessDomain).ToString(), value, RegistryValueKind.DWord);
            }
        }


        /// <summary>
        /// 浏览器IE9启用跨域数据访问
        /// </summary>
        public static string WebBrowserRegisterAccessData
        {
            get
            {
                object val = Registry.GetValue(AccessDomainRegisterPath, ((int)ETong.Common.Enum.Browser.Browser_SettingType.AccessData).ToString(), null);
                return val == null ? null : val.ToString();
            }
            set
            {
                Registry.SetValue(AccessDomainRegisterPath, ((int)ETong.Common.Enum.Browser.Browser_SettingType.AccessData).ToString(), value, RegistryValueKind.DWord);
            }
        }
    }
}
