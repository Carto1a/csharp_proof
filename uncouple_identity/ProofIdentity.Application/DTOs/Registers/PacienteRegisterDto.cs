namespace ProofIdentity.Application.DTOs.Registers;
public record PacienteRegisterDto : PessoaRegisterDto
{
    protected PacienteRegisterDto(PessoaRegisterDto original)
    : base(original)
    {

    }
}