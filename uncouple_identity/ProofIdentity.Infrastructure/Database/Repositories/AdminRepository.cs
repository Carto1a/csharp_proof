using ProofIdentity.Domain;
using ProofIdentity.Domain.Repositories;
using ProofIdentity.Infrastructure.Exceptions;

namespace ProofIdentity.Infrastructure.Database.Repository;
public class AdminRepository : IAdminWriteRepository
{
    private readonly DataContext _context;
    public AdminRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Admin admin)
    {
        try
        {
            _ = await _context.AddAsync(admin);
            return admin.Id;
        }
        catch (Exception error)
        {
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task RemoveAsync(Admin admin)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Admin admin)
    {
        throw new NotImplementedException();
    }
}
