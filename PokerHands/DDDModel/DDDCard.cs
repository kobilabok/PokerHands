using PokerHands.Enums;

namespace PokerHands.DDDModel
{
    public class DDDCard
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public DDDCard(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
