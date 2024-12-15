using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes.Errors;

public class NotAuthorized : IError
{
    public string ErrorDescription { get; }

    public NotAuthorized()
    {
        ErrorDescription = "You are not authorized to perform this operation.";
    }
}