using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain3
{
	public class ExperimentalWagon : IWagon
	{
		private Animal? leftAnimal = null;
		private Animal? rightAnimal = null;

		public bool DoesItFit(Animal newAnimal)
		{
			return (leftAnimal == null || rightAnimal == null) && newAnimal.size < 4;
		}

		public bool WillItBeSafe(Animal newAnimal)
		{
			//In experimental wagons an animal will always be alone, so it will always be safe.S
			return true;
		}

		public void AddAnimalToWagon(Animal animal)
		{
			if (leftAnimal == null)
			{
				leftAnimal = animal;
			}
			else
			{
				rightAnimal = animal;
			}
		}

		public override string ToString()
		{
			return $"[{leftAnimal}|{rightAnimal}]";
		}
	}
}
