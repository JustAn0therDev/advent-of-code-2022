public class DaySix : IProblem
{
	public readonly string _input;

	public DaySix()
	{
		_input = File.ReadAllText("PuzzleInputs/DaySix.txt");
	}

	public void SolveAllAndPrint()
	{
		Console.WriteLine($"Part one: {SolvePartOne()}");
		//Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	public int SolvePartOne()
	{
		for (int i = 3; i < _input.Length; i++) {
			List<char> chars = $"{_input[i - 3]}{_input[i - 2]}{_input[i - 1]}{_input[i]}".ToList();

			if (chars.Distinct().Count() == chars.Count) {
				return i + 1;
			}
		}

		return 0;
	}

/*
	public int SolvePartTwo()
	{
	}
*/
}