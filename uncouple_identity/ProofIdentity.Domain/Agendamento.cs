namespace ProofIdentity.Domain;
public class Agendamento : Entity
{
    public DateTime DataAgendamento { get; set; }
    public string Data { get; set; }

    public Guid AdminId { get; set; }

    private Agendamento() { }
    public Agendamento(DateTime dataAgendamento, string data, Admin admin)
    {
        DataAgendamento = dataAgendamento;
        Data = data;
        AdminId = admin.Id;
    }
}