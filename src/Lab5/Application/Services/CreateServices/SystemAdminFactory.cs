using Abstraction.Repositories;
using Contracts.Admins;
using Contracts.ResultTypes;
using Contracts.ResultTypes.Errors;
using DomainModel.Admins;

namespace Services.CreateServices;

public class SystemAdminFactory : ICreateAdminService
{
    private readonly IAdminRepository _adminRepository;

    public SystemAdminFactory(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public CreateResults CreateAdmin(string systemPassword)
    {
        if (systemPassword.Length < 9)
            return new CreateResults.Failure(new ShortSystemPasswordError());

        _adminRepository.UpdateSystemAdmin(new SystemAdmin(systemPassword));
        return new CreateResults.Success();
    }
}