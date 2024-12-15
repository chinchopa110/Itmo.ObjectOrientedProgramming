using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes.Errors;

public class NotFoundError : IError
{
    public string ErrorDescription { get; }

    public NotFoundError()
    {
        ErrorDescription = "Account not found";
    }
}