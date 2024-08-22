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
    private readonly ILoginRepository _loginRepository;
    public AdminRepository(DataContext context, UserManager<PessoaModel> manager, ILoginRepository loginRepository)
    {
        _context = context;
        _manager = manager;
        _loginRepository = loginRepository;
    }

    public async Task<Guid> CreateAsync(Admin admin, string password)
    {
        var pessoaModel = admin.ToModel();
        var result = await _manager.CreateAsync(pessoaModel, password);
        if (!result.Succeeded)
        {
            throw new RepositoryException(result.Errors);
        }

        result = await _manager.AddToRoleAsync(pessoaModel, Roles.Administrador.ToString());
        if (!result.Succeeded)
        {
            throw new RepositoryException(result.Errors);
        }

        return pessoaModel.Id;
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