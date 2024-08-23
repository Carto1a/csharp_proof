using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain;
using ProofIdentity.Infrastructure.Exceptions;

namespace ProofIdentity.Infrastructure.Database.Repositories;
public class LoginRepository : ILoginRepository
{
    private readonly DataContext _context;
    private readonly UserManager<ILoginUser> _manager;
    public LoginRepository(DataContext context, UserManager<ILoginUser> manager)
    {
        _context = context;
        _manager = manager;
    }

    public async Task AddToRoleAsync(Pessoa user, Roles role)
    {
        try
        {
            var result = await _manager.AddToRoleAsync(user, role.ToString());
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
        return _manager.CheckPasswordAsync(user, password);
    }

    public Task<bool> LoginExistAsync(Pessoa user)
    {
        return _context.Users.AnyAsync(x => x.CPF == user.CPF);
    }
}