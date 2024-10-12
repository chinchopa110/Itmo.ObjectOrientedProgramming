namespace Itmo.ObjectOrientedProgramming.Lab1.Transport.Physics;

public class Mass
{
    public double Value { get; }

    private readonly double _minMass;

    public Mass(double value, double minMass)
    {
        Value = value;
        _minMass = minMass;
    }

    public bool IsNegativeMass()
    {
        return Value < _minMass;
    }
}