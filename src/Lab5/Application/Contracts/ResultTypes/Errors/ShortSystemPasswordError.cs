using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes.Errors;

public class ShortSystemPasswordError : IError
{
    public string ErrorDescription { get; }

    public ShortSystemPasswordError()
    {
        ErrorDescription = "Password must be longer than 8 characters.";
    }
}