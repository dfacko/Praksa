using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Praksa_oop
{
		
		public class GenericList<T>
		{
			public void Add(T input) { }
		}
	
		public class Owner
		{
			//public string Cars;
			public Owner()
			{
				Name = "";
				Cars= "asdasd,asdasd,asdegaweg,wefawetf";
			}
			public string Name { get; set; }
			public string Cars { get; set; }


			
			


		}
	



	public interface ISpecificModel
	{
		 void UpdateOwner(Owner owner,string brand);


	}

	public class SpecificCar : Vehicle ,ISpecificModel
	{
		private Owner CurrentOwner;
		private string Brand;
		public  SpecificCar(Owner owner,string brand,double speed,double weight,int wheels)
		{
			this.CurrentOwner = owner;
			Speed = speed;
			Weight = weight;
			Wheels = wheels;
			Brand = brand;
		}

		 public void UpdateOwner(Owner owner,string brand)
		{

			owner.Cars = owner.Cars + "," + brand;

		}

		public override void Identify()
		{
			base.Identify();
			Console.WriteLine($"And is of the {Brand} brand,The owner is {CurrentOwner.Name},all his cars are {CurrentOwner.Cars}");

		}


	}





	class Program
	{
		static void Main(string[] args)
		{
			Owner owner = new Owner();
			string brand;

			GenericList<string> popis = new GenericList<string>();

			Car lada = new Car(10, 524,4); 
			lada.Brand = "Yugo"; 
			lada.Identify();


			Console.WriteLine("Enter your name");
			owner.Name = Console.ReadLine();
			Console.WriteLine("Enter your car brand");
			brand = Console.ReadLine();
			SpecificCar YourCar = new SpecificCar(owner,brand,100,255,4);
			YourCar.UpdateOwner(owner, brand);
			YourCar.Identify();


			/*  samo sam dodao u listu jer ne znam sta vise izmislit
			string car = "";
			for (int i = 0; i < owner.Cars.Length; i++)
			{
				car = car + owner.Cars[i];
				if(owner.Cars[i] == ',')
				{
					popis.Add(car);
					car = "";
				}

			}
			*/
			







		}
	}
}
