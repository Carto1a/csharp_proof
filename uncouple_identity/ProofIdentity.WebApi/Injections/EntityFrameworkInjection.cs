using Microsoft.EntityFrameworkCore;

using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain.Repositories;
using ProofIdentity.Infrastructure.Database;
using ProofIdentity.Infrastructure.Database.Repository;

namespace ProofIdentity.WebApi.Injections;
public static class EntityFrameworkInjection
{
    public static IServiceCollection RegisterEF(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddDbContext<DataContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DbSqlServer"),
                b => b.MigrationsAssembly("ProofIdentity.WebApi")))

            .AddScoped<IBasicUserReadRepository, BasicUserRepository>()
            .AddScoped<IBasicUserWriteRepository, BasicUserRepository>()
            ;
    }
}