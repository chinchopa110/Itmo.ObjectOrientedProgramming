using Contracts.Admins;
using Contracts.Users;
using Microsoft.Extensions.DependencyInjection;
using Services.AccountServices;
using Services.AdminLogin;
using Services.AdminServices;
using Services.CreateServices;

namespace Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<ICreateAdminService, SystemAdminFactory>();
        collection.AddScoped<CurrentAdminManager>();
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdminManager>());

        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<ICreateAccountService, AccountFactory>();
        collection.AddScoped<CurrentUserManager>();
        collection.AddScoped<ICurrentUserService>(
            p => p.GetRequiredService<CurrentUserManager>());
        return collection;
    }
}