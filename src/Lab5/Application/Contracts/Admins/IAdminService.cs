using Contracts.ResultTypes;

namespace Contracts.Admins;

public interface IAdminService
{
    AdminLoginResults Login(string systemPassword);
}