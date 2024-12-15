namespace Contracts.ResultTypes;

public abstract record AdminLoginResults
{
    private AdminLoginResults() { }

    public sealed record Success : AdminLoginResults;
}