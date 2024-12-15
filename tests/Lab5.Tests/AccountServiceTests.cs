using Abstraction.Repositories;
using Contracts.ResultTypes;
using DomainModel.Users;
using DomainModel.Users.Transaction;
using NSubstitute;
using Services.AccountServices;
using Xunit;

namespace Lab5.Tests;

public class AccountServiceTests
{
    [Fact]
    public void AccountService_ShouldWithdrawBalance_WhenEnough()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var accountUser = new AccountUser(123, "1234", 1000, new List<TransactionItem>());
        accountRepository.FindUserByAccountNumber(123).Returns(accountUser);

        var currentUserManager = new CurrentUserManager();
        currentUserManager.User = accountUser;

        var accountService = new AccountService(accountRepository, currentUserManager);

        // Act
        accountService.Withdraw(500);

        // Assert
        Assert.Equal(500, accountUser.Balance.Amount);
        accountRepository.Received(1).UpdateAccount(accountUser);
    }

    [Fact]
    public void AccountService_ShouldFailWithdraw_WhenNotEnoughBalance()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var accountUser = new AccountUser(123, "1234", 1000, new List<TransactionItem>());
        accountRepository.FindUserByAccountNumber(123).Returns(accountUser);

        var currentUserManager = new CurrentUserManager();
        currentUserManager.User = accountUser;

        var accountService = new AccountService(accountRepository, currentUserManager);

        // Act
        TransactionExecuteResult result = accountService.Withdraw(20000);

        // Assert
        Assert.IsType<TransactionExecuteResult.Failure>(result);
        accountRepository.Received(0).UpdateAccount(accountUser);
    }

    [Fact]
    public void AccountService_ShouldTopUpBalance()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var accountUser = new AccountUser(123, "1234", 1000, new List<TransactionItem>());
        accountRepository.FindUserByAccountNumber(123).Returns(accountUser);

        var currentUserManager = new CurrentUserManager();
        currentUserManager.User = accountUser;

        var accountService = new AccountService(accountRepository, currentUserManager);

        // Act
        accountService.TopUp(500);

        // Assert
        Assert.Equal(1500, accountUser.Balance.Amount);
        accountRepository.Received(1).UpdateAccount(accountUser);
    }
}