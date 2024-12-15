using Contracts.ResultTypes;

namespace Contracts.Users;

public interface IAccountService
{
    UserLoginResult Login(long accountNumber, string pinCode);

    GetBalanceResult GetBalance();

    TransactionExecuteResult TopUp(double amount);

    TransactionExecuteResult Withdraw(double amount);

    GetHistoryResult GetHistory();
}