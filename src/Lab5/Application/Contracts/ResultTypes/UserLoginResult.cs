using Contracts.ResultTypes.Errors.Interfaces;

namespace Contracts.ResultTypes;

public abstract record UserLoginResult
{
    private UserLoginResult() { }

    public sealed record Success : UserLoginResult;

    public sealed record Failure(IError Err) : UserLoginResult;
}