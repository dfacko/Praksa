using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp {

    public  class Reader {
        public  List<Osoba> popis=new List<Osoba>();
        public  List<Osoba> HasRows(SqlConnection connection) {
            string name = "",surname=""; 
            int age=-1;
            Osoba person;
            
            
            using (connection) {
                SqlCommand command = new SqlCommand(
                  "SELECT PersonName,Surname,Age FROM Osoba;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {

                        name = reader.GetString(0);
                        surname=reader.GetString(1);
                        age = reader.GetInt32(2);
                        person = new Osoba(name, surname, age);
                        popis.Add(person);
                        
                    }
                } else {
                    
                }
                reader.Close();
                connection.Close();
            }
            
   
            return popis;
        }
    }
}