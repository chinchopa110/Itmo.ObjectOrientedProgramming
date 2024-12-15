using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes;

public abstract record CreateResults
{
    private CreateResults() { }

    public sealed record Success : CreateResults;

    public sealed record Failure(IError Err) : CreateResults;
}