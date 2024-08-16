using Microsoft.EntityFrameworkCore;

namespace CancellationTokenProof.Server;
public class DataContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Score> Scores { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasMany(p => p.Scores).WithOne().OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Player>().Property(p => p.Name)
            .IsRequired()
            .IsFixedLength(true)
            .HasMaxLength(6);
    }
}
