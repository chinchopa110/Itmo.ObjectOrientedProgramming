using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

public record FileSystemInteractionResult
{
    private FileSystemInteractionResult() { }

    public sealed record Success : FileSystemInteractionResult;

    public sealed record Failure(IError Err) : FileSystemInteractionResult;
}