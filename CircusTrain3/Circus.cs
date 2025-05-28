using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain3
{
	public class Circus
	{
		private Train train = new Train();
		private List<Animal> unsortedAnimals = new List<Animal>();
		private List<Animal> sortedAnimals = new List<Animal>();

		public Circus()
		{

		}

		public void CreateAnimal(int size, bool isCarnivore)
		{
			Animal newAnimal = new Animal(size, isCarnivore);
			this.unsortedAnimals.Add(newAnimal);
		}

		private void SortAnimals()
		{
			sortedAnimals = unsortedAnimals
				.OrderByDescending(a => a.isCarnivore)
				.ThenByDescending(a => a.size)
				.ToList();
		}

		public void PutAllAnimalsInTrain()
		{
			SortAnimals();
			foreach (var animal in this.sortedAnimals)
			{
				train.PutAnimalInWagon(animal);
			}
		}

		public int GetAmountOfWagonsInTrain()
		{
			return train.GetAmountOfWagons();
		}

		public string GetTrainString()
		{
			return train.ToString();
		}
	}
}
