namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class Stopped : IError
{
    public string Message { get; }

    public Stopped(string message)
    {
        Message = message;
    }
}