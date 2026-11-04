
using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards = new List<Card>();
    private Random random = new Random();

    public Deck()
{
    RefillDeck();
}

private void RefillDeck()
{
    cards.Clear();
        string[] suits = { "Hjärter", "Ruter", "Klöver", "Spader" };
        string[] ranks = { "Ess", "2", "3", "4", "5", "6",
                           "7", "8", "9", "10", "Knekt", "Dam", "Kung" };

        foreach (string suit in suits)
        {
            for (int i = 0; i < ranks.Length; i++)
            {
                int value = i + 1;

                if (i == 0)
                    value = 11;
                else if (i >= 10)
                    value = 10;

                cards.Add(new Card(suit, ranks[i], value));
            }
        }

        Shuffle();
    }

    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

  public Card DrawCard()
{
    Card card = cards[0];
    cards.RemoveAt(0);
    return card;
}

public void PrepareNextRound()
{
    if (cards.Count < 15)
    {
        RefillDeck();
    }
}

    public int CardsRemaining()
    {
        return cards.Count;
    }
}
