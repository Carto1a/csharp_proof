using System.Linq.Expressions;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain;
using ProofIdentity.Domain.Repositories;
using ProofIdentity.Infrastructure.Database.Models;
using ProofIdentity.Infrastructure.Exceptions;
using ProofIdentity.Infrastructure.Mappers;

namespace ProofIdentity.Infrastructure.Database.Repository;
public class BasicUserRepository
: IBasicUserReadRepository, IBasicUserWriteRepository
{
    private readonly DataContext _context;
    private readonly UserManager<BasicUserModel> _manager;

    public BasicUserRepository(
        DataContext context, UserManager<BasicUserModel> manager)
    {
        _manager = manager;
        _context = context;
    }

    public async Task<Guid> CreateAsync(BasicUser user, string password)
    {
        try
        {
            BasicUserModel model = user.ToModel();
            IdentityResult result = await _manager.CreateAsync(model, password);

            if (!result.Succeeded)
            {
                throw new RepositoryException("não foi possivel criar usuario");
            }

            return model.Id;
        }
        catch (Exception error)
        {
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task DeleteAsync(BasicUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<BasicUser?> FindByEmail(string email)
    {
        /* var query = _manager.Users.Select(x => x.ToDomain()); */
        var query = _manager.Users;
        var t = query.ToQueryString();
        var x = await query.FirstOrDefaultAsync(x => x.Email == email);
        return x?.ToDomain();
    }

    public Task<BasicUser?> FindByUsername(string username)
    {
        return _manager.Users.Select(x => x.ToDomain()).FirstOrDefaultAsync(x => x.UserName == username);
    }

    public Task<List<BasicUser>> GetAll()
    {
        var query = _context.Users.Select(x => new BasicUser{
            Id = x.Id,
            UserName = x.UserName,
            NameCompleto = x.NomeCompleto,
            Email = x.Email,
            DataNascimento = x.DataNascimento,
            Cpf = x.Cpf,
            CriadoEm = x.CriadoEm
        });

        var t = query.ToQueryString();
        return query.ToListAsync();
    }

    public Task<BasicUser?> GetById(Guid id)
    {
        return _context.Users
            .Select(x => x.ToDomain())
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public void Update(BasicUser user)
    {
        throw new NotImplementedException();
    }
}