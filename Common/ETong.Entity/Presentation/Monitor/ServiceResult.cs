using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ETong.Entity.Presentation.Monitor
{
  
   /// <summary>
   /// 服务返回结果
   /// </summary>
   public class ServiceResult
    {
       /// <summary>
       /// 状态 1：成功 -1：失败
       /// </summary>
       public int ResultState { set; get; }

       /// <summary>
       /// 命令执行返回信息
       /// </summary>
       public string ResultMessage { set; get; }

       /// <summary>
       /// 返回Josn内容
       /// </summary>
       public string ResultJosnValue { set; get; }

       /// <summary>
       /// 返回byte内容
       /// </summary>
       public  byte[] ResultByteValue { set; get; }
    }
}
