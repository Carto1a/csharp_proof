namespace ProofIdentity.Application.DTOs.Registers;
public record AdminRegisterDto : PessoaRegisterDto
{
    public string Info { get; init; }

    protected AdminRegisterDto(PessoaRegisterDto original, string info)
    : base(original)
    {
        Info = info;
    }
}
