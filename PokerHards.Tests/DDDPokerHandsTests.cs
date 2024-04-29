using FluentAssertions;
using PokerHands.DDDModel;
using PokerHands.Enums;
using Xunit;

namespace PokerHards.Tests
{
    public class DDDPokerHandsTests
    {

        [Fact]
        public void HandWith_HigherCard_ShouldWin()
        {
            // Arrange
            var hand1 = new DDDPokerHand(
                new DDDCard(Suit.Clubs, Rank.Two),
                new DDDCard(Suit.Spades, Rank.Three),
                new DDDCard(Suit.Hearts, Rank.Ace),
                new DDDCard(Suit.Clubs, Rank.King),
                new DDDCard(Suit.Clubs, Rank.Four));

            var hand2 = new DDDPokerHand(
                new DDDCard(Suit.Hearts, Rank.Jack),
                new DDDCard(Suit.Diamonds, Rank.King),
                new DDDCard(Suit.Hearts, Rank.Two),
                new DDDCard(Suit.Spades, Rank.Three),
                new DDDCard(Suit.Spades, Rank.Six));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.HighCard);
        }

        [Fact]
        public void HandWith_Pair_ShouldWin()
        {
            // Arrange
            var hand1 = new DDDPokerHand(
                new DDDCard(Suit.Clubs, Rank.Two),
                new DDDCard(Suit.Spades, Rank.Two),
                new DDDCard(Suit.Hearts, Rank.Ace),
                new DDDCard(Suit.Clubs, Rank.Jack),
                new DDDCard(Suit.Clubs, Rank.Four));

            var hand2 = new DDDPokerHand(
                new DDDCard(Suit.Hearts, Rank.Four),
                new DDDCard(Suit.Diamonds, Rank.Jack),
                new DDDCard(Suit.Hearts, Rank.Two),
                new DDDCard(Suit.Spades, Rank.Three),
                new DDDCard(Suit.Spades, Rank.Six));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.Pair);
        }

        [Fact]
        public void HandWith_HigherPair_ShouldWin()
        {
            // Arrange
            var hand1 = new DDDPokerHand(
                new DDDCard(Suit.Clubs, Rank.Two),
                new DDDCard(Suit.Spades, Rank.Two),
                new DDDCard(Suit.Hearts, Rank.Ace),
                new DDDCard(Suit.Clubs, Rank.Jack),
                new DDDCard(Suit.Clubs, Rank.Four));

            var hand2 = new DDDPokerHand(
                new DDDCard(Suit.Hearts, Rank.Four),
                new DDDCard(Suit.Diamonds, Rank.Four),
                new DDDCard(Suit.Hearts, Rank.Two),
                new DDDCard(Suit.Spades, Rank.Three),
                new DDDCard(Suit.Spades, Rank.Six));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.Pair);
        }

        [Fact]
        public void BothHandsWith_SamePair_HandWithHigherCardShouldWin()
        {
            // Arrange
            var hand1 = new DDDPokerHand(
                new DDDCard(Suit.Clubs, Rank.Two),
                new DDDCard(Suit.Spades, Rank.Two),
                new DDDCard(Suit.Hearts, Rank.Ace),
                new DDDCard(Suit.Clubs, Rank.Jack),
                new DDDCard(Suit.Clubs, Rank.Four));

            var hand2 = new DDDPokerHand(
                new DDDCard(Suit.Hearts, Rank.Two),
                new DDDCard(Suit.Diamonds, Rank.Two),
                new DDDCard(Suit.Hearts, Rank.Jack),
                new DDDCard(Suit.Spades, Rank.Three),
                new DDDCard(Suit.Spades, Rank.Six));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.HighCard);
        }

        [Fact]
        public void HandWith_ThreeOfAKind_ShouldWin()
        {
            // Arrange
            var hand1 = new DDDPokerHand(
                new DDDCard(Suit.Clubs, Rank.Two),
                new DDDCard(Suit.Spades, Rank.Three),
                new DDDCard(Suit.Hearts, Rank.Ace),
                new DDDCard(Suit.Clubs, Rank.Jack),
                new DDDCard(Suit.Clubs, Rank.Four));

            var hand2 = new DDDPokerHand(
                new DDDCard(Suit.Hearts, Rank.Two),
                new DDDCard(Suit.Diamonds, Rank.Two),
                new DDDCard(Suit.Hearts, Rank.Three),
                new DDDCard(Suit.Spades, Rank.Three),
                new DDDCard(Suit.Spades, Rank.Three));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand2.Should().BeGreaterThan(hand1);
            hand2.GetHandType().Should().Be(HandDealt.ThreeOfAKind);
        }

        [Fact]
        public void HandsWith_Flush_ShouldWin()
        {
            // Arrange
            var hand1 = new DDDPokerHand(
                new DDDCard(Suit.Clubs, Rank.Two),
                new DDDCard(Suit.Clubs, Rank.Three),
                new DDDCard(Suit.Clubs, Rank.Ace),
                new DDDCard(Suit.Clubs, Rank.Jack),
                new DDDCard(Suit.Clubs, Rank.Four));

            var hand2 = new DDDPokerHand(
                new DDDCard(Suit.Hearts, Rank.Two),
                new DDDCard(Suit.Diamonds, Rank.Two),
                new DDDCard(Suit.Hearts, Rank.Three),
                new DDDCard(Suit.Spades, Rank.Three),
                new DDDCard(Suit.Spades, Rank.Three));

            // Act
            hand1.CompareTo(hand2);

            // Assert
            hand1.Should().BeGreaterThan(hand2);
            hand1.GetHandType().Should().Be(HandDealt.Flush);
        }
    }
}
