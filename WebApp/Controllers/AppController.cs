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
        static List<string> strings = new List<string>() { "jedan", "dva", "tri" };



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

        
            /* public List<Osoba> Get()
            {

            return popis;
            }

            public string Get(int id)
            {
                return "value";
            }*/

            [HttpPost]
            public IHttpActionResult Post([FromBody] Osoba person)
            {

            popis.Add(person);
            return Ok();
            }

            [HttpPost]
            public HttpResponseMessage Post([FromUri]string name,int age)
            {

            strings.Add(name);

            Osoba newPerson = new Osoba(name,age);
            popis.Add(new Osoba(name,age)); 

            return Request.CreateResponse(HttpStatusCode.OK);
            }

            [HttpPut]
            public IHttpActionResult Put(string name, string newName, int newAge)
            {
                foreach(var person in popis)
			    {
                if (person.Name == name) {
                    person.Name = newName;
                    person.Age = newAge;
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


