using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class Route
{
    private readonly IReadOnlyCollection<ISection> _sections;
    private readonly double _maxfinalspeed;

    public Route(double maxfinalspeed, IReadOnlyCollection<ISection> sections)
    {
        _sections = sections;
        _maxfinalspeed = maxfinalspeed;
    }

    public TheResultOfThePassageRoute Pass(Train train)
    {
        var time = TimeSpan.FromMinutes(0);
        foreach (ISection obj in _sections)
        {
            TheResultOfThePassageRoute resultOnSection = obj.SectionProcessing(train);
            if (resultOnSection is not TheResultOfThePassageRoute.Success)
                return resultOnSection;

            if (resultOnSection is TheResultOfThePassageRoute.Success completeSection)
                time += completeSection.Time;
        }

        return train.Speed > _maxfinalspeed
            ? new TheResultOfThePassageRoute.Failure(new SpeedLimitExceeded("Big speed at the end"))
            : new TheResultOfThePassageRoute.Success(time);
    }
}