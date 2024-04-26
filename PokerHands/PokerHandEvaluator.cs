using PokerHands.Enums;

namespace PokerHands.Code
{
    public class PokerHandEvaluator
    {
        public PokerHandResult Evaluate(PokerHand hand1, PokerHand hand2)
        {
            // Check for Flush
            if (hand1.HasFlush() && hand2.HasFlush())
                return CompareHighestCard(hand1, hand2);
            else if (hand1.HasFlush())
                return new PokerHandResult(hand1, HandDealt.Flush);
            else if (hand2.HasFlush())
                return new PokerHandResult(hand2, HandDealt.Flush);

            // Check for Three Of A Kind
            if (hand1.HasThreeOfAKind() && hand2.HasThreeOfAKind())
            {
                var hand1Rank = GetThreeOfAKindRank(hand1);
                var hand2Rank = GetThreeOfAKindRank(hand2);

                if (hand1Rank > hand2Rank)
                    return new PokerHandResult(hand1, HandDealt.Pair);
                else if (hand1Rank < hand2Rank)
                    return new PokerHandResult(hand2, HandDealt.Pair);
                else
                    return CompareHighestCardExceptRank(hand1, hand2, new[] { hand1Rank });
            }
            else if (hand1.HasThreeOfAKind())
                return new PokerHandResult(hand1, HandDealt.ThreeOfAKind);
            else if (hand2.HasThreeOfAKind())
                return new PokerHandResult(hand2, HandDealt.ThreeOfAKind);

            // Check for Two Pairs
            if (hand1.HasTwoPairs() && hand2.HasTwoPairs())
            {
                var hand1pairs = GetPairsRank(hand1).OrderByDescending(c => c);
                var hand2pairs = GetPairsRank(hand2).OrderByDescending(c => c);

                if (hand1pairs.ElementAt(0) > hand2pairs.ElementAt(0))
                    return new PokerHandResult(hand1, HandDealt.TwoPairs);
                else if (hand1pairs.ElementAt(0) < hand2pairs.ElementAt(0))
                    return new PokerHandResult(hand2, HandDealt.TwoPairs);
                else if (hand1pairs.ElementAt(1) > hand2pairs.ElementAt(1))
                    return new PokerHandResult(hand1, HandDealt.TwoPairs);
                else if (hand1pairs.ElementAt(1) < hand2pairs.ElementAt(1))
                    return new PokerHandResult(hand2, HandDealt.TwoPairs);
                else
                    return CompareHighestCardExceptRank(hand1, hand2, hand1pairs.ToArray());
            }
            else if (hand1.HasTwoPairs())
                return new PokerHandResult(hand1, HandDealt.TwoPairs);
            else if (hand2.HasTwoPairs())
                return new PokerHandResult(hand2, HandDealt.TwoPairs);

            // Check for One Pair
            if (hand1.HasPair() && hand2.HasPair())
            {
                var hand1Rank = GetPairRank(hand1);
                var hand2Rank = GetPairRank(hand2);

                if (hand1Rank > hand2Rank)
                    return new PokerHandResult(hand1, HandDealt.Pair);
                else if (hand1Rank < hand2Rank)
                    return new PokerHandResult(hand2, HandDealt.Pair);
                else
                    return CompareHighestCardExceptRank(hand1, hand2, new[] { hand1Rank });
            }
            else if (hand1.HasPair())
                return new PokerHandResult(hand1, HandDealt.Pair);
            else if (hand2.HasPair())
                return new PokerHandResult(hand2, HandDealt.Pair);

            return CompareHighestCard(hand1, hand2);
        }

        private static PokerHandResult CompareHighestCard(PokerHand hand1, PokerHand hand2)
        {
            return CompareHighestCardExceptRank(hand1, hand2, Array.Empty<Rank>());
        }

        private static PokerHandResult CompareHighestCardExceptRank(PokerHand hand1, PokerHand hand2, Rank[] cardRanks)
        {
            var hand1Cards = hand1.Cards.Where(c => !cardRanks.Contains(c.Rank)).OrderByDescending(c => c.Rank);
            var hand2Cards = hand2.Cards.Where(c => !cardRanks.Contains(c.Rank)).OrderByDescending(c => c.Rank);

            for (int i = 0; i < hand1Cards.Count(); i++)
            {
                if (hand1Cards.ElementAt(i).Rank > hand2Cards.ElementAt(i).Rank)
                    return new PokerHandResult(hand1, HandDealt.HighCard);
                else if (hand1Cards.ElementAt(i).Rank < hand2Cards.ElementAt(i).Rank)
                    return new PokerHandResult(hand2, HandDealt.HighCard);
            }
            return new PokerHandResult(winningHand: null, HandDealt.Tie);
       }

        private static Rank GetPairRank(PokerHand hand)
        {
            var groups = hand.Cards.GroupBy(card => card.Rank);
            var pairGroup = groups.FirstOrDefault(group => group.Count() == 2);

            if (pairGroup != null)
                return pairGroup.Key;

            return Rank.Two;
        }

        private static Rank[] GetPairsRank(PokerHand hand)
        {
            var groups = hand.Cards.GroupBy(card => card.Rank);
            var pairGroup = groups.Where(group => group.Count() == 2);

            return pairGroup.Select(group => group.Key).ToArray();
        }

        private static Rank GetThreeOfAKindRank(PokerHand hand)
        {
            var groups = hand.Cards.GroupBy(card => card.Rank);
            var threeOfKindGroup = groups.FirstOrDefault(group => group.Count() == 3);

            return threeOfKindGroup != null ? threeOfKindGroup.Key : Rank.Two;
        }
    }
}
