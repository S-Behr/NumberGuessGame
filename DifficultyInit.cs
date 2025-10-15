namespace AzubiDemo;

public class DifficultyInit
{
    private Difficulty easy = new Difficulty
    {
        Name = "Easy",
        Description = "Perfect for beginners",
        Tries = 20
    };
    private Difficulty normal = new Difficulty
    {
        Name = "Normal",
        Description = "The normal difficulty",
        Tries = 10
    };
    private Difficulty hard = new Difficulty
    {
        Name = "Hard",
        Description = "its difficult ;)",
        Tries = 5
    };
    private Difficulty ultra= new Difficulty
    {
        Name = "Ultra",
        Description = "Perfect for experts",
        Tries = 3
    };

    public List<Difficulty> Difficulties { get; init; } = new();

    public DifficultyInit()
    {
        Difficulties.Add(easy);
        Difficulties.Add(normal);
        Difficulties.Add(hard);
        Difficulties.Add(ultra);
    }
}