using DomainModel.Users.ResultTypes;
using DomainModel.Users.Transaction;
using DomainModel.Users.ValueObject;

namespace DomainModel.Users;

public class AccountUser : IUser
{
    private readonly List<TransactionItem> _transactions;

    public long AccountNumber { get; }

    public PinCode PinCode { get; }

    public Balance Balance { get; }

    public IReadOnlyCollection<TransactionItem> Transactions => _transactions.AsReadOnly();

    public AccountUser(
        long accountNumber,
        string pinCode,
        double balance,
        IReadOnlyCollection<TransactionItem> transactions)
    {
        AccountNumber = accountNumber;
        PinCode = new PinCode(pinCode);
        Balance = new Balance(balance);
        _transactions = transactions.ToList();
    }

    public void TopUp(double sum)
    {
        Balance.TopUpBalance(sum);
        _transactions.Add(new TransactionItem(TransactionType.TopUp, sum));
    }

    public WithdrawResult Withdraw(double sum)
    {
        WithdrawResult result = Balance.DownUpBalance(sum);
        if (result is WithdrawResult.Success)
            _transactions.Add(new TransactionItem(TransactionType.Withdraw, sum));

        return result;
    }
}