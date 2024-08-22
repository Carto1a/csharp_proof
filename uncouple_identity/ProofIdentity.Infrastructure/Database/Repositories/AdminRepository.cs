using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        PessoaModel pessoaModel = admin.ToLoginModel();
        var result = await _manager.CreateAsync(pessoaModel, password);
        if (!result.Succeeded)
        {
            throw new RepositoryException(result.Errors);
        }

        AdminModel adminModel = admin.ToModel();
        _ = await _context.Admins.AddAsync(adminModel);

        result = await _manager.AddToRoleAsync(pessoaModel, Roles.Administrador.ToString());
        if (!result.Succeeded)
        {
            throw new RepositoryException(result.Errors);
        }

        return pessoaModel.Id;
    }

    public async Task<Admin?> GetByCpf(string cpf)
    {
        try
        {
            var query = _context.Admins
                .AsNoTracking()
                .Include(x => x.Pessoa)
                .Where(x => x.Pessoa.CPF == cpf)
                .Select(x => new Admin()
                {
                    Id = x.Id,
                    Info = x.Info,
                    NomeCompleto = x.Pessoa.NomeCompleto,
                    CPF = x.Pessoa.CPF,
                    SecurityStamp = Guid.Parse(x.Pessoa.SecurityStamp),
                    PasswordHash = x.Pessoa.PasswordHash
                });

            var querySql = query.ToQueryString();
            var admin = await query.FirstOrDefaultAsync();

            return admin;
        }
        catch (Exception error)
        {
            throw new RepositoryInternalException(error.Message);
        }
    }

    public Task<Admin?> GetByPessoaId(Guid pessoaId)
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