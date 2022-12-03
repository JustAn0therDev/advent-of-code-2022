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
		Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	private int CalculateMatchPartOne(string match)
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

	private int CalculateMatchPartTwo(string match)
	{
		// A, B, C -> Rock, Paper, Scissors
		// X, Y, Z -> Lose, Draw, Win
		int matchTotal = 0;

		string[] matchComponents = match.Replace("\n", "").Split(" ");

		if (matchComponents[1] == "Z")
		{
			matchTotal += 6;

			switch (matchComponents[0])
			{
				case "A":
					matchTotal += 2;
					break;
				case "B":
					matchTotal += 3;
					break;
				case "C":
					matchTotal += 1;
					break;
			}
		}
		else if (matchComponents[1] == "Y")
		{
			matchTotal += 3;

			switch (matchComponents[0])
			{
				case "A":
					matchTotal += 1;
					break;
				case "B":
					matchTotal += 2;
					break;
				case "C":
					matchTotal += 3;
					break;
			}
		}
		else {
			switch (matchComponents[0])
			{
				case "A":
					matchTotal += 3;
					break;
				case "B":
					matchTotal += 1;
					break;
				case "C":
					matchTotal += 2;
					break;
			}
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
			total += CalculateMatchPartOne(match);
		}

		return total;
	}

	public int SolvePartTwo()
	{
		/*
			The second column says how the round needs to end: 
			X means you need to lose, 
			Y means you need to end the round in a draw, 
			and Z means you need to win.
		*/
		int total = 0;

		string[] matches = _input.Split("\r");

		foreach (string match in matches)
		{
			total += CalculateMatchPartTwo(match);
		}

		return total;
	}
}