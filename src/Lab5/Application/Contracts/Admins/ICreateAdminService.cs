using Contracts.ResultTypes;

namespace Contracts.Admins;

public interface ICreateAdminService
{
    CreateResults CreateAdmin();
}