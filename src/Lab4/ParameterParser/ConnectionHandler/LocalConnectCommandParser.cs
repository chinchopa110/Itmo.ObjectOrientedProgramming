using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.ConnectionHandler.FlagParser;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FlagHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.ConnectionHandler;

public class LocalConnectCommandParser : ParameterParserBase
{
    private readonly IFlagParser<LocalConnectCommandBuilder> _flagParser;

    public LocalConnectCommandParser(IFlagParser<LocalConnectCommandBuilder> flagParser)
    {
        _flagParser = flagParser;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "connect")
        {
            if (!request.MoveNext())
                return null;

            var builder = new LocalConnectCommandBuilder();
            _flagParser.Handle(request, builder);
            ICommand? command = builder.Build();
            return command ?? Next?.Handle(request);
        }

        return Next?.Handle(request);
    }
}