using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler;

public class FileCommandParser : ParameterParserBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "file")
        {
            if (!request.MoveNext())
                return null;
        }

        return Next?.Handle(request);
    }
}