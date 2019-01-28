using ETong.WebApi.Server.Filters;
using ETong.WebApi.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ETong.WebApi.Server.Demo.Controllers
{
   [SignValidateActionFilter]
    public class ValuesController : ApiController
    {
    
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            throw new ErrorCodeException("5", "大件事了！");
            return id.ToString();
        }

        // POST api/values
        public string Post([FromBody]testobject value,string ak)
        {
            return value.name;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class testobject
    {
       public string name { get; set; }

        public int age { get; set; }
    }
}
