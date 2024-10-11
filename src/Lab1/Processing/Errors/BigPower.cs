namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class BigPower : IError
{
    public string Message { get; }

    public BigPower(string message)
    {
        Message = message;
    }
}