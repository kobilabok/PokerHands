using PokerHands.CustomExceptions;
using PokerHands.Enums;
using System;

namespace PokerHands.Code
{
    public class DeckOfCards
    {
        const int NumberOfCard = 52;
        private List<Card> Deck;

        public DeckOfCards()
        {
            Deck = new List<Card>(NumberOfCard);
            GenerateDeck();
            Shuffle();
        }

        public void GenerateDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Deck.Add(new Card { Suit = suit, Rank = rank });
                }
            }
        }

        private void Shuffle()
        {
            Random rand = new Random();
            Deck = Deck.OrderBy(c => rand.Next()).ToList();
        }

        public Card DrawCard()
        {
            if (Deck.Count == 0)
                throw new DeckIsEmptyException("Deck is empty.");

            Card drawnCard = Deck[0];
            Deck.RemoveAt(0);
            return drawnCard;
        }

        private List<Card> DrawCards(int count)
           => Enumerable.Range(0, count)
               .Select(_ => DrawCard())
               .ToList();

        public PokerHand DealHand() => new PokerHand(DrawCards(5));
    }
}
