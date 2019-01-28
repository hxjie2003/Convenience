using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class ChannelCategoryDatamap
    {
        public ChannelCategorylist[] categoryList { get; set; }
    }

    public class ChannelCategorylist : ChannelCategory
    {
        public ChannelCategory[] categorys { get; set; }
    }

    public class ChannelCategory
    {
        public string categoryId { get; set; }
        public string isDelete { get; set; }
        public int sortNum { get; set; }
        public string customChannelId { get; set; }
        public string categoryImg { get; set; }
        public string parentId { get; set; }
        public string name { get; set; }
        public string pageKeywords { get; set; }
        public string pageDesc { get; set; }
        public string path { get; set; }
        public int grade { get; set; }
        public string isEnable { get; set; }
        public object createDate { get; set; }
        public object modifyDate { get; set; }
        public string modifyor { get; set; }
        public string creator { get; set; }
        public string parent { get; set; }
        public string pcCategoryImg { get; set; }
        public string appCategoryImg { get; set; }
        public string pcimg { get; set; }
        public string appimg { get; set; }
        public string etmimg { get; set; }
        public ChannelCategorymapimg categoryMapImg { get; set; }
    }
}
