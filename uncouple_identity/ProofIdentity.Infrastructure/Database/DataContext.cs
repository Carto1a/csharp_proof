using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Database;
public class DataContext
: IdentityDbContext<BasicUserModel, IdentityRole<Guid>, Guid>
{
    public DataContext(DbContextOptions<DataContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}