using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes;

public record TransactionExecuteResult
{
    private TransactionExecuteResult() { }

    public sealed record Success : TransactionExecuteResult;

    public sealed record Failure(IError Err) : TransactionExecuteResult;
}