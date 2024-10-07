using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection;

public class ConventionalMp : IBaseMp
{
    public double Length { get; }

    public ConventionalMp(double length)
    {
        Length = length;
    }

    public bool IsPassing(Train train)
    {
        return train.Speed > 0;
    }

    public ResultTypes SectionProcessing(Train train)
    {
        train.ApplyPower(0);

        if (!IsPassing(train)) return new ResultTypes.FailurePass();

        return train.Move(Length);
    }
}