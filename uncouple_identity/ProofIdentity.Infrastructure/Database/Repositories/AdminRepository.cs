using Microsoft.AspNetCore.Identity;

using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain;
using ProofIdentity.Domain.Repositories;
using ProofIdentity.Infrastructure.Database.Models;
using ProofIdentity.Infrastructure.Exceptions;
using ProofIdentity.Infrastructure.Mappers;

namespace ProofIdentity.Infrastructure.Database.Repository;
public class AdminRepository : IAdminWriteRepository, IAdminReadRepository
{
    private readonly DataContext _context;
    private readonly UserManager<PessoaModel> _manager;
    public AdminRepository(DataContext context, UserManager<PessoaModel> manager)
    {
        _context = context;
        _manager = manager;
    }

    public async Task<Guid> CreateAsync(Admin admin, string password)
    {
        try
        {
            var model = admin.ToModel();
            var result = await _manager.CreateAsync(model, password);
            if (!result.Succeeded)
            {
                throw new RepositoryException(result.Errors);
            }

            return admin.Id;
        }
        catch (Exception error)
        {
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task<Admin> GetByCpf(string cpf)
    {
        throw new NotImplementedException();
    }

    public Task<Admin> GetByPessoaId(Guid pessoaId)
    {
        throw new NotImplementedException();
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