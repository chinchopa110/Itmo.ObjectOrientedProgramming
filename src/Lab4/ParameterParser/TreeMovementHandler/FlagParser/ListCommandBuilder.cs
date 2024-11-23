using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler.FlagParser;

public class ListCommandBuilder
{
    private string? _depth;

    public void SetDepth(string depth)
    {
        _depth = depth;
    }

    public ICommand? Build()
    {
        if (!int.TryParse(_depth, out int depth) || _depth is null)
            return null;

        return new ListCommand(depth);
    }
}