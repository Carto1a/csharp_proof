namespace ProofIdentity.Infrastructure.Database.Models;
public interface IEntityModel
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }
}