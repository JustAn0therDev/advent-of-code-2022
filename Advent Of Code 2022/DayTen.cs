
public class DayTen : IProblem
{
	public readonly string[] _input;

	public DayTen()
	{
		_input = File.ReadAllLines("PuzzleInputs/DayTen.txt");
	}

	public void SolveAllAndPrint()
	{
		Console.WriteLine($"Part one: {SolvePartOne()}");
		// Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	public int SolvePartOne()
	{
		// addx instructions take two cycles to complete.
		// there is only one instruction per "cycle"

		int result = 0;
		int cycle = 0;
		int lastCycle = 0;
		bool hasInstructionPending = false;
		int vRegister = 1;
		int index = 0;

		while (index < _input.Length - 1)
		{
			cycle++;
			if (cycle == 20 || cycle - lastCycle == 40)
			{
				lastCycle = cycle;
				result += vRegister * cycle;
			}

			string instruction = _input[index];

			if (instruction.StartsWith("addx") && !hasInstructionPending)
			{
				hasInstructionPending = true;
			}
			else if (instruction.StartsWith("addx") && hasInstructionPending)
			{
				hasInstructionPending = false;
				vRegister += int.Parse(instruction.Split(" ")[1]);
				index++;
			}
			else
			{
				// noop
				index++;
			}
		}

		return result;
	}

	/*
	   public int SolvePartTwo()
	   {
	   }
	*/
}