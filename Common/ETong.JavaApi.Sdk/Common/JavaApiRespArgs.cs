using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    /// <summary>
    /// java open plat响应参数
    /// </summary>
    public class JavaApiRespArgs<T>
    {
        /// <summary>
        /// 加密验证码
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 请求时间,格式YYYYMMDDHHMISS
        /// </summary>
        public string reqTime { get; set; }

        /// <summary>
        /// 请求或相应数据
        /// </summary>
        public T dataMap { get; set; }

        /// <summary>
        /// "响应码,0表示请求成功,其他表示请求失败
        /// </summary>
        public string respCode { get; set; }

        /// <summary>
        /// 响应码对应的文本
        /// </summary>
        public string respMsg { get; set; }

        /// <summary>
        /// 响应时间,格式YYYYMMDDHHMISS
        /// </summary>
        public string respTime { get; set; }
    }

}
