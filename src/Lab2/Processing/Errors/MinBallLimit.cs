using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

public class MinBallLimit : IError
{
    public string Message { get; }

    public MinBallLimit()
    {
        Message = "The minimum score must be no more than 100";
    }
}