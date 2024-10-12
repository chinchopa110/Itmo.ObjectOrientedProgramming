using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection;

public class AcceleratingMagneticPath : ISection
{
    private readonly double _length;
    private readonly double _power;

    public AcceleratingMagneticPath(double length, double power)
    {
        _length = length;
        _power = power;
    }

    public TheResultOfThePassageRoute SectionProcessing(Train train)
    {
        if (!train.ApplyPower(_power))
            return new TheResultOfThePassageRoute.Failure(new PowerLimitExceeded("High power accelerating rails"));

        TheResultOfTrainMoving moveResult = train.Move(_length);
        train.ApplyPower(0);

        if (moveResult is TheResultOfTrainMoving.SomethingWrong somethingWrong)
            return new TheResultOfThePassageRoute.Failure(somethingWrong.Err);

        if (moveResult is TheResultOfTrainMoving.CompleteSection completeSection)
            return new TheResultOfThePassageRoute.Success(completeSection.Time);

        return new TheResultOfThePassageRoute.Failure(new UnknownError("Unknown error"));
    }
}