using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser;

public interface IParameterParser
{
    IParameterParser AddNext(IParameterParser parser);

    ICommand? Handle(IEnumerator<string> request);
}