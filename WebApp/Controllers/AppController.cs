using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.DynamicData.ModelProviders;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;

namespace WebApp.Controllers
{
    public class AppController : ApiController
    {

              List<Osoba> popis = new List<Osoba>() { };
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PraksaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
 

        // GET: api/App
            [HttpGet]
            public IHttpActionResult Get()
            {
            Reader reader = new Reader();

                popis=reader.HasRows(connection);
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
            DataInsert.AddToDb(connection, person);
                   
            return Ok();
            }




            [HttpPut]
            public IHttpActionResult Put(int id,string newName="",string newSurname="",int newAge=-1)
            {


            int status=DataEdit.Edit(connection,id, newName, newSurname, newAge);

            if (status == 0) { 
                return NotFound(); 
                }
			
                return Ok();
			


            }
            
            [HttpDelete]
            public IHttpActionResult Delete([FromBody]int id)
            {

            DataDelete.Delete(connection, id);
            return Ok();
                
            }
        
    }
}


