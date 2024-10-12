using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Transport.Physics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public class Train
{
    private readonly int _accuracy;

    private readonly double _massTrain;

    private readonly double _maxPower;

    private double _acceleration;

    private Mass _trainMass;

    public double Speed { get; private set; }

    public Train(double massTrain, double maxPower, int accuracy)
    {
        _accuracy = accuracy;
        _massTrain = massTrain;
        _maxPower = maxPower;

        Speed = 0;
        _acceleration = 0;
        _trainMass = new Mass(_massTrain, _massTrain);
    }

    public TheResultOfTrainMoving LoadPassengers(double workload)
    {
        var time = TimeSpan.FromMinutes(0);
        _trainMass = new Mass(_massTrain + _trainMass.Value + workload, _massTrain);

        if (_trainMass.IsNegativeMass())
            return new TheResultOfTrainMoving.SomethingWrong(new NegativePassengerWeight("The mass is negative"));

        workload = double.Abs(workload);
        while (workload > 0)
        {
            workload -= 5 * _accuracy;
            time += TimeSpan.FromMinutes(_accuracy);
        }

        return new TheResultOfTrainMoving.CompleteSection(time);
    }

    public bool ApplyPower(double power)
    {
        if (power > _maxPower) return false;
        _acceleration = power / _trainMass.Value;
        return true;
    }

    public TheResultOfTrainMoving Move(double distance)
    {
        var time = TimeSpan.FromMinutes(0);
        while (distance > 0)
        {
            if (Speed < 0)
                return new TheResultOfTrainMoving.SomethingWrong(new SectionNotPassed("The train stopped"));

            double resSpeed = Speed + (_acceleration * _accuracy);
            double completedDist = resSpeed * _accuracy;
            distance -= completedDist;

            Speed = resSpeed;
            time += TimeSpan.FromMinutes(_accuracy);
        }

        return new TheResultOfTrainMoving.CompleteSection(time);
    }
}