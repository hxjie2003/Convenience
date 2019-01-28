using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Upgrade
{
    public class FolderExeModel
    {
        /// <summary>
        /// Exe所在的文件夹
        /// </summary>
        public string Folder;
        /// <summary>
        /// Exe文件集合（可能存在一对多的状况）
        /// </summary>
        public string FileName;
        /// <summary>
        /// 是否更新程序Exe
        /// </summary>
        public bool IsUpgrade;      
        /// <summary>
        /// 是否需要关闭(通得分析文件夹得到此值  默认需要关闭)
        /// </summary>
        public bool IsNeedClose = true;
        /// <summary>
        /// 是否需要启动(通过分析文件夹得到此值  默认需要启动)
        /// </summary>
        public bool IsNeedStart = true;
        /// <summary>
        /// 类型: 表示属于哪个模块   M: 监控  E: ETM Client U: 更新模块 A:广告  
        /// </summary>
        public string ExeType;
    }
    public class VersionInfo
    {
        /// <summary>
        /// 版本ID
        /// </summary>
        public int VERSION_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 版本名称
        /// </summary>
        public string VERSION_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 版本代码
        /// </summary>
        public string VERSION_CODE
        {
            get;
            set;
        }
        /// <summary>
        /// 版本类型  升级 或 完整
        /// </summary>
        public string VERSION_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int STATUS
        {
            get;
            set;
        }
        /// <summary>
        /// 文件编号
        /// </summary>
        public int FILE_ID
        {
            get;
            set;
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FILE_NAME
        {
            get;
            set;
        }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string FILE_TYPE
        {
            get;
            set;
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        public int FILE_SIZE
        {
            get;
            set;
        }
        /// <summary>
        /// 文件状态
        /// </summary>
        public string FILE_STATUS
        {
            get;
            set;
        }
        /// <summary>
        /// 文件MD5
        /// </summary>
        public string FILE_MD5
        {
            get;
            set;
        }
        /// <summary>
        /// 文件是否已下载
        /// </summary>
        public bool IsDownLoad;
        /// <summary>
        /// 是否为当前最高版本
        /// </summary>
        public bool LastVersion;
        /// <summary>
        /// 文件下载位置
        /// </summary>
        public string Url;
    }
}
