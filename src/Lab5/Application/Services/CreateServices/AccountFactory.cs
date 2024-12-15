using Abstraction.Repositories;
using Contracts.ResultTypes;
using Contracts.ResultTypes.Errors;
using Contracts.Users;
using DomainModel.Users;
using DomainModel.Users.Transaction;

namespace Services.CreateServices;

public class AccountFactory : ICreateAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountFactory(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public CreateResults CreateAccount(long accountNumber, string pinCode)
    {
        if (pinCode.Length != 4)
            return new CreateResults.Failure(new IncorrectPinCodeError());

        _accountRepository.
            AddAccount(
            new AccountUser(
                accountNumber,
                pinCode,
                0,
                new List<TransactionItem>()));

        return new CreateResults.Success();
    }
}