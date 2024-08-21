using Microsoft.AspNetCore.Identity;
using ProofIdentity.Infrastructure.Database;
using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.WebApi.Injections;
public static class IdentityInjection
{
    public static IServiceCollection RegisterIdentity(
        this IServiceCollection services)
    {
        services.AddIdentityCore<PessoaModel>()
            .AddRoles<IdentityRole<Guid>>()
            .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}