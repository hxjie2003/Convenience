using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// 命令执行参数
    /// </summary>
    [Serializable]
   public class CommandParameter
    {
       /// <summary>
       /// 命令代码
       /// </summary>
       public string CommandCode { set; get; }

       /// <summary>
       /// 命令参数(以Json格式存储)
       /// </summary>
       public string ParameterJosnValue { set; get; }
         
       /// <summary>
       /// 参数二进制内容：可用户存放大数据
       /// </summary>
       public Byte[] ParameterByteValue { set; get; }

    }
}
