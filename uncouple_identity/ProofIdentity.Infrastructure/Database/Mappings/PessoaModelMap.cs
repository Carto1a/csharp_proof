using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Database.Mappings;
public class PessoaModelMap : IEntityTypeConfiguration<PessoaModel>
{
    public void Configure(EntityTypeBuilder<PessoaModel> builder)
    {
        builder.HasKey(x => x.CPF);
    }
}
