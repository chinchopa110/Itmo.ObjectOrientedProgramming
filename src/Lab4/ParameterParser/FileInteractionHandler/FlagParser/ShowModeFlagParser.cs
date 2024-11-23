using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FlagHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler.FlagParser;

public class ShowModeFlagParser<TBuilder> : IFlagParser<TBuilder> where TBuilder : ConsoleFileShowCommandBuilder
{
    private IFlagParser<TBuilder>? _next;

    public IFlagParser<TBuilder> AddNext(IFlagParser<TBuilder> flagParser)
    {
        _next = flagParser;
        return flagParser;
    }

    public TBuilder? Handle(IEnumerator<string> request, TBuilder builder)
    {
        builder.SetPath(request.Current);

        if (!request.MoveNext())
            return builder;

        if (request.Current != "-m")
            return _next?.Handle(request, builder);

        if (!request.MoveNext())
            return builder;

        string mode = request.Current;

        if (mode == "console")
            builder.SetShowMode("console");

        return builder;
    }
}