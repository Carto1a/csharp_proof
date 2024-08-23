using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProofIdentity.Domain;
using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Database.Mappings;
public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
{
    public void Configure(EntityTypeBuilder<Agendamento> builder)
    {
        /* builder.Property<AdminModel>("AdminId"); */

        /* builder.Ignore(a => a.Admin); */
        /* builder.HasOne<AdminModel>().WithMany().HasForeignKey("AdminId"); */
    }
}