using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using System.Collections.Immutable;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class Route
{
    private readonly ImmutableArray<ISection> _objects;
    private readonly double _maxfinalspeed;

    public Route(double maxfinalspeed, ImmutableArray<ISection> objects)
    {
        _objects = ImmutableArray.CreateRange(objects);
        _maxfinalspeed = maxfinalspeed;
    }

    public Result Pass(Train train)
    {
        foreach (ISection obj in _objects)
        {
            Result resultOnSection = obj.SectionProcessing(train);
            if (resultOnSection is not Result.Success) return resultOnSection;
        }

        return train.TrainSpeed.Value > _maxfinalspeed
            ? new Result.Failure(new BigSpeed("Big speed at the end"))
            : new Result.Success(train.Time);
    }
}