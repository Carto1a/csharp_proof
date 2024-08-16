namespace CancellationTokenProof.Server;
public class Score
{
    public int Id { get; set; }
    public int Limit { get; set; }
    public int Count { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedAt { get; set; }

    private Score() { }

    public Score(int limit, int count)
    {
        Limit = limit;
        Count = count;
        CreatedAt = DateTime.Now;
    }

    public bool IsHighScore(Score score)
    {
        return Value > score.Value;
    }
}
