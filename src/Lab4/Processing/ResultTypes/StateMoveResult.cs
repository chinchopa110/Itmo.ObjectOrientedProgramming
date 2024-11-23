using Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

public abstract record StateMoveResult
{
    private StateMoveResult() { }

    public sealed record Success(IFileSystem Context) : StateMoveResult;

    public sealed record InvalidMode(IError Err) : StateMoveResult;
}