using DomainModel.Admins;

namespace Abstraction.Repositories;

public interface IAdminRepository
{
    SystemAdmin? GetSystemAdminByPassword(string password);

    void UpdateSystemAdmin(SystemAdmin systemAdmin);
}