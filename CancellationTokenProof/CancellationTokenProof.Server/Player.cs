namespace CancellationTokenProof.Server;
public class Player
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Score? HighScore { get; set; }
    public Score? LastScore { get; set; }
    public List<Score> Scores { get; set; } = new();

    public DateTime CreatedAt { get; set; }

    private Player() { }

    public Player(string name)
    {
        Name = name;
        CreatedAt = DateTime.Now;
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Name is required");
        }

        if (Name.Length < 6)
        {
            throw new ArgumentException("Name must be at least 6 characters long");
        }

        if (Name.Length > 6)
        {
            throw new ArgumentException("Name must be at most 6 characters long");
        }
    }

    public void AddScore(int limit, int count)
    {
        var score = new Score(limit, count);
        if (HighScore is null)
        {
            HighScore = score;
        }
        else if (score.IsHighScore(HighScore))
        {
            HighScore = score;
        }

        LastScore = score;
        Scores.Add(score);
    }
}
