namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FlagHandler;

public interface IFlagParser<TBuilder>
{
    IFlagParser<TBuilder> AddNext(IFlagParser<TBuilder> flagParser);

    TBuilder? Handle(IEnumerator<string> request, TBuilder builder);
}