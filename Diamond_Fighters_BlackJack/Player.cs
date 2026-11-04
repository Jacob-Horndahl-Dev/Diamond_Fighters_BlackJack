public class Player
{
    public string Name { get; }
    public int Balance { get; private set; } = 100;
    public int RoundsPlayed { get; private set; } = 0;
    public int Bet { get; private set; }
    public Hand Hand { get; } = new();

}