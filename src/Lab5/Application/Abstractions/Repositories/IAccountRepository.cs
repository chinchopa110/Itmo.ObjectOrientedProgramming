using DomainModel.Users;

namespace Abstraction.Repositories;

public interface IAccountRepository
{
    AccountUser? FindUserByAccountNumber(long accountNumber);

    void AddAccount(AccountUser accountUser);

    void UpdateAccount(AccountUser accountUser);
}