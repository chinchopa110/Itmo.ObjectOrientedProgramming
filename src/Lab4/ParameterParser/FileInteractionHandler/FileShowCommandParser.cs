using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler.FlagParser;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FlagHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler;

public class FileShowCommandParser : ParameterParserBase
{
    private readonly IFlagParser<ConsoleFileShowCommandBuilder> _flagParser;

    public FileShowCommandParser(IFlagParser<ConsoleFileShowCommandBuilder> flagParser)
    {
        _flagParser = flagParser;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "show")
        {
            if (!request.MoveNext())
                return null;

            var builder = new ConsoleFileShowCommandBuilder();
            _flagParser.Handle(request, builder);
            ICommand? command = builder.Build();
            return command ?? Next?.Handle(request);
        }

        return Next?.Handle(request);
    }
}