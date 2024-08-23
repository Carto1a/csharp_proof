using ProofIdentity.Application.DTOs;
using ProofIdentity.Domain;

namespace ProofIdentity.Application.Repositories;
public interface IAdminReadRepository
{
    Task<Admin?> GetByPessoaId(Guid pessoaId);
    Task<Admin?> GetByCpf(string cpf);
    Task<AdminDto?> GetByCpfDto(string cpf);
    Task<IEnumerable<AdminDto>> GetAllDto();
}