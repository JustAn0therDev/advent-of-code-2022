public class DaySeven : IProblem
{
    public readonly string _input;

    public DaySeven()
    {
        _input = File.ReadAllText("PuzzleInputs/DaySeven.txt");
    }

    public void SolveAllAndPrint()
    {
        Console.WriteLine($"Part one: {SolvePartOne()}");
        // Console.WriteLine($"Part two: {SolvePartTwo()}");
    }

    private double FindPartOne(TreeNode tree)
    {
        // if this directory is too large,
        // look for directories inside it

        double total = 0;
        double nodeSize = tree.GetTotalSize();

        if (nodeSize <= 100_000)
        {
            total += nodeSize;
        }

        foreach (var subDir in tree.SubDirectories)
        {
            total += FindPartOne(subDir);
        }

        return total;
    }

    public int SolvePartOne()
    {
        // Find all of the directories with a total size of at most 100000. 
        // What is the sum of the total sizes of those directories?

        // The first command is always to make the tree.
        // IReadOnlyList<string> lines = _input.Split("\r").Where(w => w != "$ cd /").Select(s => s.Replace("\n", "")).ToList();
        IReadOnlyList<string> lines = _input.Split("$").Where(w => w != " cd /\r\n").Select(s => s.Trim()).Where(w => w != string.Empty).ToList();

        // The root directory
        TreeNode tree = new("/", parentDirectory: null);

        double finalSum = 0;

        foreach (string line in lines)
        {
            string command = line.Split(" ")[0];

            switch (command)
            {
                case "cd":
                    // read the string after it
                    string directoryName = line.Split(" ")[1];

                    if (directoryName == "..")
                    {
                        tree = tree.ParentDirectory!;
                        continue;
                    }

                    if (tree.SubDirectories.Any(a => a.Name == directoryName))
                    {
                        tree = tree.SubDirectories.FirstOrDefault(f => f.Name == directoryName)!;
                        continue;
                    }
                    break;
                default:
                    foreach (var item in line.Split("\r\n"))
                    {
                        // TODO: Refactor
                        if (item == "ls")
                            continue;
                        // If the line is not a command, populate the current tree node
                        (string info, string itemName) = (item.Split(" ")[0], item.Split(" ")[1]);

                        if (double.TryParse(info, out double fileSize))
                        {
                            tree.Files.Add(new(itemName, fileSize));
                        }
                        else
                        {
                            tree.SubDirectories.Add(new(itemName, parentDirectory: tree));
                        }
                    }

                    break;
            }
            // Console.WriteLine(line);
        }

        // get to root directory
        while (tree.ParentDirectory != null)
        {
            tree = tree.ParentDirectory;
        }

        return (int)FindPartOne(tree);
    }

    // public int SolvePartTwo()
    // {

    // }

    public class TreeNode
    {
        public string? Name { get; set; }
        public List<TreeNode> SubDirectories { get; set; }
        public List<DaySevenFile> Files { get; set; }
        public TreeNode? ParentDirectory { get; set; }

        public TreeNode(string name, TreeNode? parentDirectory)
        {
            Name = name;
            SubDirectories = new();
            Files = new();
            ParentDirectory = parentDirectory;
        }

        public double GetTotalSize()
        {
            double diretorySizes = SubDirectories.Sum(s => s.GetTotalSize());
            double fileSizes = Files.Sum(s => s.Size);

            return diretorySizes + fileSizes;
        }
    }

    public class DaySevenFile
    {
        public string Name { get; set; }
        public double Size { get; set; }

        public DaySevenFile(string name, double size)
        {
            Name = name;
            Size = size;
        }
    }
}