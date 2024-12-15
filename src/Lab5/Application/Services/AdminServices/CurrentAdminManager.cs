using Contracts.Admins;
using DomainModel.Admins;

namespace Services.AdminLogin;

internal class CurrentAdminManager : ICurrentAdminService
{
    public SystemAdmin? Admin { get; set; }
}