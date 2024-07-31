using ProofIdentity.Application.UseCases.BasicUser;

namespace ProofIdentity.WebApi.Injections;
public static class UseCasesInjection
{
    public static IServiceCollection RegisterUseCases(
        this IServiceCollection services)
    {
        return services
            .AddScoped<BasicUserRegisterUseCase>()
            .AddScoped<BasicUserLoginUseCase>()
            ;
    }
}