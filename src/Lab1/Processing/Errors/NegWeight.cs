namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class NegWeight : IError
{
    public string Message { get; }

    public NegWeight(string message)
    {
        Message = message;
    }
}