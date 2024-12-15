using Contracts.Users;
using DomainModel.Users;

namespace Services.AccountServices;

internal class CurrentUserManager : ICurrentUserService
{
    public AccountUser? User { get; set; }
}