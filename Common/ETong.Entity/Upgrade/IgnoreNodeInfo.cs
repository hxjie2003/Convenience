using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Upgrade
{
    /// <summary>
    /// 忽略节点信息
    /// </summary>
    public class IgnoreNodeInfo
    {
        public string FileName
        {
            get;
            set;
        }
        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelativePath
        {
            get;
            set;
        }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName
        {
            get;
            set;
        }
        /// <summary>
        /// 节点值
        /// </summary>
        public string NodeValue
        {
            get;
            set;
        }
        /// <summary>
        /// 所属模块
        /// </summary>
        public string Module
        {
            get;
            set;
        }

        public string NodeKey
        {
            get;
            set;
        }
    }
}
