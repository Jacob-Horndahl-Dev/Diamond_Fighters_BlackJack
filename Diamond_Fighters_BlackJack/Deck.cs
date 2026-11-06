
using System;
using System.Collections.Generic;

public class Deck
{
    // Lista med alla kort och en slumpgenerator
    private List<Card> cards = new List<Card>();
    private Random random = new Random();

    // Skapar kortleken när spelet startar
    public Deck()
    {
        RefillDeck();
    }

    // Fyller kortleken med 52 kort
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

                // Ess är 11 och klädda kort är 10
                if (i == 0)
                    value = 11;
                else if (i >= 10)
                    value = 10;

                cards.Add(new Card(suit, ranks[i], value));
            }
        }

        Shuffle();
    }

    // Blandar korten så att ordningen blir slumpmässig
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

    // Tar det översta kortet och tar bort det från kortleken
    public Card DrawCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    // Fyller på kortleken om det finns färre än 15 kort kvar
    public void PrepareNextRound()
    {
        if (cards.Count < 15)
        {
            RefillDeck();
        }
    }

    // Visar hur många kort som finns kvar
    public int CardsRemaining()
    {
        return cards.Count;
    }
}
