using System;

namespace PokerHands.CustomExceptions
{
    public class DeckIsEmptyException : Exception
    {
        public DeckIsEmptyException(string message) : base(message)
        {
        }
    }
}
