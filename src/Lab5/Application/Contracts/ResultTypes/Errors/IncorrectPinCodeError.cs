using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes.Errors;

public class IncorrectPinCodeError : IError
{
    public string ErrorDescription { get; }

    public IncorrectPinCodeError()
    {
        ErrorDescription = "Incorrect PinCode";
    }
}