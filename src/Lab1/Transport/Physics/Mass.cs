namespace Itmo.ObjectOrientedProgramming.Lab1.Transport.Physics;

public class Mass
{
    public double Value { get; }

    public Mass(double value)
    {
        Value = value;
    }

    public static Mass operator +(Mass m1, Mass m2)
    {
        return new Mass(m1.Value + m2.Value);
    }

    public static Mass operator +(Mass m, double additionalValue)
    {
        return new Mass(m.Value + additionalValue);
    }

    public static Mass operator +(double additionalValue, Mass m)
    {
        return new Mass(m.Value + additionalValue);
    }
}