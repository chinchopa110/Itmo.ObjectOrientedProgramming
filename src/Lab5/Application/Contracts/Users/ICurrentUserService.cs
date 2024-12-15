using DomainModel.Users;

namespace Contracts.Users;

public interface ICurrentUserService
{
    AccountUser? User { get; }
}