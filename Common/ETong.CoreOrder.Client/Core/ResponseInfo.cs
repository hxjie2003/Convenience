using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Core
{
    /// <summary>
    /// 响应信息
    /// </summary>
    /// <typeparam name="T">响应类型</typeparam>
    public class ResponseInfo<T>
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
        /// <summary>
        /// 响应代码
        /// </summary>
        public string respCode { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string respMsg { get; set; }
        /// <summary>
        /// 响应时间
        /// </summary>
        public string respTime { get; set; }
    }
}
