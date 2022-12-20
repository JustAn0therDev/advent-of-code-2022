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
        //Console.WriteLine($"Part two: {GetUniqueTailPositions(2, 10)}");
        Console.WriteLine($"Part two: {SolvePartTwo()}");
    }

    private static bool IsNotAdjacent(Point head, Point tail)
    {
        return Math.Abs(head.X - tail.X) > 1 || Math.Abs(head.Y - tail.Y) > 1;
    }

    private static bool IsNotAdjacentPartTwo(Point head, Point part)
    {
        return Math.Abs(head.X - part.X) == 2 || Math.Abs(head.Y - part.Y) == 2;
    }

    public int SolvePartOne()
    {
        List<(int x, int y)> visited = new();

        Point head = new();
        Point tail = new();

        int headsLastPositionX;
        int headsLastPositionY;

        visited.Add((tail.X, tail.Y));
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
                    if (!visited.Contains((headsLastPositionX, headsLastPositionY)))
                    {
                        visited.Add((headsLastPositionX, headsLastPositionY));
                    }

                    tail.Place(headsLastPositionX, headsLastPositionY);
                }
            }
        }

        return visited.Count;
    }

    public int SolvePartTwo()
    {
        HashSet<(int x, int y)> visited = new();

        (int x, int y)[] rope = new(int x, int y)[10];

        visited.Add((0, 0));

        foreach (string line in _input)
        {
            string[] lineSplit = line.Trim().Split(" ");

            (string orientation, int amount) = (lineSplit[0], int.Parse(lineSplit[1]));

            for (int i = 0; i < amount; i++)
            {
                switch (orientation)
                {
                    case "R":
                        rope[0].x += 1;
                        break;
                    case "L":
                        rope[0].x -= 1;
                        break;
                    case "U":
                        rope[0].y -= 1;
                        break;
                    case "D":
                        rope[0].y += 1;
                        break;
                    default:
                        throw new Exception();
                }

                for (int j = 1; j < rope.Length; j++)
                {
                    int dx = rope[j - 1].x - rope[j].x;
                    int dy = rope[j - 1].y - rope[j].y;

                    if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
                    {
                        rope[j].x += Math.Sign(dx);
                        rope[j].y += Math.Sign(dy);
                    }
                }

                visited.Add((rope[^1].x, rope[^1].y));
            }
        }

        // The result should be less than 2538...

        return visited.Count;
    }

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

        public void Place(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        public (int x, int y) GetNextMove(Point objective)
        {
            int dx = Math.Abs(objective.X - X);
            int dy = Math.Abs(objective.Y - Y);
            return (Math.Sign(dx), Math.Sign(dy));
        }
    }
}