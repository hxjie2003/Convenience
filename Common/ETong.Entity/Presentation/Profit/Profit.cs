using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation
{



    /// <summary>
    /// 分润列表参数
    /// </summary>
    public class ProfitArgs
    {
        public string memberId { get; set; }
        public string profitStatus { get; set; }
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public string profitType { get; set; }
        public string profitEtmId { get; set; }
        public string profitScope { get; set; }
        public string curPage { get; set; }
        public string pageSize { get; set; }
    }


    /// <summary>
    /// 分润账户信息参数
    /// </summary>
    public class ProfitMemberArgs
    {
        public string memberId { get; set; }
    }

    /// <summary>
    /// ETM分润参数
    /// </summary>
    public class EtmMemberArgs
    {
        public string memberId { get; set; }
        public string etmCode { get; set; }
        public string curPage { get; set; }
        public string pageSize { get; set; }
    }



    /// <summary>
    /// ETM列表
    /// </summary>
    public class AgentdealerdrivervoJson
    {
        public Agentdealerdriverlist[] agentDealerDriverList { get; set; }
        public string memberId { get; set; }
    }

    public class Agentdealerdriverlist
    {
        public string id { get; set; }
        public string driverType { get; set; }
        public string agentId { get; set; }
        public string dealerId { get; set; }
        public string propertyType { get; set; }
        public string propertyDate { get; set; }
        public string driverIp { get; set; }
        public string driverCode { get; set; }
        public string activeState { get; set; }
        public string activeBy { get; set; }
        public string activeDate { get; set; }
        public string setupBy { get; set; }
        public string setupDate { get; set; }
        public string lastReportDate { get; set; }
        public string driverState { get; set; }
        public string addressProvince { get; set; }
        public string addressCity { get; set; }
        public string addressArea { get; set; }
        public string addressPath { get; set; }
        public string addressLocation { get; set; }
        public string addressMapGis { get; set; }
        public string circumferenceNote { get; set; }
        public string remark { get; set; }
        public string memberId { get; set; }
        public string locationId { get; set; }
        public string stringitude { get; set; }
        public string latitude { get; set; }
        public string memberName { get; set; }
        public string contactMobile { get; set; }
        public string storeName { get; set; }
        public Agentvo agentVO { get; set; }
        public Agentdealervo agentDealerVO { get; set; }
        public string activeDateText { get; set; }
        public string setupDateText { get; set; }
        public string lastReportDateText { get; set; }
        public string propertyDateText { get; set; }
        public string driverStateText { get; set; }
        public string propertyTypeText { get; set; }
        public string driverTypeText { get; set; }
    }

    public class Agentvo
    {
        public string id { get; set; }
        public string companyName { get; set; }
        public string companyType { get; set; }
        public string companyIndustryType { get; set; }
        public string companyProfile { get; set; }
        public string addressProvince { get; set; }
        public string addressCity { get; set; }
        public string addressArea { get; set; }
        public string addressPath { get; set; }
        public string addressLocation { get; set; }
        public string addressZipcode { get; set; }
        public string addressMapGis { get; set; }
        public string contactName { get; set; }
        public string contactTel { get; set; }
        public string contactFax { get; set; }
        public string contactMobile { get; set; }
        public string contactQQ { get; set; }
        public string contactEmail { get; set; }
        public string approveBy { get; set; }
        public string approveState { get; set; }
        public string approveComment { get; set; }
        public string approveDate { get; set; }
        public string remark { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public string updatedBy { get; set; }
        public string updatedDate { get; set; }
        public string memberId { get; set; }
        public string approveDateText { get; set; }
        public string createdDateText { get; set; }
        public string updatedDateText { get; set; }
    }

    public class Agentdealervo
    {
        public string id { get; set; }
        public string agentId { get; set; }
        public string dealerName { get; set; }
        public string dealerType { get; set; }
        public string addressProvince { get; set; }
        public string addressCity { get; set; }
        public string addressArea { get; set; }
        public string addressPath { get; set; }
        public string addressLocation { get; set; }
        public string addressZipcode { get; set; }
        public string addressMapGis { get; set; }
        public string contactName { get; set; }
        public string contactTel { get; set; }
        public string contactFax { get; set; }
        public string contactMobile { get; set; }
        public string contactQQ { get; set; }
        public string contactEmail { get; set; }
        public string approveBy { get; set; }
        public string approveState { get; set; }
        public string approveComment { get; set; }
        public string approveDate { get; set; }
        public string remark { get; set; }
        public string createdBy { get; set; }
        public string createdDate { get; set; }
        public string updatedBy { get; set; }
        public string updatedDate { get; set; }
        public string memberId { get; set; }
        public string approveDateText { get; set; }
        public string createdDateText { get; set; }
        public string updatedDateText { get; set; }
    }

    /// <summary>
    /// 分润列表
    /// </summary>
    public class ProfitlistJson
    {
        public Profitlist[] profitList { get; set; }
        public string memberId { get; set; }
    }

    public class Profitlist
    {
        public string profitEtmId { get; set; }
        public string grossProfit { get; set; }
        public string profitTypeText { get; set; }
        public string orderFrom { get; set; }
        public string remark { get; set; }
        public string orderPayType { get; set; }
        public string orderEtmId { get; set; }
        public string orderProviderId { get; set; }
        public string orderPayTypeName { get; set; }
        public string id { get; set; }
        public string orderAmount { get; set; }
        public string memberTierText { get; set; }
        public string memberName { get; set; }
        public string memberTier { get; set; }
        public string orderTypeName { get; set; }
        public string orderId { get; set; }
        public string profitStatus { get; set; }
        public string orderStatusName { get; set; }
        public string orderType { get; set; }
        public string agentId { get; set; }

        public string orderMemberId { get; set; }
        public string profitStatusText { get; set; }
        public string orderStatus { get; set; }
        public string profitEtmMasterName { get; set; }
        public string orderTotalAmount { get; set; }
        public string orderMemberName { get; set; }
        public string profitEtmMaster { get; set; }
        public string agentName { get; set; }
        public string profitAmount { get; set; }
        public string memberId { get; set; }
        public string profitType { get; set; }
        public string orderFromName { get; set; }
        public string createDateText { get; set; }
    }

    /// <summary>
    /// 分润账户类
    /// </summary>
    public class ProfitJson
    {
        public string memberId { get; set; }
        public Profitaccountvo profitAccountVO { get; set; }
    }
    public class Profitaccountvo
    {
        public string alreadyAmount { get; set; }
        public string memberAmount { get; set; }
        public string etmPredictAmount { get; set; }
        public string agentAmount { get; set; }
        public string uncollectedAmount { get; set; }
        public string predictAmount { get; set; }
        public string isDisabled { get; set; }
        public string id { get; set; }
        public string memberPredictAmount { get; set; }
        public string totalAmount { get; set; }
        public string memberId { get; set; }
        public string memberName { get; set; }
        public string createDateText { get; set; }
        public string etmAmount { get; set; }
        public string modifyDateText { get; set; }
        public string agentPredictAmount { get; set; }
        public string memberUncollectedAmount { get; set; }
        public string totalMemberAmount { get; set; }
        public string etmUncollectedAmount { get; set; }
        public string totalEtmAmount { get; set; }
        public string agentUncollectedAmount { get; set; }
        public string totalAgentAmount { get; set; }

    }

}
