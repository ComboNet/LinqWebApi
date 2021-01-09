using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinqWebApi.Models;

namespace LinqWebApi.Controllers
{
    public class PersonController : ApiController
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            var ps = from p in db.Persons select p;
            return ps.AsEnumerable();
        }

        // GET: api/Person/5
        public IEnumerable<Person> Get(int id)
        {
            var ps = from p in db.Persons where p.Id == id select p;
            return ps.AsEnumerable();
        }

        // POST: api/Person
        public void Post([FromBody]Person newPerson)
        {
            db.Persons.InsertOnSubmit(newPerson);
            db.SubmitChanges();
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]Person updatePerson)
        {
            Person newPerson = db.Persons.FirstOrDefault(p => p.Id.Equals(id));
            newPerson.Name = updatePerson.Name;
            newPerson.Age = updatePerson.Age;
            db.SubmitChanges();
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
            Person deletePerson = db.Persons.FirstOrDefault(p => p.Id.Equals(id));
            db.Persons.DeleteOnSubmit(deletePerson);
            db.SubmitChanges();
        }
    }
}
