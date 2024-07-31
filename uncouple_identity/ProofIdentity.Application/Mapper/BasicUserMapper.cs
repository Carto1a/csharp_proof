using ProofIdentity.Application.DTOs;
using ProofIdentity.Domain;

namespace ProofIdentity.Application.Mapper;
public static class BasicUserMapper
{
    public static BasicUser ToDomain(this RegisterBasicUserDto dto)
    {
        return new BasicUser(
            dto.UserName,
            dto.NameCompleto,
            dto.Email,
            DateOnly.FromDateTime(dto.DateNascimento),
            dto.Cpf);
    }

    public static BasicUser ToCheck(this RegisterBasicUserDto dto)
    {
        return new BasicUser()
        {
            UserName = dto.UserName,
            Email = dto.Email,
            Cpf = dto.Cpf
        };
    }
}