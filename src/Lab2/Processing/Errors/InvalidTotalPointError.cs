using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

public class InvalidTotalPointError : IError
{
    public string Message { get; }

    public InvalidTotalPointError()
    {
        Message = "The total points must be one hundred";
    }
}