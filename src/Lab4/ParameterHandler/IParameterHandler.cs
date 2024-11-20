using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler;

public interface IParameterHandler
{
    IParameterHandler AddNext(IParameterHandler handler);

    ICommand? Handle(IEnumerator<string> request);
}