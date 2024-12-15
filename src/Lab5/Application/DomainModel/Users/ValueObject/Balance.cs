using DomainModel.Users.ResultTypes;

namespace DomainModel.Users.ValueObject;

public class Balance
{
    public double Amount { get; private set; }

    public Balance(double amount)
    {
        Amount = amount;
    }

    public void TopUpBalance(double amount)
    {
        Amount += amount;
    }

    public WithdrawResult DownUpBalance(double amount)
    {
        if (Amount < amount)
            return new WithdrawResult.NotEnoughMoney();

        Amount -= amount;
        return new WithdrawResult.Success();
    }
}