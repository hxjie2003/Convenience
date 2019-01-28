using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// ETM状态查询参数参数
    /// </summary>
    [Serializable]
    public class StatusQueryParam
    {
       /// <summary>
       /// ETM编号集合
       /// </summary>
       public string[] EtmIds { set; get; }

       /// <summary>
       /// 当前页码，为0则全部
       /// </summary>
       public int PageIndex { set; get; }
         
       /// <summary>
       /// 每页记录数，为0则全部
       /// </summary>
       public int PageSize { set; get; }

    }
}
