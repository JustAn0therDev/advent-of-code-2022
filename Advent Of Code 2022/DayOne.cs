public class DayOne : IProblem {
	public readonly string _input;

	public DayOne() {
		_input = File.ReadAllText("PuzzleInputs/DayOne.txt");
	}

	public void SolveAllAndPrint()
	{
		Console.WriteLine($"Part one: {SolvePartOne()}");
		Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	public int SolvePartOne() {
		// Which elf has the most calories on them?

		List<int> elfCalorieCount = new() { 0 };

		string[] listOfCalories = _input.Split("\r");

		foreach (string calorieAmount in listOfCalories) {
			if (calorieAmount == "\n") {
				elfCalorieCount.Add(0);
				continue;
			}

			elfCalorieCount[^1] += Convert.ToInt32(calorieAmount);
		}

		return elfCalorieCount.Max();
	}

	public int SolvePartTwo() {
		// How many calories are the top three elves with the most
		// calories carrying?

		List<int> elfCalorieCount = new() { 0 };

		string[] listOfCalories = _input.Split("\r");

		foreach (string calorieAmount in listOfCalories) {
			if (calorieAmount == "\n") {
				elfCalorieCount.Add(0);
				continue;
			}

			elfCalorieCount[^1] += Convert.ToInt32(calorieAmount);
		}

		return elfCalorieCount.OrderByDescending(od => od).Take(3).Sum();
	}
}