using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes.Errors;

public class NotEnoughMoneyError : IError
{
    public string ErrorDescription { get; }

    public NotEnoughMoneyError()
    {
        ErrorDescription = "You do not have enough money to do that transaction.";
    }
}