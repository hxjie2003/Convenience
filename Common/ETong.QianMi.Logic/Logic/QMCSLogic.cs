using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qianmi.Api;
using Qianmi.Api.Request;
using Qianmi.Api.Response;

namespace ETong.QianMi.Logic
{
    public class QMCSLogic
    {
        /// <summary>
        /// 为已授权的用户开通消息服务
        /// </summary>
        /// <returns>是否成功</returns>
        public QmcsUserPermitResponse UserPermit()
        {
            QmcsUserPermitResponse response = null;

            try
            {
                IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL, ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

                QmcsUserPermitRequest req = new QmcsUserPermitRequest();

                response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        /// <summary>
        /// 取消用户的消息服务
        /// </summary>
        /// <param name="user_Id">用户编号,如：A854800</param>
        /// <returns></returns>
        public QmcsUserCancelResponse UserCancel(string user_Id)
        {
            QmcsUserCancelResponse response = null;

            try
            {
                IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL, ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

                QmcsUserCancelRequest req = new QmcsUserCancelRequest();
                req.UserId = user_Id;

                response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        /// <summary>
        /// 获取用户已开通消息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="fields">需要返回的字段，多个字段之间以逗号分隔</param>
        /// <returns> 用户消息 </returns>
        public QmcsUserGetResponse UserGet(string userId, string fields = "user_id,group_name,topics")
        {
            QmcsUserGetResponse response = null;

            try
            {
                IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL, ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

                QmcsUserGetRequest req = new QmcsUserGetRequest();

                req.UserId = userId;
                req.Fields = fields;

                response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        /// <summary>
        /// 为已开通用户添加用户分组
        /// </summary>
        /// <param name="userId">分组名称，同一个应用下需要保证唯一性，最长32个字符。添加分组后，消息通道会为用户的消息分配独立分组，但之前的消息还是存储于默认分组中。不能以default开头，default开头为系统默认组。</param>
        /// <param name="fields">用户编号列表，以半角逗号分隔</param>
        /// <returns></returns>
        public QmcsGroupAddResponse GroupAdd(string group_name, string user_ids)
        {
            QmcsGroupAddResponse response = null;

            try
            {
                IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL, ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

                QmcsGroupAddRequest req = new QmcsGroupAddRequest();

                req.GroupName = group_name;
                req.UserIds = user_ids;

                response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        /// <summary>
        /// 获取自定义用户分组列表
        /// </summary>
        /// <param name="group_names">分组列表，不传代表查询所有分组信息，但不会返回组下面的用户信息。如果应用没有设置分组则返回空。组名不能以default开头，default开头是系统默认的组。</param>
        /// <param name="page_no">页码</param>
        /// <param name="page_size">每页条数</param>
        /// <returns></returns>
        public QmcsGroupsGetResponse GroupsGet(string group_names, int page_no = 0, int page_size = 50)
        {
            QmcsGroupsGetResponse response = null;

            try
            {
                IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL, ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

                QmcsGroupsGetRequest req = new QmcsGroupsGetRequest();

                req.GroupNames = group_names;
                req.PageNo = page_no;
                req.PageSize = page_size;

                response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        /// <summary>
        /// 消费多条消息
        /// </summary>
        /// <returns></returns>
        public QmcsMessagesConsumeResponse MessagesConsume(string group_name, long quantity = 100)
        {
            QmcsMessagesConsumeResponse response = null;

            IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL,
                ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);

            QmcsMessagesConsumeRequest req = new QmcsMessagesConsumeRequest();

            req.GroupName = group_name;
            req.Quantity = quantity;

            response = client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);

            return response;
        }

        public QmcsMessagesConfirmResponse ConfirmMessage(List<string> messages)
        {

            IOpenClient client = new DefaultOpenClient(ETong.QianMi.Logic.Authorize.API_SERVER_URL,
                ETong.QianMi.Logic.Authorize.APP_KEY, ETong.QianMi.Logic.Authorize.APP_SECRET);            
            QmcsMessagesConfirmRequest req = new QmcsMessagesConfirmRequest();
            req.SMessageIds = string.Join(",", messages);

            return client.Execute(req, ETong.QianMi.Logic.Authorize.ACCESS_TOKEN);
        }

    }
}
