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
		Console.WriteLine($"Part two: {SolvePartTwo()}");
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

	private int SolvePartTwo()
	{
		// In how many assignment pairs do the ranges overlap?

		string[] pairs = _input.Split("\r").Select(s => s.Replace("\n", "")).ToArray();

		int total = 0;

		foreach (string pair in pairs) {
			string firstPair, secondPair;
		
			(firstPair, secondPair) = (pair.Split(",")[0], pair.Split(",")[1]);

			(int fpFirstValue, int fpSecondValue) = (int.Parse(firstPair.Split("-")[0]), int.Parse(firstPair.Split("-")[1]));
			(int spFirstValue, int spSecondValue) = (int.Parse(secondPair.Split("-")[0]), int.Parse(secondPair.Split("-")[1]));

			IEnumerable<int> firstList = Enumerable.Range(fpFirstValue, (fpSecondValue - fpFirstValue) + 1);
			IEnumerable<int> secondList = Enumerable.Range(spFirstValue, (spSecondValue - spFirstValue) + 1);

			var joined = firstList.Join(secondList, a => a, b => b, (a, b) => b);

			if (joined.Count() > 0) {
				total++;
			}
		}

		return total;
	}
}