using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

public class ExaminationSubject : IError
{
    public string Message { get; }

    public ExaminationSubject(string message)
    {
        Message = message;
    }
}