using ProofIdentity.Application.DTOs.Registers;
using ProofIdentity.Application.Excetions;
using ProofIdentity.Application.Mapper;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain;
using ProofIdentity.Domain.Repositories;

namespace ProofIdentity.Application.UseCases.Registers;
public class AdminRegisterUseCase
{
    private readonly ILoginRepository _loginRepository;
    private readonly IAdminWriteRepository _adminRepository;

    public AdminRegisterUseCase(ILoginRepository loginRepository, IAdminWriteRepository adminRepository)
    {
        _loginRepository = loginRepository;
        _adminRepository = adminRepository;
    }

    public async Task<Guid> Handler(AdminRegisterDto request)
    {
        var loginExists = await _loginRepository.LoginExistAsync(request.ToCheckLogin());
        if (!loginExists)
            throw new ApplicationLayerException("Não foi posivel criar o usuario");

        var admin = new Admin(request.Info, request.NomeCompleto, request.CPF);
        var id = await _adminRepository.CreateAsync(admin, request.Senha);

        return id;
    }
}