using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection;

public class AcceleratingMagneticPath : IBaseMagneticPath
{
    public double Length { get; }

    private readonly double _power;

    public AcceleratingMagneticPath(double length, double power)
    {
        Length = length;
        _power = power;
    }

    public Result SectionProcessing(Train train)
    {
        if (!train.ApplyPower(_power)) return new Result.Failure(new BigPower("High power accelerating rails"));
        return train.Move(Length);
    }
}