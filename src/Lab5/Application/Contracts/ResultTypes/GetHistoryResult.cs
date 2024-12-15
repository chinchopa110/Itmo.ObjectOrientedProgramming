using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes;

public record GetHistoryResult
{
    private GetHistoryResult() { }

    public sealed record Success(IReadOnlyCollection<string> History) : GetHistoryResult;

    public sealed record Failure(IError Err) : GetHistoryResult;
}