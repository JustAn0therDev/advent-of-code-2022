
public class DayNine : IProblem
{
	public readonly string[] _input;

	public DayNine()
	{
		_input = File.ReadAllLines("PuzzleInputs/DayNine.txt");
	}

	public void SolveAllAndPrint()
	{
		Console.WriteLine($"Part one: {SolvePartOne()}");
		//Console.WriteLine($"Part two: {SolvePartTwo()}");
	}

	public bool IsNotAdjacent(Point head, Point tail) 
	{
		return Math.Abs(head.X - tail.X) > 1 || Math.Abs(head.Y - tail.Y) > 1;
	}

	public int SolvePartOne()
	{
		// The tail and head function like a snake game.
		// The tail must always be adjacent to the head.
		// If the head gets away from the tail (check if it's not adjacent anymore), get the past head's position and move it there.
		// This should be enough for part one.
		// Use coordinates to keep track of each position.

		List<(int x, int y)> visited = new();

		Point head = new();
		Point tail = new();

		visited.Add((tail.X, tail.Y));

		int headsLastPositionX = 0;
		int headsLastPositionY = 0;

		foreach (string line in _input)
		{
			string[] lineSplit = line.Split(" ");

			(string orientation, int amount) = (lineSplit[0], int.Parse(lineSplit[1]));

			for (int i = 0; i < amount; i++)
			{
				(headsLastPositionX, headsLastPositionY) = (head.X, head.Y);
				head.Move(orientation);

				if (IsNotAdjacent(head, tail))
				{
					if (!visited.Contains((headsLastPositionX, headsLastPositionY))) {
						visited.Add((headsLastPositionX, headsLastPositionY));
					}

					tail.Move(headsLastPositionX, headsLastPositionY);
					// Console.WriteLine($"They are now in {head.X}, {head.Y} and {tail.X}, {tail.Y}.");
				} else {
					// Console.WriteLine($"Adjacent. In {head.X}, {head.Y} and {tail.X}, {tail.Y}.");
				}
			}
		}

		return visited.Count;
	}

	/*
		public int SolvePartTwo()
		{
		}
	*/

	public struct Point
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point()
		{
			X = default;
			Y = default;
		}

		public void Move(string orientation)
		{
			switch (orientation)
			{
				case "R":
					X += 1;
					break;
				case "L":
					X -= 1;
					break;
				case "U":
					Y -= 1;
					break;
				case "D":
					Y += 1;
					break;
			}
		}

		public void Move(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}