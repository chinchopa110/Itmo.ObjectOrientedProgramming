using Abstraction.Repositories;
using DomainModel.Users;
using DomainModel.Users.Transaction;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public AccountUser? FindUserByAccountNumber(long accountNumber)
    {
        const string sql = """
                           SELECT a.account_number, 
                                  a.pin_code, 
                                  a.balance,
                                  t.type,
                                  t.sum
                           FROM accounts a
                           LEFT JOIN transactions t on
                           (a.account_number = t.account_number)
                           WHERE a.account_number = :accountNumber
                           """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("accountNumber", accountNumber);
        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
            return null;

        long accountNumberResult = reader.GetInt64(0);
        string pinCodeResult = reader.GetString(1);
        double balanceResult = reader.GetDouble(2);

        var transactions = new List<TransactionItem>();
        do
        {
            if (reader.IsDBNull(3))
                break;

            string transactionType = reader.GetString(3);
            if (Enum.TryParse(transactionType, true, out TransactionType parsedType))
            {
                transactions.Add(new TransactionItem(
                    type: parsedType,
                    sum: reader.GetDouble(4)));
            }
        }
        while (reader.Read());

        return new AccountUser(
            accountNumberResult,
            pinCodeResult,
            balanceResult,
            transactions: transactions);
    }

    public void AddAccount(AccountUser accountUser)
    {
        const string insertAccountSql = """
                                            INSERT INTO accounts (account_number, pin_code, balance)
                                            VALUES (:accountNumber, :pinCode, :balance);
                                        """;

        const string insertTransactionSql = """
                                                INSERT INTO transactions (account_number, type, sum)
                                                VALUES (:accountNumber, cast(:type as "transaction_type"), :sum);
                                            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using (var command = new NpgsqlCommand(insertAccountSql, connection))
        {
            command.AddParameter("accountNumber", accountUser.AccountNumber);
            command.AddParameter("pinCode", accountUser.PinCode);
            command.AddParameter("balance", accountUser.Balance.Amount);
            command.ExecuteNonQuery();
        }

        foreach (TransactionItem transactionItem in accountUser.Transactions)
        {
            string transactionTypeString = transactionItem.Type.ToString();

            if (!Enum.IsDefined(typeof(TransactionType), transactionTypeString))
                throw new ArgumentException($"Invalid transaction type: {transactionTypeString}");

            using var command = new NpgsqlCommand(insertTransactionSql, connection);
            command.AddParameter("accountNumber", accountUser.AccountNumber);
            command.AddParameter("type", transactionItem.Type);
            command.AddParameter("sum", transactionItem.Sum);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateAccount(AccountUser accountUser)
    {
        const string updateAccountSql = """
                                            UPDATE accounts 
                                            SET balance = :balance
                                            WHERE account_number = :accountNumber;
                                        """;

        const string deleteTransactionsSql = """
                                                 DELETE FROM transactions WHERE account_number = :accountNumber;
                                             """;

        const string insertTransactionSql = """
                                                INSERT INTO transactions (account_number, type, sum)
                                                VALUES (:accountNumber, cast(:type as "transaction_type"), :sum);
                                            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask()
            .GetAwaiter()
            .GetResult();

        using var command1 = new NpgsqlCommand(updateAccountSql, connection);
        command1.AddParameter("accountNumber", accountUser.AccountNumber);
        command1.AddParameter("balance", accountUser.Balance.Amount);
        command1.ExecuteNonQuery();

        using var command2 = new NpgsqlCommand(deleteTransactionsSql, connection);
        command2.AddParameter("accountNumber", accountUser.AccountNumber);
        command2.ExecuteNonQuery();

        foreach (TransactionItem transactionItem in accountUser.Transactions)
        {
            string transactionTypeString = transactionItem.Type.ToString();

            if (!Enum.IsDefined(typeof(TransactionType), transactionTypeString))
                throw new ArgumentException($"Invalid transaction type: {transactionTypeString}");

            using var command3 = new NpgsqlCommand(insertTransactionSql, connection);
            command3.AddParameter("accountNumber", accountUser.AccountNumber);
            command3.AddParameter("type", transactionTypeString);
            command3.AddParameter("sum", transactionItem.Sum);
            command3.ExecuteNonQuery();
        }
    }
}