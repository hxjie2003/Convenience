using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Common.Enum
{
     public class Browser
    {
         /// <summary>
         /// 设置强制那个浏览器
         /// </summary>
         public enum Browser_Emulation
         {
             IE10_Default = 10001,
             IE10_DocType = 10000,
             IE9_Force = 9999,
             IE9_Default = 9000,
             IE8_Force = 8888,
             IE8_Default = 8000,
             Default = 7000
         }

         /// <summary>
         /// 浏览器设置跨域
         /// </summary>
         public enum Browser_AccessDomain
         {
             Enabled = 0,
             Disabled = 3,
             Hint = 1
         }

         /// <summary>
         /// 跨域的具体键值
         /// </summary>
         public enum Browser_SettingType
         {
             AccessDomain = 1607,
             AccessData = 1406
         }
    }
}
