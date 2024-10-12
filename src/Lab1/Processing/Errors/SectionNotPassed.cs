using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class SectionNotPassed : IError
{
    public string Message { get; }

    public SectionNotPassed(string message)
    {
        Message = message;
    }
}