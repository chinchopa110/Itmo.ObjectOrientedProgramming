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

    public Result SectionProcessing(Train train)
    {
        if (train.TrainSpeed.Value > _maxSpeed) return new Result.Failure(new BigSpeed("Big speed on station"));

        if (!train.LoadPassengers(_workload))
            return new Result.Failure(new NegWeight("The mass of passengers cannot be negative"));

        return new Result.Success(train.Time);
    }
}