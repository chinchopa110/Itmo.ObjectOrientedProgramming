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

    public Result SectionProcessing(Train train)
    {
        if (!train.ApplyPower(_power)) return new Result.Failure(new BigPower("High power accelerating rails"));
        return train.Move(_length);
    }
}