using Itmo.ObjectOrientedProgramming.Lab1.Processing;

namespace Itmo.ObjectOrientedProgramming.Lab1.Transport;

public class Train
{
    public double Mass { get; private set; }

    public double Speed { get; private set; }

    public double Acceleration { get; private set; }

    public double Time { get; private set; }

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

    public ResultTypes LoadPassengers(double workload)
    {
        Mass += workload;

        if (Mass < _massTrain)
            return new ResultTypes.FailureNegWeight();

        workload = double.Abs(workload);
        while (workload > 0)
        {
            workload -= 5 * Accuracy;
            Time += Accuracy;
        }

        return new ResultTypes.Success();
    }

    public void UpdateSpeed()
    {
        Speed += Acceleration * Accuracy;
    }

    public bool ApplyPower(double power)
    {
        if (!CheckPower(power)) return false;

        Acceleration = power / Mass;

        return true;
    }

    public ResultTypes Move(double distance)
    {
        while (distance > 0)
        {
            if (Speed < 0) return new ResultTypes.FailurePass();

            double resSpeed = Speed + (Acceleration * Accuracy);
            double completedDist = resSpeed * Accuracy;
            distance -= completedDist;

            UpdateSpeed();
            Time += Accuracy;
        }

        return new ResultTypes.Success();
    }
}