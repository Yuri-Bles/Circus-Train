using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrain3
{
	public class Train
	{
		int amountOfExperimentalWagons = 4;

		List<Wagon> allNormalWagons = new List<Wagon>();
		List<ExperimentalWagon> allExperimentalWagons = new List<ExperimentalWagon>();

		public void PutAnimalInWagon(Animal newAnimal)
		{
			bool foundASpot = false;
			foreach (var wagon in this.allNormalWagons)
			{
				if (wagon.DoesItFit(newAnimal) && wagon.WillItBeSafe(newAnimal))
				{
					wagon.AddAnimalToWagon(newAnimal);
					foundASpot = true;
					break;
				}
			}

			if (!foundASpot)
			{
				Wagon newWagon = new Wagon();
				allNormalWagons.Add(newWagon);
				newWagon.AddAnimalToWagon(newAnimal);
			}
		}

		public void AddExperimentalWagons()
		{
			List<Animal> animalsForExperimentalWagons = new List<Animal>();

			foreach (var wagon in allNormalWagons)
			{
				if (wagon.animalsInWagon.Count == 1 && wagon.animalsInWagon[0].size < 4)
				{
					animalsForExperimentalWagons.Add(wagon.animalsInWagon[0]);
					wagon.animalsInWagon.Clear();
					allNormalWagons.Remove(wagon);
				}
			}
			//Only one herbivore can be in the animalsForExperimentalWagons list.
			if (animalsForExperimentalWagons.Count > 2 * amountOfExperimentalWagons)
			{
				foreach (var animal in animalsForExperimentalWagons)
				{
					if (!animal.isCarnivore)
					{
						animalsForExperimentalWagons.Remove(animal);
						AddNormalWagonBecauseOfTooManyExperimentalWagons(animal);
					}
				}
			}

			int maxAnimalCount = 2 * amountOfExperimentalWagons;
			for (int i = animalsForExperimentalWagons.Count; maxAnimalCount < animalsForExperimentalWagons.Count; i--)
			{
				Animal animal = animalsForExperimentalWagons[i];
				animalsForExperimentalWagons.Remove(animal);
				AddNormalWagonBecauseOfTooManyExperimentalWagons(animal);
			}
		}

		public void AddNormalWagonBecauseOfTooManyExperimentalWagons(Animal newAnimal)
		{
			//This will only be called upon for animals that were alone anyways, so we don't have to check the other wagons.
			Wagon newWagon = new Wagon();
			allNormalWagons.Add(newWagon);
			newWagon.AddAnimalToWagon(newAnimal);
		}

		public int GetAmountOfWagons()
		{
			return allNormalWagons.Count;
		}

		public override string ToString()
		{
			List<string> wagonStrings = new List<string>();

			foreach (var wagon in this.allNormalWagons)
			{
				wagonStrings.Add(wagon.ToString());
			}

			return $"{string.Join("-", wagonStrings)}";
		}
	}
}
