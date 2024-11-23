using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.ConnectionHandler.FlagParser;

public class LocalConnectCommandBuilder
{
    private string? _mode;

    private string? _path;

    public void SetMode(string mode)
    {
        _mode = mode;
    }

    public void SetPath(string path)
    {
        _path = path;
    }

    public ICommand? Build()
    {
        if (_mode == null || _path == null)
            return null;

        return new LocalConnectCommand(_path);
    }
}