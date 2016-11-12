using MakeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MakeWebApi.Controllers
{
    public class ContactController : ApiController
    {
        // 先稿後程
        // make Contact[]
        Contact[] contacts = new Contact[]
        {
            new Contact(){Id=1,FirstName = "Justin",LastName = "Chen"},
            new Contact(){Id=2,FirstName = "Kobe",LastName = "Bryant"},
            new Contact(){Id=3,FirstName = "Michael",LastName = "Jordan"}
        };

        
        // GET api/contact
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET api/contact/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/contact
        public void Post([FromBody]string value)
        {
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
