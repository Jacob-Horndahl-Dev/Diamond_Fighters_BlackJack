
using System.Collections.Generic;

public class Hand
{
    private List<Card> cards = new List<Card>();

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

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

        while (total > 21 && aces > 0)
        {
            total -= 10;
            aces--;
        }

        return total;
    }

    public bool IsBust()
    {
        return GetValue() > 21;
    }

    public bool IsBlackjack()
    {
        return cards.Count == 2 && GetValue() == 21;
    }

    public void Clear()
    {
        cards.Clear();
    }

    public List<Card> GetCards()
    {
        return new List<Card>(cards);
    }
public void ShowHand()
{
    foreach (Card card in cards)
    {
        Console.WriteLine($"{card.Suit} {card.Rank}");
    }
}
}
