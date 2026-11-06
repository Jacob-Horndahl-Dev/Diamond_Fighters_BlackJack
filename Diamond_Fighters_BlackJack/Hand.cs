
using System.Collections.Generic;

public class Hand
{
    // Lista med korten som finns på handen
    private List<Card> cards = new List<Card>();

    // Lägger till ett kort på handen
    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    // Räknar ihop kortens värde
    public int GetValue()
    {
        int total = 0;
        int aces = 0;

        foreach (Card card in cards)
        {
            total += card.Value;

            if (card.Rank == "Ess")
                aces++;
        }

        // Ändrar ess från 11 till 1 om poängen blir över 21
        while (total > 21 && aces > 0)
        {
            total -= 10;
            aces--;
        }

        return total;
    }

    // Kollar om handen har mer än 21 poäng
    public bool IsBust()
    {
        return GetValue() > 21;
    }

    // Kollar om de två första korten ger Blackjack
    public bool IsBlackjack()
    {
        return cards.Count == 2 && GetValue() == 21;
    }

    // Tömmer handen inför nästa runda
    public void Clear()
    {
        cards.Clear();
    }

    // Hämtar en kopia av listan med korten
    public List<Card> GetCards()
    {
        return new List<Card>(cards);
    }

    // Visar korten som ASCII-bilder i terminalen
    public void ShowHand()
    {
        foreach (Card card in cards)
        {
            // Väljer symbol beroende på kortets färg
            string symbol = card.Suit switch
            {
                "Hjärter" => "♥",
                "Ruter" => "♦",
                "Klöver" => "♣",
                "Spader" => "♠",
                _ => "?"
            };

            // Förkortar kortens namn så de får plats på bilden
            string rank = card.Rank switch
            {
                "Ess" => "A",
                "Knekt" => "J",
                "Dam" => "Q",
                "Kung" => "K",
                _ => card.Rank
            };

            Console.WriteLine("┌─────────┐");
            Console.WriteLine($"│ {rank,-2}      │");
            Console.WriteLine("│         │");
            Console.WriteLine($"│    {symbol}    │");
            Console.WriteLine("│         │");
            Console.WriteLine($"│      {rank,2} │");
            Console.WriteLine("└─────────┘");

            // Visar även kortets namn under bilden
            Console.WriteLine($"{card.Suit} {card.Rank}");
            Console.WriteLine();
        }
    }

    // Visar bara dealerns första kort
    public void ShowFirstCard()
    {
        if (cards.Count == 0) return;

        Hand firstCardHand = new Hand();
        firstCardHand.AddCard(cards[0]);
        firstCardHand.ShowHand();
    }
}
