using ProofIdentity.Application.DTOs.Registers;
using ProofIdentity.Application.Excetions;
using ProofIdentity.Application.Mapper;
using ProofIdentity.Application.Services;
using ProofIdentity.Domain;

namespace ProofIdentity.Application.UseCases.Registers;
public class AdminRegisterUseCase
{
    private readonly ILoginService _loginService;

    public AdminRegisterUseCase(
        ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async Task<Guid> Handler(AdminRegisterDto request)
    {
        var loginExists = await _loginService.CheckIfLoginExistAsync(request.ToCheckLogin());
        if (!loginExists)
            throw new ApplicationLayerException("Não foi posivel criar o usuario");

        var admin = new Admin(request.Info, request.NomeCompleto, request.CPF);
        var id = await _loginService.Register(admin, request.Senha);

        return id;
    }
}