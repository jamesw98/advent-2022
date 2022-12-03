namespace advent_2022;

public class Day3 : Day
{
    public Day3(string filename) : base(filename)
    {
    }

    public int Part1()
    {
        var score = 0;
        foreach (var l in _lines)
        {
            var charsInCommon = l[..(l.Length / 2)]
                .Intersect(l[(l.Length / 2)..])
                .Distinct();
            
            score += charsInCommon.Sum(c => CharToScore(c));
        }
        return score;
    }
    
    public int Part2()
    {
        List<string> groupOfThreeElves = new();
        var score = 0;
        
        var counter = 1;
        foreach (var l in _lines)
        {
            groupOfThreeElves.Add(l);
            if (counter % 3 == 0)
            {
                var charsInCommon = groupOfThreeElves[0]
                    .Intersect(groupOfThreeElves[1])
                    .Intersect(groupOfThreeElves[2])
                    .Distinct().ToList();

                score += charsInCommon.Sum(c => CharToScore(c));;
                groupOfThreeElves.Clear();
            }
            counter++;
        }
        return score;
    }

    // spooky stuff
    private int CharToScore(char value)
    {
        // upper case
        if (value <= 97)
            return value - '&';
        // lower case
        return value - '`';
    }
}