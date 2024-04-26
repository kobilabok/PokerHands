using PokerHands.Enums;
using System;

namespace PokerHands.Code
{
    public class PokerHandResult
    {
        public PokerHand? WinningHand { get; set; }
        public HandDealt HandDealt { get; set; }

        public PokerHandResult(PokerHand winningHand, HandDealt handDealt)
        {
            WinningHand = winningHand;
            HandDealt = handDealt;
        }
    }
}
