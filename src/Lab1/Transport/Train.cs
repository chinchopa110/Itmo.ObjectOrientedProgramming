using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Transport.Physics;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public class Train
{
    private readonly int _accuracy;

    private readonly double _massTrain;

    private readonly double _maxPower;

    public Speed TrainSpeed { get; private set; }

    public Acceleration TrainAcceleration { get; private set; }

    public Mass TrainMass { get; private set; }

    public TimeSpan Time { get; private set; }

    public Train(double massTrain, double maxPower, int accuracy)
    {
        _accuracy = accuracy;
        _massTrain = massTrain;
        _maxPower = maxPower;

        TrainAcceleration = new Acceleration(0);
        TrainSpeed = new Speed(0);
        TrainMass = new Mass(_massTrain);
    }

    public bool LoadPassengers(double workload)
    {
        TrainMass += workload;

        if (TrainMass.Value < _massTrain)
            return false;

        workload = double.Abs(workload);
        while (workload > 0)
        {
            workload -= 5 * _accuracy;
            Time += TimeSpan.FromMilliseconds(_accuracy);
        }

        return true;
    }

    public bool ApplyPower(double power)
    {
        if (power > _maxPower) return false;
        TrainAcceleration = new Acceleration(power / TrainMass.Value);
        return true;
    }

    public Result Move(double distance)
    {
        while (distance > 0)
        {
            if (TrainSpeed.Value < 0) return new Result.Failure(new Stopped("The train stopped"));

            double resSpeed = TrainSpeed.Value + (TrainAcceleration.Value * _accuracy);
            double completedDist = resSpeed * _accuracy;
            distance -= completedDist;

            TrainSpeed = new Speed(resSpeed);
            Time += TimeSpan.FromMinutes(_accuracy);
        }

        return new Result.Success(Time);
    }
}