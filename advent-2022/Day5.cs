using System.Text.RegularExpressions;

namespace advent_2022;

public class Day5 : Day
{
    private class Instruction
    {
        public int Count { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
    
    public Day5(string filename) : base(filename)
    {
    }
    
    public string Part1()
    {
        var (cranes, instructions) = ReadInput();
        return CrateMover9000(instructions, cranes);
    }
    
    public string Part2()
    {
        var (cranes, instructions) = ReadInput();
        return CrateMover9001(instructions, cranes);
    }
    
    private string CreateResult(List<Stack<char>> cranes)
    {
        var result = "";
        foreach (var c in cranes)
            result += c.Peek();
        return result;
    }

    private string CrateMover9000(List<Instruction> instructions, List<Stack<char>> cranes)
    {
        foreach (var i in instructions)
        {
            for (var j = 0; j < i.Count; j++)
                cranes[i.To - 1].Push(cranes[i.From - 1].Pop());
        }

        return CreateResult(cranes);
    }
    
    private string CrateMover9001(List<Instruction> instructions, List<Stack<char>> cranes)
    {
        foreach (var i in instructions)
        {
            var temp = "";
            for (var j = 0; j < i.Count; j++)
                temp +=  cranes[i.From - 1].Pop();
            
            foreach (var c in temp.Reverse())
                cranes[i.To - 1].Push(c);
        }

        return CreateResult(cranes);
    }

    private (List<Stack<char>>, List<Instruction>) ReadInput()
    {
        var finishedStacks = false;
        
        List<Stack<char>> cranes = new();
        List<Instruction> instructions = new();
        foreach (var l in _lines)
        {
            if (l.Equals(""))
            {
                finishedStacks = true;
                continue;
            }
                
            if (finishedStacks)
                instructions.Add(ReadInstruction(l));
            else
                cranes.Add(ReadStack(l));     
        }

        return (cranes, instructions);
    }
    
    private Stack<char> ReadStack(string line)
    {
        Stack<char> stack = new();
        foreach (var c in line)
            stack.Push(c);
        return stack;
    }

    private Instruction ReadInstruction(string line)
    {
        var pattern = new Regex(@"move ([0-9]+) from ([0-9]+) to ([0-9]+)");
        var match = pattern.Match(line);

        return new Instruction
        {
            Count = int.Parse(match.Groups[1].Value),
            From = int.Parse(match.Groups[2].Value),
            To = int.Parse(match.Groups[3].Value)
        };

    }
}