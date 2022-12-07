using System.Text;

public class DayFive : IProblem
{
	public readonly string _input;

	public DayFive()
	{
		_input = File.ReadAllText("PuzzleInputs/DayFive.txt");
	}

	public void SolveAllAndPrint()
	{
		Console.WriteLine($"Part one: {SolvePartOne()}");
		Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	private int GetListSize(string part)
	{
		int index = 0;
		int spaceCounter = 0;
		int listIndex = 0;

		while (index < part.Length)
		{

			if (part[index] == ' ')
			{
				spaceCounter++;
			}

			if (spaceCounter == 4)
			{
				listIndex++;
				spaceCounter = 0;
			}
			else if (part[index] == '[')
			{
				listIndex++;
				index += 3;
				spaceCounter = 0;
				continue;
			}

			index++;
		}

		return listIndex;
	}

	private void MakeList(string part, List<List<string>> listOfLists)
	{
		int index = 0;
		int spaceCounter = 0;
		int listIndex = 0;

		while (index < part.Length)
		{
			if (part[index] == ' ')
			{
				spaceCounter++;
			}

			if (spaceCounter == 4)
			{
				listIndex++;
				spaceCounter = 0;
			}
			else if (part[index] == '[')
			{
				listOfLists[listIndex] = listOfLists[listIndex].Prepend($"{part[index + 1]}").ToList();
				// listOfLists[listIndex].Add($"{part[index + 1]}");

				listIndex++;
				index += 3;
				spaceCounter = 0;

				continue;
			}

			index++;
		}
	}

	// The only difference between parts one and two is that the moved items maintain the 
	// "stack behavior" in the first part but loses it in the second part (the part moved now maintains its order)
	private void MoveItemBetweenListsPartOne(List<List<string>> listOfLists, int numOfItems, int fromListIndex, int toListIndex)
	{
		List<string> from = listOfLists[fromListIndex];
		List<string> to = listOfLists[toListIndex];

		while (numOfItems > 0)
		{
			numOfItems--;
			to.Add(from.Last());
			from.RemoveAt(from.Count - 1);
		}
	}

	private void MoveItemBetweenListsPartTwo(List<List<string>> listOfLists, int numOfItems, int fromListIndex, int toListIndex)
	{
		List<string> from = listOfLists[fromListIndex];
		List<string> to = listOfLists[toListIndex];

		List<string> itemsToMove = ((IEnumerable<string>)from).Reverse().Take(numOfItems).Reverse().ToList();

		to.AddRange(itemsToMove);
		int index = from.Count - 1;
		int itemsToRemove = numOfItems;

		while (itemsToRemove > 0) {
			from.RemoveAt(index);
			index--;
			itemsToRemove--;
		}
	}


	public string SolvePartOne()
	{
		List<List<string>> listOfLists = new();

		List<string> splitInput = _input.Split("\r").Select(s => s.Replace("\n", "")).ToList();

		// The first line will always have the biggest list in it,
		// so we'll always get the amount of lists from it
		int listSize = GetListSize(splitInput[0]);

		for (int i = 0; i < listSize; i++)
		{
			listOfLists.Add(new List<string>());
		}

		for (int i = 0; i < splitInput.Count; i++)
		{
			if (!splitInput[i].Contains("move"))
			{
				MakeList(splitInput[i], listOfLists);
			}
			else
			{
				// this whole thing using lots of LINQ should be refactored later
				Console.WriteLine(splitInput[i]);
				string[] parsedInput = splitInput[i]
				.Replace("move", "")
				.Replace("from", "")
				.Replace("to", "")
				.Split(" ")
				.Where(w => w != "").ToArray();

				int numOfItems = int.Parse(parsedInput[0].Trim());
				int fromListIndex = int.Parse(parsedInput[1].Trim()) - 1;
				int toListIndex = int.Parse(parsedInput[2].Trim()) - 1;

				MoveItemBetweenListsPartOne(listOfLists, numOfItems, fromListIndex, toListIndex);
			}
		}

		StringBuilder result = new();

		foreach (var list in listOfLists)
		{
			result.Append(list.Last());
		}

		return result.ToString();
	}

	

	public string SolvePartTwo()
	{
		List<List<string>> listOfLists = new();

		List<string> splitInput = _input.Split("\r").Select(s => s.Replace("\n", "")).ToList();

		// The first line will always have the biggest list in it,
		// so we'll always get the amount of lists from it
		int listSize = GetListSize(splitInput[0]);

		for (int i = 0; i < listSize; i++)
		{
			listOfLists.Add(new List<string>());
		}

		for (int i = 0; i < splitInput.Count; i++)
		{
			if (!splitInput[i].Contains("move"))
			{
				MakeList(splitInput[i], listOfLists);
			}
			else
			{
				// this whole thing using lots of LINQ should be refactored later
				Console.WriteLine(splitInput[i]);
				string[] parsedInput = splitInput[i]
				.Replace("move", "")
				.Replace("from", "")
				.Replace("to", "")
				.Split(" ")
				.Where(w => w != "").ToArray();

				int numOfItems = int.Parse(parsedInput[0].Trim());
				int fromListIndex = int.Parse(parsedInput[1].Trim()) - 1;
				int toListIndex = int.Parse(parsedInput[2].Trim()) - 1;

				MoveItemBetweenListsPartTwo(listOfLists, numOfItems, fromListIndex, toListIndex);
			}
		}

		StringBuilder result = new();

		foreach (var list in listOfLists)
		{
			result.Append(list.Last());
		}

		return result.ToString();		
	}
}