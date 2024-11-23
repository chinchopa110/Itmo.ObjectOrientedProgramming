using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler.FlagParser;

public class ConsoleFileShowCommandBuilder
{
    private string? _showMode;

    private string? _path;

    public void SetShowMode(string showMode)
    {
        _showMode = showMode;
    }

    public void SetPath(string path)
    {
        _path = path;
    }

    public ICommand? Build()
    {
        if (_showMode == null || _path == null)
        {
            return null;
        }

        return new ConsoleShowFileCommand(_path);
    }
}