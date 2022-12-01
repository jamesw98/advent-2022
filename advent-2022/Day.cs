namespace advent_2022;

public class Day
{
    protected string[] _lines;

    protected Day(string filename)
    {
        _lines = File.ReadAllLines($"F:\\dev\\advent-2022\\advent-2022\\{filename}");
    }
}