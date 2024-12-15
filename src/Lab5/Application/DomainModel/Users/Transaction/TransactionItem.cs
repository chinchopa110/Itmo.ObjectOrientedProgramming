namespace DomainModel.Users.Transaction;

public class TransactionItem
{
    public TransactionType Type { get; }

    public double Sum { get; }

    public TransactionItem(TransactionType type, double sum)
    {
        Type = type;
        Sum = sum;
    }
}