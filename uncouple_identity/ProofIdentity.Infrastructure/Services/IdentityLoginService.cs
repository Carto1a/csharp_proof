using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Application.Services;
using ProofIdentity.Domain;
using ProofIdentity.Domain.Repositories;
using ProofIdentity.Infrastructure.Database;
using ProofIdentity.Infrastructure.Database.Models;
using ProofIdentity.Infrastructure.Mappers;

namespace ProofIdentity.Infrastructure.Services;
public class IdentityLoginService : ILoginService
{
    private readonly IBasicUserWriteRepository _repositoryWrite;
    private readonly IBasicUserReadRepository _repositoryRead;
    private readonly IAdminWriteRepository _adminWriteRepository;
    private readonly UserManager<BasicUserModel> _manager;
    private readonly UserManager<Pessoa> _userManager;
    private readonly DataContext _context;

    public IdentityLoginService(IBasicUserWriteRepository repositoryWrite, IBasicUserReadRepository repositoryRead, UserManager<BasicUserModel> manager, DataContext context, IAdminWriteRepository adminWriteRepository, UserManager<Pessoa> userManager)
    {
        _repositoryWrite = repositoryWrite;
        _repositoryRead = repositoryRead;
        _manager = manager;
        _context = context;
        _adminWriteRepository = adminWriteRepository;
        _userManager = userManager;
    }

    public Task<bool> CheckIfLoginExistAsync(BasicUser user)
    {
        return _context.Users.AnyAsync(
            x => x.UserName == user.UserName
              || x.Email == user.Email);
    }

    public Task<bool> CheckIfLoginExistAsync(Pessoa user)
    {
        return _context.Users.AnyAsync(
            x => x.UserName == user.CPF);
    }

    public Task<bool> CheckIfLoginExistAsync(Admin user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckIfLoginExistAsync(Paciente user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckIfLoginExistAsync(Medico user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckPasswordAsync(BasicUser user, string password)
    {
        return _manager.CheckPasswordAsync(user.ToModel(), password);
    }

    public Task<bool> CheckPasswordAsync(Pessoa user, string password)
    {
        return _userManager.CheckPasswordAsync(user.ToModel(), password);
    }

    public Task<Guid> Register(BasicUser user, string password)
    {
        return _repositoryWrite.CreateAsync(user, password);
    }

    public Task<Guid> Register(Paciente user, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> Register(Admin user, string password)
    {
        _ = await _userManager.CreateAsync(user.Pessoa, password);
        return _adminWriteRepository.CreateAsync(user);
    }

    public Task<Guid> Register(Medico user, string password)
    {
        throw new NotImplementedException();
    }
}