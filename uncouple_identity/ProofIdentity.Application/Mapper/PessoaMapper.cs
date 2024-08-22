using ProofIdentity.Application.DTOs.Registers;
using ProofIdentity.Domain;

namespace ProofIdentity.Application.Mapper;

public static class PessoaMapper
{
    public static Pessoa ToCheckLogin(this PessoaRegisterDto dto)
    {
        return new Pessoa(dto.NomeCompleto, dto.CPF);
    }
}