using System;

namespace PokerHands.Code
{
    public class PokerHand
    {
        public List<Card> Cards { get; set; }
        public PokerHand(List<Card> cards)
        {
            Cards = cards;
        }

        public bool HasPair() => Cards.GroupBy(card => card.Rank).Any(group => group.Count() == 2);

        public bool HasTwoPairs() => Cards.GroupBy(card => card.Rank).Count(group => group.Count() == 2) == 2;

        public bool HasThreeOfAKind() => Cards.GroupBy(card => card.Rank).Any(group => group.Count() == 3);

        public bool HasFlush() => Cards.GroupBy(card => card.Suit).Any(group => group.Count() == 5);
    }
}
