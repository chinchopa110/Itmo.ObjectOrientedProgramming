using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;

public interface ISection
{
    public bool IsPassing(Train train);

    public ResultTypes SectionProcessing(Train train);
}