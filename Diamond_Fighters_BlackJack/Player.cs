public class Player
{
    public string Name { get; set; }
    public int Balance { get; set; } = 100;
    public int RoundsPlayed { get; set; } = 0;
    public int Bet { get; set; }
    public Hand Hand { get; } = new();

}