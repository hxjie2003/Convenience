using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    [Serializable]
    public class PaginationDataTable
    {
        /// <summary>
        /// 返回的数据
        /// </summary>
        public DataTable Data { get; set; }
        

        /// <summary>
        /// 分页的大小
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 起始页
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 记录数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 执行状态
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 执行结果响应码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 简要错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 详细错误信息
        /// </summary>
        public string MessageDetail { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }
    }
}
