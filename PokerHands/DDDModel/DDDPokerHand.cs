using PokerHands.Enums;

namespace PokerHands.DDDModel
{
    public class DDDPokerHand : IComparable<DDDPokerHand>
    {
        public IReadOnlyCollection<DDDCard> Cards { get; }
        public DDDPokerHand(DDDCard card1, DDDCard card2, DDDCard card3, DDDCard card4, DDDCard card5)
        {
            Cards = new[] { card1, card2, card3, card4, card5 };
        }

        public bool HasPair() => Cards.GroupBy(card => card.Rank).Any(group => group.Count() == 2);

        public bool HasTwoPairs() => Cards.GroupBy(card => card.Rank).Count(group => group.Count() == 2) == 2;

        public bool HasThreeOfAKind() => Cards.GroupBy(card => card.Rank).Any(group => group.Count() == 3);

        public bool HasFlush() => Cards.GroupBy(card => card.Suit).Any(group => group.Count() == 5);

        public HandDealt GetHandType()
        {
            if (HasFlush()) return HandDealt.Flush;
            if (HasThreeOfAKind()) return HandDealt.ThreeOfAKind;
            if (HasTwoPairs()) return HandDealt.TwoPairs;
            if (HasPair()) return HandDealt.Pair;

            return HandDealt.HighCard;
        }

        public int CompareTo(DDDPokerHand? other)
        {
            var thisHandValue = EvaluateHandValue();
            var otherHandValue = other.EvaluateHandValue();

            if (thisHandValue != otherHandValue)
                return thisHandValue.CompareTo(otherHandValue);
            else
                return CompareHandsByRanks(other);
        }

        public int EvaluateHandValue()
        {
            if (HasFlush()) return 6;
            if (HasThreeOfAKind()) return 4;
            if (HasTwoPairs()) return 3;
            if (HasPair()) return 2;

            return 1; // High card
        }

        public int CompareHandsByRanks(DDDPokerHand? other)
        {
            var thisSortedCards = Cards.OrderByDescending(card => card.Rank).ToList();
            var otherSortedCards = other.Cards.OrderByDescending(card => card.Rank).ToList();

            for (int i = 0; i < thisSortedCards.Count(); i++)
            {
                if (thisSortedCards.ElementAt(i).Rank > otherSortedCards.ElementAt(i).Rank)
                    return 1;
                else if (thisSortedCards.ElementAt(i).Rank < otherSortedCards.ElementAt(i).Rank)
                    return -1;
            }
            return 0;
        }

        private static Rank GetPairRank(DDDPokerHand hand)
        {
            var groups = hand.Cards.GroupBy(card => card.Rank);
            var pairGroup = groups.FirstOrDefault(group => group.Count() == 2);

            if (pairGroup != null)
                return pairGroup.Key;

            return Rank.Two;
        }
    }
}
