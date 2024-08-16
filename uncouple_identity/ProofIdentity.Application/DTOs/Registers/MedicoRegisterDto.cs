namespace ProofIdentity.Application.DTOs.Registers;
public record MedicoRegisterDto : PessoaRegisterDto
{
    protected MedicoRegisterDto(PessoaRegisterDto original)
    : base(original)
    {
    }
}