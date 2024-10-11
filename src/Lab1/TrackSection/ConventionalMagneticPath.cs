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

    public Result SectionProcessing(Train train)
    {
        train.ApplyPower(0);
        if (train.TrainSpeed.Value == 0) return new Result.Failure(new Stopped("The train stopped"));
        return train.Move(_length);
    }
}