using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Menu
{  
    /// <summary>
    /// 链接项
    /// </summary>
    public class LinkItem
    {      
        /// <summary>
        /// 序号
        /// </summary>
        public int seq;

        public string id;
        public string pid;
        public string text;
        public string icon;
        public string url;
        public string target;
        public string remark;
        public int status;

    }
}
