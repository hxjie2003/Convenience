using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.PaymentCollection
{
    public class PaymentCollectionOrderInputArgs
    {
        public string MemberId
        {
            get;
            set;
        }

        public string MemberName
        {
            get;
            set;
        }

        public string ETMId
        {
            get;
            set;
        }

        public string ETMIp
        {
            get;
            set;
        }

        public decimal TotalAmount
        {
            get;
            set;
        }

        public string CollectionTypeId
        {
            get;
            set;
        }

        public string CollectionTypeName
        {
            get;
            set;
        }

        public string PayerMobile
        {
            get;
            set;
        }

        public string ReceiverId
        {
            get;
            set;
        }

        public string ReceiverName
        {
            get;
            set;
        }

        public string ReceiverRealName
        {
            get;
            set;
        }

        public string VehiclePlate
        {
            get;
            set;
        }

        public string VehicleFrame
        {
            get;
            set;
        }

        public string Engine
        {
            get;
            set;
        }
    }
}
