using DomainModel.Users.ResultTypes;
using DomainModel.Users.Transaction;
using DomainModel.Users.ValueObject;

namespace DomainModel.Users;

public interface IUser
{
    public long AccountNumber { get; }

    public PinCode PinCode { get; }

    public Balance Balance { get; }

    public IReadOnlyCollection<TransactionItem> Transactions { get; }

    public void TopUp(double sum);

    public WithdrawResult Withdraw(double sum);
}