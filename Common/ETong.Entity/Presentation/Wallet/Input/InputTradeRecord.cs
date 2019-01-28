using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    /// <summary>
    /// webapi输入参数基类
    /// </summary>
    public class InputTradeRecord : InputBase
    {
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 记录ID（订单ID）
        /// </summary>
        public string RecordId { get; set; }

        /// <summary>
        /// 定单类型
        /// </summary>
        public string orderType { get; set; }


        /// <summary>
        /// 收支类别
        /// </summary>
        public string payType { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        public string tradeStatus { get; set; }

        /// <summary>
        ///交易开始时间
        /// </summary>
        public string startTradeDate { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        public string endTradeDate { get; set; }
       
       
    }
}