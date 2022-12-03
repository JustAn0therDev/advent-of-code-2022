public class DayTwo : IProblem
{
	public readonly string _input;

	public DayTwo()
	{
		_input = File.ReadAllText("PuzzleInputs/DayTwo.txt");
	}

	public void SolveAllAndPrint()
	{
		Console.WriteLine($"Part one: {SolvePartOne()}");
		// Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	private int CalculateMatch(string match)
	{
		// A, B, C -> Rock, Paper, Scissors
		// X, Y, Z -> Rock, Paper, Scissors
		int matchTotal = 0;

		string[] matchComponents = match.Replace("\n", "").Split(" ");

		if (matchComponents[1] == "X")
		{
			matchTotal += 1;
		}
		else if (matchComponents[1] == "Y")
		{
			matchTotal += 2;
		}
		else
		{
			matchTotal += 3;
		}

		if (
			(matchComponents[1] == "X" && matchComponents[0] == "A") ||
			(matchComponents[1] == "Y" && matchComponents[0] == "B") ||
			(matchComponents[1] == "Z" && matchComponents[0] == "C")
			)
		{
			matchTotal += 3;
		}
		else if (
			(matchComponents[1] == "X" && matchComponents[0] == "C") ||
			(matchComponents[1] == "Y" && matchComponents[0] == "A") ||
			(matchComponents[1] == "Z" && matchComponents[0] == "B")
			)
		{
			matchTotal += 6;
		}

		return matchTotal;
	}

	public int SolvePartOne()
	{
		// What would your total score be if everything goes exactly according to your strategy guide?
		int total = 0;

		string[] matches = _input.Split("\r");

		foreach (string match in matches)
		{
			total += CalculateMatch(match);
		}

		return total;
	}

	// public int SolvePartTwo() {

	// }
}