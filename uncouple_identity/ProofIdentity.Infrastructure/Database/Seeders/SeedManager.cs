using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProofIdentity.Application.DTOs.Registers;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Application.UseCases.Registers;
using ProofIdentity.Domain;

namespace ProofIdentity.Infrastructure.Database.Seeders;
public class SeedManager
{
    public static async Task Seed(IServiceProvider provider)
    {
        await SeedRoles(provider);
        await SeedAdmin(provider);
    }

    private static async Task SeedRoles(IServiceProvider provider)
    {
        var roleManager = provider.GetService<RoleManager<IdentityRole<Guid>>>();
        _ = await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Administrador.ToString()));
        _ = await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Paciente.ToString()));
        _ = await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Medico.ToString()));
    }

    private static async Task SeedAdmin(IServiceProvider provider)
    {
        var service = provider.GetService<AdminRegisterUseCase>();
        var loginRepository = provider.GetService<ILoginRepository>();

        string cpf = "00000000001";

        var pessoaToCheck = new Pessoa("Carlos", cpf);
        var loginExists = await loginRepository.LoginExistAsync(pessoaToCheck);
        if (loginExists)
            return;

        AdminRegisterDto request = new()
        {
            NomeCompleto = "Carlos",
            CPF = cpf,
            Senha = "abc123CARLOS@",
            Info = "info"
        };

        _ = await service.Handler(request!);
    }
}