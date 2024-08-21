using ProofIdentity.Application.UseCases.Logins;
using ProofIdentity.Application.UseCases.Registers;

namespace ProofIdentity.WebApi.Injections;
public static class UseCasesInjection
{
    public static IServiceCollection RegisterUseCases(
        this IServiceCollection services)
    {
        return services
            .AddScoped<AdminRegisterUseCase>()
            .AddScoped<AdminLoginUseCase>()
            ;
    }
}