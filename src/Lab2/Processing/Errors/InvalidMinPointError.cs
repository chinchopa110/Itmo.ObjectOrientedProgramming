using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

public class InvalidMinPointError : IError
{
    public string Message { get; }

    public InvalidMinPointError()
    {
        Message = "The minimum score must be no more than 100";
    }
}