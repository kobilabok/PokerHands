using PokerHands.Code;
using Xunit;
using PokerHands.Enums;
using System.Collections.Generic;
using FluentAssertions;

namespace PokerHards.Tests
{
    public class PokerHandsTests
    {
        [Fact]
        public void HandWith_HigherCard_ShouldWin()
        {
            // Arrange
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Three },
                new Card { Suit = Suit.Hearts, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.King},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Hearts, Rank = Rank.Jack },
                new Card { Suit = Suit.Diamonds, Rank = Rank.King },
                new Card { Suit = Suit.Hearts, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Three },
                new Card { Suit = Suit.Spades, Rank = Rank.Six }
            });

            // Act 
            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            // Assert
            result.WinningHand.Should().Be(hand1);
            result.HandDealt.Should().Be(HandDealt.HighCard);
        }

        [Fact]
        public void HandWith_Pair_ShouldWin()
        {
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Two },
                new Card { Suit = Suit.Hearts, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Jack},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Hearts, Rank = Rank.Four },
                new Card { Suit = Suit.Diamonds, Rank = Rank.Jack },
                new Card { Suit = Suit.Hearts, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Three },
                new Card { Suit = Suit.Spades, Rank = Rank.Six }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(hand1);
            result.HandDealt.Should().Be(HandDealt.Pair);
        }

        [Fact]
        public void HandWith_HigherPair_ShouldWin()
        {
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Two },
                new Card { Suit = Suit.Hearts, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Jack},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Hearts, Rank = Rank.Four },
                new Card { Suit = Suit.Diamonds, Rank = Rank.Four },
                new Card { Suit = Suit.Hearts, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Three },
                new Card { Suit = Suit.Spades, Rank = Rank.Six }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(hand2);
            result.HandDealt.Should().Be(HandDealt.Pair);
        }

        [Fact]
        public void HandWith_TwoPairs_ShouldWin()
        {
            // Create hands for testing
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Two },
                new Card { Suit = Suit.Hearts, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Jack},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Hearts, Rank = Rank.Two },
                new Card { Suit = Suit.Diamonds, Rank = Rank.Two },
                new Card { Suit = Suit.Hearts, Rank = Rank.Jack },
                new Card { Suit = Suit.Spades, Rank = Rank.Three },
                new Card { Suit = Suit.Spades, Rank = Rank.Three }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(hand2);
            result.HandDealt.Should().Be(HandDealt.TwoPairs);
        }

        [Fact]
        public void BothHandsWith_SamePair_HandWithHigherCardShouldWin()
        {
            // Create hands for testing
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Two },
                new Card { Suit = Suit.Hearts, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Jack},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Hearts, Rank = Rank.Two },
                new Card { Suit = Suit.Diamonds, Rank = Rank.Two },
                new Card { Suit = Suit.Hearts, Rank = Rank.Jack },
                new Card { Suit = Suit.Spades, Rank = Rank.Seven },
                new Card { Suit = Suit.Spades, Rank = Rank.Nine }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(hand1);
            result.HandDealt.Should().Be(HandDealt.HighCard);
        }

        [Fact]
        public void HandWith_ThreeOfAKind_ShouldWin()
        {
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Three },
                new Card { Suit = Suit.Hearts, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Jack},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Hearts, Rank = Rank.Jack },
                new Card { Suit = Suit.Diamonds, Rank = Rank.Ace },
                new Card { Suit = Suit.Hearts, Rank = Rank.Three },
                new Card { Suit = Suit.Spades, Rank = Rank.Three },
                new Card { Suit = Suit.Diamonds, Rank = Rank.Three }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(hand2);
            result.HandDealt.Should().Be(HandDealt.ThreeOfAKind);
        }

        [Fact]
        public void HandsWith_Flush_ShouldWin()
        {
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Clubs, Rank = Rank.Three },
                new Card { Suit = Suit.Clubs, Rank = Rank.Nine },
                new Card { Suit = Suit.Clubs, Rank = Rank.Jack},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Hearts, Rank = Rank.Jack },
                new Card { Suit = Suit.Diamonds, Rank = Rank.Ace },
                new Card { Suit = Suit.Hearts, Rank = Rank.Two },
                new Card { Suit = Suit.Spades, Rank = Rank.Three },
                new Card { Suit = Suit.Spades, Rank = Rank.Six }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(hand1);
            result.HandDealt.Should().Be(HandDealt.Flush);
        }

        [Fact]
        public void BothHandsWith_Flush_HandWithHigherCardShouldWin()
        {
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Clubs, Rank = Rank.Three },
                new Card { Suit = Suit.Clubs, Rank = Rank.Nine },
                new Card { Suit = Suit.Clubs, Rank = Rank.Jack},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Queen },
                new Card { Suit = Suit.Clubs, Rank = Rank.Nine },
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Clubs, Rank = Rank.Three },
                new Card { Suit = Suit.Clubs, Rank = Rank.Six }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(hand2);
            result.HandDealt.Should().Be(HandDealt.HighCard);
        }

        [Fact]
        public void HandsWith_SameCards_TieShouldBeReturned()
        {
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Clubs, Rank = Rank.Three },
                new Card { Suit = Suit.Clubs, Rank = Rank.Four },
                new Card { Suit = Suit.Clubs, Rank = Rank.Nine},
                new Card { Suit = Suit.Clubs, Rank = Rank.King }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Clubs, Rank = Rank.Three },
                new Card { Suit = Suit.Clubs, Rank = Rank.Four },
                new Card { Suit = Suit.Clubs, Rank = Rank.Nine },
                new Card { Suit = Suit.Clubs, Rank = Rank.King }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(null);
            result.HandDealt.Should().Be(HandDealt.Tie);
        }

        [Fact]
        public void HandsWith_SamePair_HighCardOutsidePairShouldWin()
        {
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Clubs, Rank = Rank.Nine},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Ace },
                new Card { Suit = Suit.Clubs, Rank = Rank.Four },
                new Card { Suit = Suit.Clubs, Rank = Rank.Nine },
                new Card { Suit = Suit.Clubs, Rank = Rank.King }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(hand2);
            result.HandDealt.Should().Be(HandDealt.HighCard);
        }

        [Fact]
        public void HandsWith_TwoSamePairsAndTheSameRemainingCard_TieShouldBeReturned()
        {
            var hand1 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Clubs, Rank = Rank.Two },
                new Card { Suit = Suit.Clubs, Rank = Rank.Three },
                new Card { Suit = Suit.Clubs, Rank = Rank.Three},
                new Card { Suit = Suit.Clubs, Rank = Rank.Four }
            });

            var hand2 = new PokerHand(new List<Card>
            {
                new Card { Suit = Suit.Clubs, Rank = Rank.Three },
                new Card { Suit = Suit.Clubs, Rank = Rank.Three },
                new Card { Suit = Suit.Clubs, Rank = Rank.Four },
                new Card { Suit = Suit.Clubs, Rank = Rank.Two},
                new Card { Suit = Suit.Clubs, Rank = Rank.Two }
            });

            var sut = new PokerHandEvaluator();
            var result = sut.Evaluate(hand1, hand2);

            result.WinningHand.Should().Be(null);
            result.HandDealt.Should().Be(HandDealt.Tie);
        }
    }
}