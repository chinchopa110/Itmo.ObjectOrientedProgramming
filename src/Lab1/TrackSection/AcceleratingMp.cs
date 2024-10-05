using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection;

public class AcceleratingMp : IBaseMp
{
    public double Length { get; }

    private readonly double _power;

    public AcceleratingMp(double length, double power)
    {
        Length = length;
        _power = power;
    }

    public bool IsPassing(Train train)
    {
        return train.Speed >= 0;
    }

    public ResultTypes SectionProcessing(Train train)
    {
        double neededLength = Length;

        if (train.ApplyPower(_power) is not ResultTypes.Success) return new ResultTypes.FailureBigPower();

        while (neededLength > 0)
        {
            if (!IsPassing(train)) return new ResultTypes.FailurePass();

            double resSpeed = train.Speed + (train.Acceleration * train.Accuracy);
            double completedDist = resSpeed * train.Accuracy;
            neededLength -= completedDist;

            train.UpdateSpeed();
            train.Time += train.Accuracy;
        }

        return new ResultTypes.Success();
    }
}