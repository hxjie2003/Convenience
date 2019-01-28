using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETong.Services.DeliveryAddress
{
    public class DeliveryAddressService
    {
        private readonly string _memberApiUrl;

        public DeliveryAddressService(string memberApiUrl)
        {
            _memberApiUrl = memberApiUrl;
        }

        public void SaveOrUpdate(Delivery delivery)
        {
            
        }

        public Delivery Get(string memberId, string delivId, bool isDefault)
        {
            return null;
        }

        public void Delete(string deliveryId)
        {
            
        }

    }
}
