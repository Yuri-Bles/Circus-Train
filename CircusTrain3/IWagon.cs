using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain3
{
	public interface IWagon
	{
		public bool DoesItFit(Animal newAnimal);

		public bool WillItBeSafe(Animal newAnimal);

		public void AddAnimalToWagon(Animal animal);
	}
}
