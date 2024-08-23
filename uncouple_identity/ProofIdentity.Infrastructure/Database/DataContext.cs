using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ProofIdentity.Domain;
using ProofIdentity.Infrastructure.Database.Models;

namespace ProofIdentity.Infrastructure.Database;
public class DataContext
: IdentityDbContext<PessoaModel, IdentityRole<Guid>, Guid>
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Admin>();
        builder.Ignore<Medico>();
        builder.Ignore<Paciente>();
        builder.Ignore<Pessoa>();

        builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}