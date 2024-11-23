using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FlagHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler.FlagParser;

public class ListParameterParser<TBuilder> : IFlagParser<TBuilder> where TBuilder : ListCommandBuilder
{
    private IFlagParser<TBuilder>? _next;

    public IFlagParser<TBuilder> AddNext(IFlagParser<TBuilder> flagParser)
    {
        _next = flagParser;
        return flagParser;
    }

    public TBuilder? Handle(IEnumerator<string> request, TBuilder builder)
    {
        if (request.Current != "-d")
            return _next?.Handle(request, builder);

        if (!request.MoveNext())
            return builder;

        builder.SetDepth(request.Current);

        return builder;
    }
}