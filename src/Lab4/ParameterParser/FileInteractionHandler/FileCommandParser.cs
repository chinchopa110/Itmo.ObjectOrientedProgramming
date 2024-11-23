using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler.FileChainFactory;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler;

public class FileCommandParser : ParameterParserBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "file")
        {
            IParameterParser fileParser = FileCommandParserFactory.CreateFileCommandHandlerChain();

            if (!request.MoveNext())
                return null;

            return fileParser.Handle(request);
        }

        return Next?.Handle(request);
    }
}