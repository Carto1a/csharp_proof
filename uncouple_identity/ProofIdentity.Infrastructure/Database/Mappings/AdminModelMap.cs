using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProofIdentity.Domain;

namespace ProofIdentity.Infrastructure.Mappings;
public class AdminModelMap : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
    }
}