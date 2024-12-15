namespace DomainModel.Users.ValueObject;

public class PinCode
{
    private readonly string _pinCode;

    public PinCode(string pinCode)
    {
        _pinCode = pinCode;
    }

    public bool Login(string pinCode)
    {
        return _pinCode == pinCode;
    }
}