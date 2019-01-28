using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ETong.Entity.Persistence.Shop
{
    /// <summary>
    /// 返回参数
    /// </summary>
    public class ShopApiResult
    {
        public ShopApiResult()
        {
            ExecuteState = false;
            BusinessState = false;
            ErrorType = ErrorType.NoError;
        }

        /// <summary>
        /// 执行结果状态
        /// </summary>
        public bool ExecuteState { get; set; }

        /// <summary>
        /// 业务状态 如第三方执行结果状态,默认false
        /// </summary>
        public bool BusinessState { get; set; }

        /// <summary>
        /// 错误类型
        /// </summary>
        public ErrorType ErrorType { get; set; }

        /// <summary>
        /// 原始错误
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 执行结果描述（定制的友好错误提示）
        /// </summary>
        public string DisplayMessage { get; set; }

        public object Value1 { get; set; }

        public object Value2 { get; set; }

        public object Value3 { get; set; }

        public object Value4 { get; set; }

        public object Value5 { get; set; }

        public object Value6 { get; set; }

        public object Value7 { get; set; }

        public object Value8 { get; set; }
    }
    public enum ErrorType
    {
        NoError = 0,

        RequestTimeout = 1,

        RequestReturnError = 2,

        LocalDataFailed = 3,

        NotFindTask = 4,
    }
}
