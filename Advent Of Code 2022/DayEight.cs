public class DayEight : IProblem
{
    public readonly string[] _input;

    public DayEight()
    {
        _input = File.ReadAllLines("PuzzleInputs/DayEight.txt");
    }

    public void SolveAllAndPrint()
    {
        Console.WriteLine($"Part one: {SolvePartOne()}");
        // Console.WriteLine($"Part two: {SolvePartTwo()}");
    }

    private bool VisibleLeft(int lineIndex, int index, int leftTo) {
        int thisTree = (int)char.GetNumericValue(_input[lineIndex][index]);

        if (index - leftTo < 0) {
            return true;
        }

        int leftsideTree = (int)char.GetNumericValue(_input[lineIndex][index - leftTo]);

        if (thisTree > leftsideTree) {
            return VisibleLeft(lineIndex, index, leftTo + 1);
        } 

        return false;
    }

    private bool VisibleRight(int lineIndex, int index, int rightTo) {
        int thisTree = (int)char.GetNumericValue(_input[lineIndex][index]);

        if (index + rightTo > _input.Length - 1) {
            return true;
        }

        int rightsideTree = (int)char.GetNumericValue(_input[lineIndex][index + rightTo]);

        if (thisTree > rightsideTree) {
            return VisibleRight(lineIndex, index, rightTo + 1);
        } 

        return false;
    }

    private bool VisibleUp(int lineIndex, int index, int upTo) {
        int thisTree = (int)char.GetNumericValue(_input[lineIndex][index]);

        if (lineIndex - upTo < 0) {
            return true;
        }

        int upTree = (int)char.GetNumericValue(_input[lineIndex - upTo][index]);

        if (thisTree > upTree) {
            return VisibleUp(lineIndex, index, upTo + 1);
        } 

        return false;
    }

    private bool VisibleDown(int lineIndex, int index, int downTo) {
        int thisTree = (int)char.GetNumericValue(_input[lineIndex][index]);

        if (lineIndex + downTo > _input.Length - 1) {
            return true;
        }

        int downTree = (int)char.GetNumericValue(_input[lineIndex + downTo][index]);

        if (thisTree > downTree) {
            return VisibleDown(lineIndex, index, downTo + 1);
        } 

        return false;
    }

    public int SolvePartOne()
    {
        // Look through every item line by line.
        // If there is another tree to the left, right, top or bottom, call it recursively.
        // Navigate to see if its visible as long as there are smaller trees down the line; 
        int total = 0;
        
        for (int i = 0; i < _input.Length; i++) {
            for (int j = 0; j < _input[i].Length; j++) {
                if (VisibleDown(i, j, 1) || VisibleLeft(i, j, 1) || VisibleRight(i, j, 1) || VisibleUp(i, j, 1)) {
                    //Console.WriteLine($"{_input[i][j]} visible at coordinates: {i}, {j}");
                    total++;
                }
            }
        }

        return total;
    }

    //public int SolvePartTwo()
    //{
    //}
}