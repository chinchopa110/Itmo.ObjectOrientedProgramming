using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes;

public record GetBalanceResult
{
    private GetBalanceResult() { }

    public sealed record Success(double Balance) : GetBalanceResult;

    public sealed record Failure(IError Err) : GetBalanceResult;
}