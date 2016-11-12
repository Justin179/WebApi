using WebApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        // 先稿後程
        // make Contact[]
        Contact[] contacts = new Contact[]
        {
            new Contact(){Id=0,FirstName = "Justin",LastName = "Chen"},
            new Contact(){Id=1,FirstName = "Kobe",LastName = "Bryant"},
            new Contact(){Id=2,FirstName = "Michael",LastName = "Jordan"}
        };

        
        // GET api/contact
        [Route("")]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET api/contact/5
        [Route("{id:int:min(1)}")]
        public IHttpActionResult Get(int id)
        {

            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [Route("{name}")]
        public IEnumerable<Contact> GetContactByName(string name)
        {

            Contact[] contactsByNames =
                contacts.Where<Contact>(c => c.FirstName.Contains(name)).ToArray<Contact>();

            return contactsByNames;
        }

        // POST api/contact
        [Route("")]
        public IEnumerable<Contact> Post([FromBody]Contact newContact)
        {

            List<Contact> contactList = contacts.ToList<Contact>();
            newContact.Id = contactList.Count;
            contactList.Add(newContact);
            contacts = contactList.ToArray();

            return contacts;
        }

        // PUT api/contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Put(int id, [FromBody]Contact changedContact)
        {

            Contact contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact != null)
            {
                contact.FirstName = changedContact.FirstName;
                contact.LastName = changedContact.LastName;
            }

            return contacts;
        }
        
        // DELETE api/contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Delete(int id)
        {

            contacts = contacts.Where<Contact>(c => c.Id != id).ToArray<Contact>();

            return contacts;
        }



    }
}
