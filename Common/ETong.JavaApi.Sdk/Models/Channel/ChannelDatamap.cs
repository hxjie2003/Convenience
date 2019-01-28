using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class ChannelDatamap
    {
        public Channel channel { get; set; }
    }

    public class Channel
    {
        public string channelId { get; set; }
        public string name { get; set; }
        public string displyName { get; set; }
        public string code { get; set; }
        public string logoImg { get; set; }
        public int sortNum { get; set; }
        public string themeId { get; set; }
        public string channelPid { get; set; }
        public string channelPath { get; set; }
        public string channelTypeId { get; set; }
        public string keywords { get; set; }
        public string displayId { get; set; }
        public string description { get; set; }
        public int isEnable { get; set; }
        public int isDelete { get; set; }
        public long createDate { get; set; }
        public string creator { get; set; }
        public long modifyDate { get; set; }
        public string modifyor { get; set; }
        public string displayCode { get; set; }
        public string themeCode { get; set; }
        public string productDisplayName { get; set; }
        public string fmtCreateDate { get; set; }
    }

}
