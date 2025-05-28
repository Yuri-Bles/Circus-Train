using CircusTrain3;

Circus circus = new Circus();
string trainString = "";
bool done = false;

while (!done)
{
	Console.WriteLine("Do you want to add an animal? Y/N");
	char addAnimalAnswer = 'E';

	string? line = Console.ReadLine();
	if (line!.Length > 0)
	{
		addAnimalAnswer = line[0];
	}
	
	if (addAnimalAnswer == 'Y' || addAnimalAnswer == 'y')
	{
		int size = 0;
		bool foundSize = false;
		while (!foundSize)
		{
			Console.WriteLine("What is the size of the animal? Any integer");
			if (int.TryParse(Console.ReadLine(), out int result))
			{
				size = result;
				foundSize = true;
			}
			else
			{
				Console.WriteLine("The value provided is not an integer");
			}
		}

		bool isCarnivore = false;
		bool foundEaterType = false;
		while (!foundEaterType)
		{
			Console.WriteLine("Is the animal a carnivore? Y/N");
			char isCarnivoreAnswer = 'E';

			string? line2 = Console.ReadLine();
			if (line2!.Length > 0)
			{
				isCarnivoreAnswer = line2[0];
			}

			if (isCarnivoreAnswer == 'Y' || isCarnivoreAnswer == 'y')
			{
				isCarnivore = true;
				foundEaterType = true;
			}
			else if (isCarnivoreAnswer == 'N' || isCarnivoreAnswer == 'n')
			{
				isCarnivore = false;
				foundEaterType = true;
			}
			else
			{
				Console.WriteLine("That is not a valid value, use Y (for yes) or N (for no)");
			}
		}

		int amount = 0;
		bool amountIsFound = false;
		while (!amountIsFound)
		{
			Console.WriteLine("How many of this animal do you want to add?");

			if (int.TryParse(Console.ReadLine(), out int result))
			{
				amount = result;
				amountIsFound = true;
			}
			else
			{
				Console.WriteLine("The value provided is not an integer");
			}
		}

		for (int i = 0; i < amount; i++)
		{
			circus.CreateAnimal(size, isCarnivore);
		}
		Console.WriteLine("");
	}
	else if (addAnimalAnswer == 'N' || addAnimalAnswer == 'n')
	{
		done = true;
	}
	else
	{
		Console.WriteLine("That is not a valid value, use Y (for yes) or N (for no)");
	}
}

circus.PutAllAnimalsInTrain();

trainString = circus.GetTrainString();

Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Amount of wagons: {circus.GetAmountOfWagonsInTrain()}");
Console.WriteLine(trainString);