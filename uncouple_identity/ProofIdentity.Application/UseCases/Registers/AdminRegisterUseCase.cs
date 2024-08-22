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
    private readonly IUnitOfWork _unitOfWork;

    public AdminRegisterUseCase(ILoginRepository loginRepository, IAdminWriteRepository adminRepository, IUnitOfWork unitOfWork)
    {
        _loginRepository = loginRepository;
        _adminRepository = adminRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handler(AdminRegisterDto request)
    {
        var loginExists = await _loginRepository.LoginExistAsync(request.ToCheckLogin());
        if (loginExists)
            throw new ApplicationLayerException("Não foi posivel criar o usuario");

        Guid id;
        Admin admin = new(request.Info, request.NomeCompleto, request.CPF);

        try
        {
            await _unitOfWork.BeginTransactionAsync();

            id = await _adminRepository.CreateAsync(admin, request.Senha);

            await _unitOfWork.CommitAsync();
        }
        catch (Exception error)
        {
            await _unitOfWork.RollbackAsync();
            throw new ApplicationLayerException("Não foi posivel criar o usuario", error);
        }

        return id;
    }
}