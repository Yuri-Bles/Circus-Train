using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain3
{
	public class Wagon : IWagon
	{
		public List<Animal> animalsInWagon = new List<Animal>();
		private int wagonsize = 10;

		public bool DoesItFit(Animal newAnimal)
		{
			int occupiedSpace = 0;
			foreach (var animal in this.animalsInWagon)
			{
				occupiedSpace += animal.size;
			}

			if (occupiedSpace + newAnimal.size <= this.wagonsize)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool WillItBeSafe(Animal newAnimal)
		{
			//Check if the other animals will be safe
			if (newAnimal.isCarnivore)
			{
				foreach (var animal in this.animalsInWagon)
				{
					if (newAnimal.size >= animal.size)
					{
						return false;
					}
				}
			}

			//Check if the new animal will be safe
			foreach (var animal in this.animalsInWagon)
			{
				if (animal.isCarnivore && animal.size >= newAnimal.size)
				{
					return false;
				}
			}

			return true;
		}

		public void AddAnimalToWagon(Animal animal)
		{
			this.animalsInWagon.Add(animal);
		}

		public override string ToString()
		{
			List<string> animalStrings = new List<string>();

			foreach (var animal in this.animalsInWagon)
			{
				animalStrings.Add(animal.ToString());
			}

			return $"[{string.Join("", animalStrings)}]";
		}
	}
}
