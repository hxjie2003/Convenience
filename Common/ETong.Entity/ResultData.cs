using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity
{
    /// <summary>
    /// API返回参数.后续兼容版本中不再使用。
    /// </summary>
    /// <typeparam name="T">数据</typeparam>
    [Obsolete]
    public class ResultData<T>
    {
        public ResultData(string code, bool success, string message,T data)
            : this("1.0",success, code, message,data)
        { }

        public ResultData(string version, bool success, string code, string message, T data)
        {
            this.Version = version;
            this.Success = success;
            this.Code = code;
            this.Message = message;
            this.Data = data;

        }

        public ResultData()
            : this("200", true, null,default(T))
        {
        }

        /// <summary>
        ///版本号
        /// </summary>
        public string Version { get; set; }

        private string _code;
        /// <summary>
        /// 响应码
        /// </summary>
        public string Code
        {
            get { return _code; }
            set
            {
                this._code = value;
                //if (value.Length == 3 && value.StartsWith("2"))
                //{
                //    this.Success = true;
                //}
            }
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// 页面显示信息
        /// </summary>
        public string DisplayMessage { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
    }
}
