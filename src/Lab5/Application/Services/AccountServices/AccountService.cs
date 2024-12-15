using Abstraction.Repositories;
using Contracts.ResultTypes;
using Contracts.ResultTypes.Errors;
using Contracts.Users;
using DomainModel.Users;
using DomainModel.Users.ResultTypes;

namespace Services.AccountServices;

internal class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public AccountService(IAccountRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public UserLoginResult Login(long accountNumber, string pinCode)
    {
        AccountUser? user = _repository.FindUserByAccountNumber(accountNumber);

        if (user is null)
            return new UserLoginResult.Failure(new NotFoundError());

        if (!user.PinCode.Login(pinCode))
            return new UserLoginResult.Failure(new IncorrectPinCodeError());

        _currentUserManager.User = user;

        return new UserLoginResult.Success();
    }

    public GetBalanceResult GetBalance()
    {
        if (_currentUserManager.User is null)
            return new GetBalanceResult.Failure(new NotAuthorized());

        return new GetBalanceResult.Success(_currentUserManager.User.Balance.Amount);
    }

    public TransactionExecuteResult TopUp(double amount)
    {
        if (_currentUserManager.User is null)
            return new TransactionExecuteResult.Failure(new NotAuthorized());

        _currentUserManager.User.TopUp(amount);
        _repository.UpdateAccount(_currentUserManager.User);
        return new TransactionExecuteResult.Success();
    }

    public TransactionExecuteResult Withdraw(double amount)
    {
        if (_currentUserManager.User is null)
            return new TransactionExecuteResult.Failure(new NotAuthorized());

        WithdrawResult result = _currentUserManager.User.Withdraw(amount);

        if (result is WithdrawResult.NotEnoughMoney)
            return new TransactionExecuteResult.Failure(new NotEnoughMoneyError());

        _repository.UpdateAccount(_currentUserManager.User);
        return new TransactionExecuteResult.Success();
    }

    public GetHistoryResult GetHistory()
    {
        if (_currentUserManager.User is null)
            return new GetHistoryResult.Failure(new NotAuthorized());

        return new GetHistoryResult.Success(_currentUserManager.
            User.
            Transactions.
            Select(t => $"{t.Type}: {t.Sum}").ToList().AsReadOnly());
    }
}