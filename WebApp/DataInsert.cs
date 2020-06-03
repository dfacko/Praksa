using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp {
    public class DataInsert {

        public static void AddToDb(SqlConnection connection, Osoba person) {

            string name = person.Name;
            string surname = person.Surname;
            int age = person.Age;
            int Id=0;

            using (connection) {
                SqlCommand command = new SqlCommand(
                  "SELECT Id FROM Osoba;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {                    //ovaj cijeli if je samo da dobijem zadnji id pa da za sljedeci unos automatski poveca id za 1, ovo se moglo lijepse napravit 
                    while (reader.Read()) {              // da se selektira najveci id bez da se prolazi kroz cijelu tablicu tj pretrazuju svi objekti

                        Id = reader.GetInt32(0);
                        
                    }
                }
                Id = Id + 1;
                reader.Close();

                string queryString =
                $"Insert into Osoba values ({Id},1,'{name}','{surname}',{age});";  
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet newPerson = new DataSet();  
                adapter.Fill(newPerson, "Osoba");
            }

            
            

            
            connection.Close();
            return;

        }
    }
}