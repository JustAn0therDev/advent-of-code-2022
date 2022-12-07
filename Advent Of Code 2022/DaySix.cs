using System.Text;

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
		Console.WriteLine($"Part two: {SolvePartTwo()}");
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

	public int SolvePartTwo()
	{
		const int messageSize = 14;

		for (int i = 14; i < _input.Length; i++) {
			StringBuilder chars = new();

			int messageBufferSize = 0;
			int messageBufferIndex = i;

			while (messageBufferSize != messageSize) {
				chars.Append(_input[messageBufferIndex]);
				messageBufferIndex--;
				messageBufferSize++;
			}

			if (chars.ToString().Distinct().Count() == chars.Length) {
				return i + 1;
			}
		}

		return 0;
	}
}