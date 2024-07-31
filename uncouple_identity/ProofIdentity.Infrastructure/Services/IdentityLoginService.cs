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
    private readonly UserManager<BasicUserModel> _manager;
    private readonly DataContext _context;

    public IdentityLoginService(IBasicUserWriteRepository repositoryWrite, IBasicUserReadRepository repositoryRead, UserManager<BasicUserModel> manager, DataContext context)
    {
        _repositoryWrite = repositoryWrite;
        _repositoryRead = repositoryRead;
        _manager = manager;
        _context = context;
    }

    public Task<bool> CheckIfLoginExistAsync(BasicUser user)
    {
        return _context.Users.AnyAsync(
            x => x.UserName == user.UserName
              || x.Email == user.Email);
    }

    public Task<bool> CheckPasswordAsync(BasicUser user, string password)
    {
        return _manager.CheckPasswordAsync(user.ToModel(), password);
    }

    public Task<Guid> Register(BasicUser user, string password)
    {
        return _repositoryWrite.CreateAsync(user, password);
    }
}
