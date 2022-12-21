using System.Text;

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
		Console.WriteLine($"Part two: \n{SolvePartTwo()}");
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

	public string SolvePartTwo()
	{
		// the X register keeps the position of a sprite in it.
		// a sprite is the sum of three pixels and the middle of a sprite
		// is the position (so a ...###... sprite is in position 4 in a 0-based index.)
		// the CRT will only draw a pixel if the register has a sprite in it
		// so if the register has "1" in it, it means that the pixel "###......." is there.
		// if it changes value after that, two cycles have passed, so it becomes: "##......"

		StringBuilder crtScreen = new();
		StringBuilder section = new();
		int cycle = 0;
		int lastCycle = 0;
		bool hasInstructionPending = false;
		int vRegister = 1;
		int index = 0;
		int sectionIndex = 0;

		while (index < _input.Length - 1)
		{
			if (vRegister == sectionIndex - 1 || vRegister == sectionIndex || vRegister == sectionIndex + 1)
			{
				section.Append('#');
			}
			else
			{
				section.Append('.');
			}

			cycle++;
			sectionIndex++;

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
				// noop instruction
				index++;
			}

			// I cannot waste cycles.
			if (cycle - lastCycle == 40)
			{
				lastCycle = cycle;

				crtScreen.Append(section);
				crtScreen.AppendLine();
				sectionIndex = 0;
				section.Clear();
			}
		}

        crtScreen.Append(section);
        crtScreen.AppendLine();

		return crtScreen.ToString();
	}
}