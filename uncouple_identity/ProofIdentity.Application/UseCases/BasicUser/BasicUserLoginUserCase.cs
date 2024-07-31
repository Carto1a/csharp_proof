using ProofIdentity.Application.DTOs;
using ProofIdentity.Application.Excetions;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Application.Services;

namespace ProofIdentity.Application.UseCases.BasicUser;
public class BasicUserLoginUseCase
{
    private readonly IAuthenService _authService;
    private readonly IBasicUserReadRepository _repository;
    private readonly ILoginService _loginService;

    public BasicUserLoginUseCase(IAuthenService service, IBasicUserReadRepository repository, ILoginService loginService)
    {
        _authService = service;
        _repository = repository;
        _loginService = loginService;
    }

    public async Task<string> Handler(LoginBasicUserDto request)
    {
        var user = await _repository.FindByEmail(request.Email);
        if (user == null)
            throw new ApplicationLayerException(
                "Não foi possivel fazer o login");

        var isValidPassword = await _loginService
            .CheckPasswordAsync(user, request.Password);
        if (isValidPassword)
            throw new ApplicationLayerException(
                "Não foi possivel fazer o login");

        var auth = await _authService.Authenticate(user);
        return auth;
    }
}