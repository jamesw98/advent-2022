namespace advent_2022;

public class Day1 : Day
{
    public Day1(string filename) : base(filename)
    {
    }

    public int Part1()
    {
        return GetElves().Max();
    }
    
    public int Part2()
    {
        return GetElves().OrderByDescending(x => x).Take(3).Sum();
    }

    private List<int> GetElves()
    {
        List<int> elves = new();
        var currentCalories = 0;

        foreach (var l in _lines)
        {
            if (l.Equals(string.Empty))
            {
                elves.Add(currentCalories);                
                currentCalories = 0;   
            }
            else
                currentCalories += int.Parse(l);                
        }

        return elves;
    }
}