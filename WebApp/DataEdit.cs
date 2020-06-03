using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp {
	public class DataEdit {
		public static int Edit(SqlConnection connection,int Id,string newName,string newSurname,int newAge) {

            int flag = 0;
            string queryString;



            using (connection) {
                
                //treba provjerit jel taj id uopce postoji u bazi

                if (newName != "") {
                    queryString = $"Update Osoba set PersonName='{newName}' where Id={Id};";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                    DataSet Person = new DataSet();  
                    adapter.Fill(Person, "Osoba");
                    flag = 1;
                }

                if (newSurname != "") {
                    queryString = $"Update Osoba set Surname='{newSurname}'" +
                        $"where Id={Id};";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                    DataSet Person = new DataSet();  
                    adapter.Fill(Person, "Osoba");
                    flag = 1;
                }

                if (newAge != -1) {
                    queryString = $"Update Osoba set Age={newAge}" +
                        $"where Id={Id};";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                    DataSet Person = new DataSet();  
                    adapter.Fill(Person, "Osoba");
                    flag = 1;
                }
         
            }
            connection.Close();

            if (flag == 0) {
                return flag;
			}
            return flag;

        }
	}
}