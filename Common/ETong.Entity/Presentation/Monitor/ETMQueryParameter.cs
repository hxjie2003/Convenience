using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor 
{
  public   class ETMQueryParameter
    {
      /// <summary>
      /// 查询的ETM机代码
      /// </summary>
      public string[] ETMCodes { set; get; }

      /// <summary>
      /// 查询的区域代码
      /// </summary>
      public string[] LocationIds { set; get; }
    }
}
