using Contracts.ResultTypes;

namespace Contracts.Users;

public interface ICreateAccountService
{
    CreateResults CreateAccount(long accountNumber, string pinCode);
}