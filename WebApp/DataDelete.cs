using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApp {
	public class DataDelete {

		public static void Delete(SqlConnection connection,[FromBody]int id) {



            //isto provjerja postoji li u bazi

            using (connection) {     

                string queryString =
                $"Delete from Osoba where id={id}";  
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet newPerson = new DataSet();  
                adapter.Fill(newPerson, "Osoba");
            }

            
           
            
            connection.Close();
            return;

        }
	}
}