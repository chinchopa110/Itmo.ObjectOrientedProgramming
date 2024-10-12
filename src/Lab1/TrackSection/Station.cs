using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection;

public class Station : ISection
{
    private readonly double _workload;

    private readonly double _maxSpeed;

    public Station(double workload, double maxSpeed)
    {
        _workload = workload;
        _maxSpeed = maxSpeed;
    }

    public TheResultOfThePassageRoute SectionProcessing(Train train)
    {
        if (train.Speed > _maxSpeed)
            return new TheResultOfThePassageRoute.Failure(new SpeedLimitExceeded("Big speed on station"));

        TheResultOfTrainMoving moveResult = train.LoadPassengers(_workload);

        if (moveResult is TheResultOfTrainMoving.SomethingWrong somethingWrong)
            return new TheResultOfThePassageRoute.Failure(somethingWrong.Err);

        if (moveResult is TheResultOfTrainMoving.CompleteSection completeSection)
            return new TheResultOfThePassageRoute.Success(completeSection.Time);

        return new TheResultOfThePassageRoute.Failure(new UnknownError("Unknown error"));
    }
}