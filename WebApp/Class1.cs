using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
	public class Osoba 
	{ 
		public string Name { get; set; }
		public int Age { get; set; }
		//public string prezime { get; set; }


		public  Osoba(string name,int age)
		{
			this.Name = name;
			this.Age = age;
		}

	}

}
