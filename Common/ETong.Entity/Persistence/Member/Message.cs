using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Persistence.Member
{
    /// <summary>
    /// 未读消息接口响应类
    /// </summary>
    public class UnreadMessageRes
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string memberId { get; set; }
        /// <summary>
        /// 未读消息数
        /// </summary>
        public string unreadCount { get; set; }
        /// <summary>
        /// 总消息数量
        /// </summary>
        public string allCount { get; set; }
        /// <summary>
        /// 已读消息数
        /// </summary>
        public string readedCount { get; set; }
    }
    /// <summary>
    /// 未读消息接口请求类
    /// </summary>
    public class UnreadMessageReq
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string memberId { get; set; }
    }

    /// <summary>
    /// 抓取消息接口请求类
    /// </summary>
    public class MessagesReq {
        /// <summary>
        /// 当前页(必填)
        /// </summary>
        public string curPage { get; set; }

        /// <summary>
        /// 会员编号(必填)
        /// </summary>
        public string memberId { get; set; }
        /// <summary>
        /// 每页显示条数(必填)
        /// </summary>
        public string pageSize { get; set; }
        /// <summary>
        /// 阅读状态：1.未读，2.已读 (必填)
        /// </summary>
        public string readType { get; set; }
    }

    /// <summary>
    /// 抓取消息接口响应类
    /// </summary>
    public class MessagesRes {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string memberId { get; set; }
        /// <summary>
        /// 消息列表
        /// </summary>
        public List<Messages> messageList { get; set; }
    }

    /// <summary>
    /// 消息内容类
    /// </summary>
    public class Messages {
        /// <summary>
        /// 消息内容
        /// </summary>
        public string msgContent { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string msgLink { get; set; }
        /// <summary>
        /// 消息状态，1、未发送；2、发送成功；3、发送失败；4、失效；5、消息已读
        /// </summary>
        public string msgStatus { get; set; }
        /// <summary>
        /// 消息标题
        /// </summary>
        public string msgTitle { get; set; }
        /// <summary>
        /// 阅读时间
        /// </summary>
        public string readTime { get; set; }
        /// <summary>
        /// 消息Key
        /// </summary>
        public string sendHtyId { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public string sendTime { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string userName { get; set; }
    }
}
