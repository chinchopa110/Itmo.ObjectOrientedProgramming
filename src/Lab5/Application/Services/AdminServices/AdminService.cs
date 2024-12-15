using Abstraction.Repositories;
using Contracts.Admins;
using Contracts.ResultTypes;
using DomainModel.Admins;
using Services.AdminLogin;

namespace Services.AdminServices;

internal class AdminService : IAdminService
{
    private readonly CurrentAdminManager _currentAdminService;
    private readonly IAdminRepository _adminRepository;

    public AdminService(CurrentAdminManager currentAdminService, IAdminRepository adminRepository)
    {
        _currentAdminService = currentAdminService;
        _adminRepository = adminRepository;
    }

    public AdminLoginResults Login(string systemPassword)
    {
        SystemAdmin? admin = _adminRepository.GetSystemAdminByPassword(systemPassword);

        if (admin is null)
            Environment.Exit(1);

        _currentAdminService.Admin = admin;
        return new AdminLoginResults.Success();
    }
}