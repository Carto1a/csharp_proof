using ProofIdentity.Application.DTOs;
using ProofIdentity.Application.Excetions;
using ProofIdentity.Application.Mapper;
using ProofIdentity.Application.Services;

namespace ProofIdentity.Application.UseCases.BasicUser;
public class BasicUserRegisterUseCase
{
    private readonly ILoginService _loginService;

    public BasicUserRegisterUseCase(
        ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async Task<Guid> Handler(RegisterBasicUserDto request)
    {
        bool findUser = await _loginService
            .CheckIfLoginExistAsync(request.ToCheck());
        if (findUser)
        {
            throw new ApplicationLayerException(
                "Não foi posivel criar o usuario");
        }

        Guid id = await _loginService.Register(request.ToDomain(), request.Password);

        return id;
    }
}