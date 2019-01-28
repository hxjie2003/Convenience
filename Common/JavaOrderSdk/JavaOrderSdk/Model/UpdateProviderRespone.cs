using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaOrderSdk.Model
{
   
        public class UpdateProviderRespone
        {
            public string sign { get; set; }
            public string reqTime { get; set; }
            public UpdateProviderResopneBody dataMap { get; set; }
            public string respCode { get; set; }
            public string respMsg { get; set; }
            public string respTime { get; set; }
        }

        public class UpdateProviderResopneBody
        {
            public string memberId { get; set; }
        }

 
}
