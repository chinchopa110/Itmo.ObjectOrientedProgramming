using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class Route
{
    private readonly List<object> _objects;

    private readonly Train _train;

    private readonly double _maxfinalspeed;

    public Route(Train train, double maxfinalspeed, params object[] objects)
    {
        _train = train;
        _objects = new List<object>(objects);
        _maxfinalspeed = maxfinalspeed;
    }

    public ResultTypes Passing()
    {
        foreach (ISection obj in _objects)
        {
            if (!obj.IsPassing(_train)) return new ResultTypes.FailurePass();

            ResultTypes resultOnSection = obj.SectionProcessing(_train);
            if (resultOnSection is not ResultTypes.Success) return resultOnSection;
        }

        return _train.Speed > _maxfinalspeed ? new ResultTypes.FailureBigSpeed() : new ResultTypes.Success();
    }
}