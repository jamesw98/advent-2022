namespace advent_2022;

public class Day2 : Day
{
    private const string ERock = "A";
    private const string EPaper = "B";
    private const string EScissors = "C";
    
    private const string MRock = "X";
    private const string MPaper = "Y";
    private const string MScissors = "Z";

    private const int RockScore = 1;
    private const int PaperScore = 2;
    private const int ScissorsScore = 3;

    public Day2(string filename) : base(filename)
    {
    }
    
    public int Part1()
    {
        var myScore = 0;

        foreach (var l in _lines)
        {
            var split = l.Split(" ");
            myScore += GetScore(split[0], split[1]);
        }

        return myScore;
    }
    
    public int Part2()
    {
        var myScore = 0;

        foreach (var l in _lines)
        {
            var split = l.Split(" ");
            var elf = split[0];
            myScore += GetScore(elf, GetMyChoice(elf));
        }

        return myScore;
    }

    private string GetMyChoice(string elf)
    {
        return elf switch
        {
            MRock => GetLoseString(elf),
            MPaper => GetDrawString(elf),
            MScissors => GetWinString(elf),
            _ => ""
        };
    }

    private int GetScore(string elf, string me)
    {
        var score = me switch
        {
            MRock => RockScore,
            MPaper => PaperScore,
            MScissors => ScissorsScore,
            _ => 0
        };
            
        return score + GetWinDrawLossScore(elf, me);
    }

    private string GetWinString(string elf)
    {
        return elf switch
        {
            ERock => MPaper,
            EPaper => MScissors,
            EScissors => MRock,
            _ => ""
        };
    }
    
    private string GetDrawString(string elf)
    {
        return elf switch
        {
            ERock => MRock,
            EPaper => MPaper,
            EScissors => MScissors,
            _ => ""
        };
    }
    
    private string GetLoseString(string elf)
    {
        return elf switch
        {
            ERock => MScissors,
            EPaper => MRock,
            EScissors => MPaper,
            _ => ""
        };
    }
    
    private int GetWinDrawLossScore(string elf, string me)
    {
        switch (elf)
        {
            case ERock when me.Equals(MRock):
            case EPaper when me.Equals(MPaper):
            case EScissors when me.Equals(MScissors):
                return 3;
            case ERock when me.Equals(MPaper):
            case EPaper when me.Equals(MScissors):
            case EScissors when me.Equals(MRock):
                return 6;
            default:
                return 0;
        }
    }
}