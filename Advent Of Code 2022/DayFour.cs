public class DayFour : IProblem
{
	public readonly string _input;

	public DayFour()
	{
		_input = File.ReadAllText("PuzzleInputs/DayFour.txt");
	}

	public void SolveAllAndPrint()
	{
		Console.WriteLine($"Part one: {SolvePartOne()}");
		// Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	private int SolvePartOne()
	{
		// In how many assignment pairs does one range fully contain the other?

		string[] pairs = _input.Split("\r").Select(s => s.Replace("\n", "")).ToArray();

		int total = 0;

		foreach (string pair in pairs) {
			string firstPair, secondPair;
		
			(firstPair, secondPair) = (pair.Split(",")[0], pair.Split(",")[1]);

			(int fpFirstValue, int fpSecondValue) = (int.Parse(firstPair.Split("-")[0]), int.Parse(firstPair.Split("-")[1]));
			(int spFirstValue, int spSecondValue) = (int.Parse(secondPair.Split("-")[0]), int.Parse(secondPair.Split("-")[1]));

			if ((fpFirstValue >= spFirstValue && fpSecondValue <= spSecondValue) || 
				(spFirstValue >= fpFirstValue && spSecondValue <= fpSecondValue)) {
					total++;
			}
		}

		return total;
	}

	// private int SolvePartTwo()
	// {
	// 	// How many calories are the top three elves with the most
	// 	// calories carrying?

	// 	List<int> elfCalorieCount = new() { 0 };

	// 	string[] listOfCalories = _input.Split("\r");

	// 	foreach (string calorieAmount in listOfCalories)
	// 	{
	// 		if (calorieAmount == "\n")
	// 		{
	// 			elfCalorieCount.Add(0);
	// 			continue;
	// 		}

	// 		elfCalorieCount[^1] += Convert.ToInt32(calorieAmount);
	// 	}

	// 	return elfCalorieCount.OrderByDescending(od => od).Take(3).Sum();
	// }
}