using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;

public interface ISection
{
    public TheResultOfThePassageRoute SectionProcessing(Train train);
}