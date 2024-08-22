using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain;
using ProofIdentity.Infrastructure.Database.Models;
using ProofIdentity.Infrastructure.Exceptions;
using ProofIdentity.Infrastructure.Mappers;

namespace ProofIdentity.Infrastructure.Database.Repository;
public class LoginRepository : ILoginRepository
{
    private readonly DataContext _context;
    private readonly UserManager<PessoaModel> _manager;
    public LoginRepository(DataContext context, UserManager<PessoaModel> manager)
    {
        _context = context;
        _manager = manager;
    }

    public async Task AddToRoleAsync(Pessoa user, Roles role)
    {
        try
        {
            var model = user.ToLoginModel();
            var result = await _manager.AddToRoleAsync(model, role.ToString());
            if (!result.Succeeded)
            {
                throw new RepositoryException(result.Errors);
            }

            return;
        }
        catch (Exception error)
        {
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task<bool> IsPasswordCorrectAsync(Pessoa user, string password)
    {
        var model = user.ToLoginModel();
        return _manager.CheckPasswordAsync(model, password);
    }

    public Task<bool> LoginExistAsync(Pessoa user)
    {
        return _context.Users.AnyAsync(x => x.CPF == user.CPF);
    }
}