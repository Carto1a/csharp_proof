using Microsoft.EntityFrameworkCore;

using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain.Repositories;
using ProofIdentity.Infrastructure.Database;
using ProofIdentity.Infrastructure.Database.Repositories;

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
                    b => b.MigrationsAssembly("ProofIdentity.Infrastructure")))

            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IAdminReadRepository, AdminRepository>()
            .AddScoped<IAdminWriteRepository, AdminRepository>()
            .AddScoped<ILoginRepository, LoginRepository>()
            .AddScoped<IAgendamentoReadRepository, AgendamentoRepository>()
            .AddScoped<IAgendamentoWriteRepository, AgendamentoRepository>()
            ;
    }
}