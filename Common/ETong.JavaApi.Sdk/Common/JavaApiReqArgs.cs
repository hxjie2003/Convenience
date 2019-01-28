using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    /// <summary>
    /// java open plat输入参数
    /// </summary>
    public class JavaApiReqArgs<T>
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
        /// 接口版本(String：v1)
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// 请求来源(String：1:ETM,2:PC,4:APP)
        /// </summary>
        public string reqFrom { get; set; }

        /// <summary>
        /// 请求或相应数据
        /// </summary>
        public T dataMap { get; set; }
    }

}
