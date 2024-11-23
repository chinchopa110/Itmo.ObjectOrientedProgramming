using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FlagHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler.FlagParser;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler;

public class ListCommandParser : ParameterParserBase
{
    private readonly IFlagParser<ListCommandBuilder> _flagParser;

    public ListCommandParser(IFlagParser<ListCommandBuilder> flagParser)
    {
        _flagParser = flagParser;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current != "list")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        var builder = new ListCommandBuilder();
        _flagParser.Handle(request, builder);
        ICommand? command = builder.Build();
        return command ?? Next?.Handle(request);
    }
}