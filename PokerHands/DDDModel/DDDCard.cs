using PokerHands.Enums;

namespace PokerHands.DDDModel
{
    public class DDDCard
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public DDDCard(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
