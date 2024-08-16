using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Mappings;
public class AdminModelMap : IEntityTypeConfiguration<AdminModel>
{
    public void Configure(EntityTypeBuilder<AdminModel> builder)
    {
    }
}