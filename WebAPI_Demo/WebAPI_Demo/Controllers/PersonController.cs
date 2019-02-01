using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Controllers
{
    public class PersonController : ApiController
    {
        // IRL: aus EF laden
        private Person[] personen = new Person[]
        {
            new Person{ID=0,Vorname="Tom",Nachname="Ate",Alter=10,Gehalt=100},
            new Person{ID=1,Vorname="Anna",Nachname="Nass",Alter=20,Gehalt=200},
            new Person{ID=2,Vorname="Peter",Nachname="Silie",Alter=30,Gehalt=300}
        };

        public IEnumerable<Person> GetPeople() => personen;

        public IHttpActionResult GetPerson(int id)
        {
            var p = personen.FirstOrDefault(x => x.ID == id);
            if (p != null)
                return Ok(p);
            else
                return NotFound();
        }

    }
}
