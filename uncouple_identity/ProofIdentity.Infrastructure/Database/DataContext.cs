using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Database;
public class DataContext
: IdentityDbContext<PessoaModel, IdentityRole<Guid>, Guid>
{
    public DbSet<PacienteModel> Pacientes { get; set; }
    public DbSet<AdminModel> Admins { get; set; }
    public DbSet<MedicoModel> Medicos { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}