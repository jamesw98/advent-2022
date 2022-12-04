namespace advent_2022;

public class Day4 : Day
{
    public Day4(string filename) : base(filename)
    {
    }

    public int Part1()
    {
        var numFullyContained = 0;
        
        foreach (var line in _lines)
        {
            var (left, right) = SplitLine(line);

            if (left.All(l => right.Contains(l)) || right.All(r => left.Contains(r)))
                numFullyContained++;
        }

        return numFullyContained;
    }

    public int Part2()
    {
        var numFullyContained = 0;
        
        foreach (var line in _lines)
        {
            var (left, right) = SplitLine(line);

            if (left.Any(l => right.Contains(l)) || right.Any(r => left.Contains(r)))
                numFullyContained++;
        }

        return numFullyContained;
    }

    private static (List<int>, List<int>) SplitLine(string line)
    {
        var splitComma = line.Split(",");
        var lLower = int.Parse(splitComma[0].Split('-')[0]);
        var lUpper = int.Parse(splitComma[0].Split('-')[1]);
        var rLower = int.Parse(splitComma[1].Split('-')[0]);
        var rUpper = int.Parse(splitComma[1].Split('-')[1]);

        List<int> left = new();
        List<int> right = new();

        for (int i = lLower; i <= lUpper; i++)
            left.Add(i);
        for (int i = rLower; i <= rUpper; i++)
            right.Add(i);

        return (left, right);
    }
}