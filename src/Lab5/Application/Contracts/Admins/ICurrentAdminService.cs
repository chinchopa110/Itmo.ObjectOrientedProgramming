using DomainModel.Admins;

namespace Contracts.Admins;

public interface ICurrentAdminService
{
    SystemAdmin? Admin { get; }
}