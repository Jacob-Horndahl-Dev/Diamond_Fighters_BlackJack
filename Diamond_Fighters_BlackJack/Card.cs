
public class Card
{
    // Kortets färg, namn och värde
    public string Suit { get; set; }
    public string Rank { get; set; }
    public int Value { get; set; }

    // Skapar ett kort med de värden vi skickar in
    public Card(string suit, string rank, int value)
    {
        Suit = suit;
        Rank = rank;
        Value = value;
    }
}
