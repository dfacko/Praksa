using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.DynamicData.ModelProviders;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;

namespace WebApp.Controllers
{
    public class AppController : ApiController
    {

        static List<Osoba> popis = new List<Osoba>() { };



        // GET: api/App
            [HttpGet]
            public IHttpActionResult Get()
            {

                if (popis.Count == 0)
                {
                    return NotFound();
			    }
			    else
			    {
                    return Ok(popis);
			    }
            }

        
     

            [HttpPost]
            public IHttpActionResult Post([FromBody] Osoba person)
            {
            if (person == null) {
                return BadRequest();
                }
            popis.Add(person);
            return Ok();
            }

            [HttpPost]
            public HttpResponseMessage Post([FromUri]string name,string prezime,int age)
            {


            Osoba newPerson = new Osoba(name,prezime,age);
            popis.Add(new Osoba(name,prezime,age)); 

            return Request.CreateResponse(HttpStatusCode.OK);
            }

            [HttpPut]
            public IHttpActionResult Put(string name,string surname, string newName,string newSurname, int newAge)
            {
                foreach(var person in popis)
			    {
                if (person.Name == name && person.Surname==surname) {
                    person.Name = newName;
                    person.Age = newAge;
                    person.Surname = newSurname;
                    return Ok();
                }

			    }
                return NotFound();


            }
            
            [HttpDelete]
            public IHttpActionResult Delete([FromBody]string name)
            {
                foreach(var person in popis){
                    if (person.Name == name) {
                        popis.Remove(person);
                        return Ok();
                    }

			    }
                return BadRequest();
                
            }
        
    }
}


