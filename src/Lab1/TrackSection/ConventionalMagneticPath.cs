using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection;

public class ConventionalMagneticPath : ISection
{
    private readonly double _length;

    public ConventionalMagneticPath(double length)
    {
        _length = length;
    }

    public TheResultOfThePassageRoute SectionProcessing(Train train)
    {
        if (train.Speed == 0)
            return new TheResultOfThePassageRoute.Failure(new SectionNotPassed("The train stopped"));

        TheResultOfTrainMoving moveResult = train.Move(_length);

        if (moveResult is TheResultOfTrainMoving.SomethingWrong somethingWrong)
            return new TheResultOfThePassageRoute.Failure(somethingWrong.Err);

        if (moveResult is TheResultOfTrainMoving.CompleteSection completeSection)
            return new TheResultOfThePassageRoute.Success(completeSection.Time);

        return new TheResultOfThePassageRoute.Failure(new UnknownError("Unknown error"));
    }
}