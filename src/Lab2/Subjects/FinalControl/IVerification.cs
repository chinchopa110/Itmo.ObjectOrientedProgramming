using Itmo.ObjectOrientedProgramming.Lab2.Processing;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;

public interface IVerification
{
    public VerificationValidateResult Validate(int points);
}