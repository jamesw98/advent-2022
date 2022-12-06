namespace advent_2022;

public class Day6 : Day
{
    public Day6(string filename) : base(filename)
    {
    }
    
    public int Part1()
    {
        return Calculate(4);
    }
    
    public int Part2()
    {
        return Calculate(14);
    }

    private int Calculate(int markerNum)
    {
        for (int i = 0; i < _lines[0].Length - markerNum; i++)
        {
            if (_lines[0].Substring(i, markerNum).Distinct().Count() == markerNum)
                return i + markerNum;
        }
        return -1;
    }
}