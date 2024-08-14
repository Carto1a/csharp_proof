namespace ProofIdentity.Domain;
public class Entity
{
    public Guid Id { get; set; }
    public DateTime CriadoEm { get; set; }

    public Entity()
    {
        CriadoEm = DateTime.Now;
    }
}