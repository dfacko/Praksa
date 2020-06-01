using System;
using System.Collections.Generic;
using System.Text;

namespace Praksa_oop
{
	public abstract class Vehicle
	{
		protected double Speed { get; set; }
		protected double Weight { get; set; }
		protected int Wheels { get; set; }


		public virtual void Identify()
		{
			Console.WriteLine($"This vehicle has {Wheels} wheels, weighs {Weight} and goes {Speed}"); 
		}
	}

	public class Car : Vehicle
	{
		public string Brand { get; set; } 
		/*public string MyBrand
		{
			get
			{
				return Brand;
			}
			set
			{
				if (value.Length > 15) { Console.WriteLine("ne moze"); return; }
				this.Brand = value;
			}
		} 
		public void setBrand(string brand)
		{
			this.Brand = brand;

		}*/
		public Car(float speed, float weight, int wheels)
		{
			this.Speed = speed;
			this.Weight = weight;
			this.Wheels = wheels;

		}

		public override void Identify()
		{
			base.Identify();
			Console.WriteLine($"And is of the {Brand} brand");
		}
	}
}
