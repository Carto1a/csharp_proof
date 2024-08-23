using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ProofIdentity.Application.DTOs;
using ProofIdentity.Application.Repositories;
using ProofIdentity.Domain;
using ProofIdentity.Domain.Repositories;
using ProofIdentity.Infrastructure.Exceptions;

namespace ProofIdentity.Infrastructure.Database.Repositories;
public class AdminRepository : IAdminWriteRepository, IAdminReadRepository
{
    private readonly DataContext _context;
    private readonly UserManager<Pessoa> _manager;
    private readonly ILoginRepository _loginRepository;
    public AdminRepository(DataContext context, UserManager<Pessoa> manager, ILoginRepository loginRepository)
    {
        _context = context;
        _manager = manager;
        _loginRepository = loginRepository;
    }

    public async Task<Guid> CreateAsync(Admin admin, string password)
    {
        var result = await _manager.CreateAsync(admin, password);
        if (!result.Succeeded)
        {
            throw new RepositoryException(result.Errors);
        }

        result = await _manager.AddToRoleAsync(admin, Roles.Administrador.ToString());
        if (!result.Succeeded)
        {
            throw new RepositoryException(result.Errors);
        }

        return admin.Id;
    }

    public async Task<IEnumerable<AdminDto>> GetAllDto()
    {
        try
        {
            var query = _context.Admins
                .AsNoTracking()
                .Select(x => new AdminDto()
                {
                    Id = x.Id,
                    Nome = x.NomeCompleto,
                    Cpf = x.CPF
                });

            var querySql = query.ToQueryString();
            var adminList = await query.ToListAsync();

            return adminList;
        }
        catch (Exception error)
        {
            throw new RepositoryInternalException(error.Message);
        }
    }

    public async Task<Admin?> GetByCpf(string cpf)
    {
        try
        {
            var query = _context.Admins
                .AsNoTracking()
                .Where(x => x.CPF == cpf)
                .Select(x => new Admin()
                {
                    Id = x.Id,
                    Info = x.Info,
                    NomeCompleto = x.NomeCompleto,
                    CPF = x.CPF,
                    SecurityStamp = Guid.NewGuid(),
                    PasswordHash = x.PasswordHash
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

    public async Task<AdminDto?> GetByCpfDto(string cpf)
    {
        try
        {
            var query = _context.Admins
                .AsNoTracking()
                .Where(x => x.CPF == cpf)
                .Select(x => new AdminDto()
                {
                    Id = x.Id,
                    Nome = x.NomeCompleto,
                    Cpf = x.CPF
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