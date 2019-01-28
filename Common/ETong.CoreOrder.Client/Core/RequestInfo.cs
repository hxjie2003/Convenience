using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Core
{
    /// <summary>
    /// 请求信息
    /// </summary>
    /// <typeparam name="T">请求类型</typeparam>
    public class RequestInfo<T>
    {
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public string reqTime { get; set; }
        /// <summary>
        /// 请求模型数据
        /// </summary>
        public T dataMap { get; set; }
    }
}
