using Itmo.ObjectOrientedProgramming.Lab1.Processing;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public class Train
{
    public double Mass { get; private set; }

    public double Speed { get; private set; }

    public double Acceleration { get; private set; }

    public double Time { get; set; }

    public int Accuracy { get; }

    private readonly double _maxPower;

    private readonly double _massTrain;

    private bool CheckPower(double power)
    {
        return power <= _maxPower;
    }

    public Train(double massTrain, double maxPower, int accuracy)
    {
        Mass = massTrain;
        _massTrain = massTrain;

        Speed = 0;
        Acceleration = 0;
        Time = 0;

        _maxPower = maxPower;
        Accuracy = accuracy;
    }

    public ResultTypes UpdateMass(double massPassenger)
    {
        Mass += massPassenger;

        if (Mass < _massTrain)
            return new ResultTypes.FailureNegWeight();

        return new ResultTypes.Success();
    }

    public void UpdateSpeed()
    {
        Speed += Acceleration * Accuracy;
    }

    public ResultTypes ApplyPower(double power)
    {
        if (!CheckPower(power)) return new ResultTypes.FailureBigPower();

        Acceleration = power / Mass;

        return new ResultTypes.Success();
    }
}