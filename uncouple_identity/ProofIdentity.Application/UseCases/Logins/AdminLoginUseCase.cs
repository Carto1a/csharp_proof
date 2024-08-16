using ProofIdentity.Application.DTOs.Logins;
using ProofIdentity.Application.Excetions;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Application.Services;

namespace ProofIdentity.Application.UseCases.Logins;
public class AdminLoginUseCase
{
    private readonly IAdminReadRepository _readRepository;
    private readonly ILoginService _loginService;
    private readonly IAuthenService _authService;

    public AdminLoginUseCase(IAdminReadRepository readRepository, IAuthenService authService, ILoginService loginService)
    {
        _readRepository = readRepository;
        _authService = authService;
        _loginService = loginService;
    }

    public async Task<string> Handler(LoginDto request)
    {
        var admin = await _readRepository.GetByCpf(request.CPF);
        if (admin == null)
            throw new ApplicationLayerException("CPF ou senha errado");

        var isValidPassword = await _loginService.CheckPasswordAsync(admin, request.Senha);
        if (isValidPassword)
            throw new ApplicationLayerException("CPF ou senha errado");

        var authString = await _authService.Authenticate(admin);
        return authString;
    }
}