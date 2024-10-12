using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class NegativePassengerWeight : IError
{
    public string Message { get; }

    public NegativePassengerWeight(string message)
    {
        Message = message;
    }
}