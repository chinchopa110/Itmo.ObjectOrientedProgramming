namespace Itmo.ObjectOrientedProgramming.Lab1.Processing;

public abstract record ResultTypes
{
    private ResultTypes() { }

    public sealed record Success : ResultTypes;

    public sealed record FailureBigSpeed : ResultTypes;

    public sealed record FailurePass : ResultTypes;

    public sealed record FailureBigPower : ResultTypes;

    public sealed record FailureNegWeight : ResultTypes;
}