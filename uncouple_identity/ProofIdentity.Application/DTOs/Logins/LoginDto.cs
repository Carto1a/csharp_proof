using ProofIdentity.Domain;

namespace ProofIdentity.Application.DTOs.Logins;
public record LoginDto(string CPF, string Senha, Roles Role);