public class DayThree : IProblem
{
	public readonly string _input;

	public DayThree()
	{
		_input = File.ReadAllText("PuzzleInputs/DayThree.txt");
	}

	public void SolveAllAndPrint()
	{
		Console.WriteLine($"Part one: {SolvePartOne()}");
		Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	public int SolvePartOne()
	{
		// What is the sum of the priorities of those item types?
		// Find the common character that exists in both compartments of the rucksack.
		// Each character has a predefined priority
		// Lowercase item types a through z have priorities 1 through 26.
		// Uppercase item types A through Z have priorities 27 through 52.

		int total = 0;

		IEnumerable<string> rucksacks = _input.Split("\r").Select(s => s.Replace("\n", ""));

		foreach (string rucksack in rucksacks)
		{
			string firstHalf = string.Join("", rucksack.Take(0..(rucksack.Length / 2)));
			string secondHalf = string.Join("", rucksack.Take(((rucksack.Length / 2))..rucksack.Length));

			char charInCommon = firstHalf.Join(secondHalf, a => a, b => b, (a, b) => a).FirstOrDefault();

			if (char.IsLower(charInCommon))
			{
				total += (int)charInCommon - 96;
			}
			else
			{
				total += (int)charInCommon - 38;
			}
		}

		return total;
	}

	public int SolvePartTwo()
	{
		// Find the item type that corresponds to the badges of each three-Elf group. 
		// What is the sum of the priorities of those item types?
		int total = 0;

		string[] rucksacks = _input.Split("\r").Select(s => s.Replace("\n", "")).ToArray();

		for (int i = 0; i < rucksacks.Length; i += 3)
		{
			string firstRuckSack = rucksacks[i];
			string secondRuckSack = rucksacks[i + 1];
			string thirdRuckSack = rucksacks[i + 2];

			char charInCommon = char.MinValue;

			foreach (char ch in firstRuckSack) {
				if (secondRuckSack.Contains(ch) && thirdRuckSack.Contains(ch)) {
					charInCommon = ch;
					break;
				}
			}

			if (char.IsLower(charInCommon))
			{
				total += (int)charInCommon - 96;
			}
			else
			{
				total += (int)charInCommon - 38;
			}
		}

		return total;
	}
}