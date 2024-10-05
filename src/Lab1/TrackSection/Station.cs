using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection;

public class Station : ISection
{
    private readonly double _workload;

    private readonly double _maxSpeed;

    private readonly double _massPassenger;

    public Station(double workload, double maxSpeed, double massPassenger)
    {
        _workload = workload;
        _maxSpeed = maxSpeed;
        _massPassenger = massPassenger;
    }

    public bool IsPassing(Train train)
    {
        if (train.Speed <= _maxSpeed) return true;

        return false;
    }

    public ResultTypes SectionProcessing(Train train)
    {
        if (train.UpdateMass(_massPassenger) is not ResultTypes.Success) return new ResultTypes.FailureNegWeight();

        double currworkload = _workload;
        while (currworkload > 0)
        {
            train.Time++;
            currworkload -= 5;
        }

        return new ResultTypes.Success();
    }
}