using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser;

public abstract class ParameterParserBase : IParameterParser
{
    protected IParameterParser? Next { get; private set; }

    public IParameterParser AddNext(IParameterParser parser)
    {
        if (Next is null)
        {
            Next = parser;
        }
        else
        {
            Next.AddNext(parser);
        }

        return this;
    }

    public abstract ICommand? Handle(IEnumerator<string> request);
}