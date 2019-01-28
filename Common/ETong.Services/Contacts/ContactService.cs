using System;
using System.Collections.Generic;
using ETong.Web;

namespace ETong.Services.Contacts
{
    public class ContactService
    {
        private readonly string _memberAddressUrl;

        /// <summary>
        ///     Member Api的地址，如 http://memberapi.etong.com就可以
        /// </summary>
        /// <param name="memberAddressUrl"></param>
        public ContactService(string memberAddressUrl)
        {
            if (memberAddressUrl == null)
                throw new ArgumentNullException("memberAddressUrl");
            _memberAddressUrl = memberAddressUrl.TrimEnd('/') + "/api/contact";
        }

        public void Delete(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            WebApiHelper.Delete(_memberAddressUrl + "/" + id);
        }

        public void Save(Contact contact)
        {
            if (String.IsNullOrEmpty(contact.MemberId))
                throw new ArgumentNullException("contact", "contact's memberId is null.");
            WebApiHelper.Post(_memberAddressUrl, contact);
        }

        public bool IsExist(string id, string identityNumber, string memberId)
        {
            if (String.IsNullOrEmpty(identityNumber))
                throw new ArgumentNullException("contactId", "contact's identityNumber is null.");
            string param=string.Format("?id={0}&identityNumber={1}&memberId={2}",id,identityNumber,memberId);
            return WebApiHelper.Get<bool>(_memberAddressUrl + param);
           
        }

        public IList<Contact> List(string memberId)
        {
            return WebApiHelper.Get<IList<Contact>>(_memberAddressUrl + "?memberId=" + memberId);
        }
    }
}