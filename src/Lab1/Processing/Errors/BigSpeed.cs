namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class BigSpeed : IError
{
    public string Message { get; }

    public BigSpeed(string message)
    {
        Message = message;
    }
}