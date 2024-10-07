using Itmo.ObjectOrientedProgramming.Lab1.Processing;
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

    public bool IsPassing(Train train)
    {
        if (train.Speed <= _maxSpeed) return true;

        return false;
    }

    public ResultTypes SectionProcessing(Train train)
    {
        if (!IsPassing(train)) return new ResultTypes.FailurePass();

        if (train.LoadPassengers(_workload) is not ResultTypes.Success) return new ResultTypes.FailureNegWeight();

        return new ResultTypes.Success();
    }
}