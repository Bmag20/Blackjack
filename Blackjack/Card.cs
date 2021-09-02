using System;

namespace Blackjack
{
    class Card
    {

        public enum CardSuit
        {
            Spade, Heart, Diamond, Club
        }

        public enum CardRank
        {
            Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Jack, Queen, King
        }

        private CardSuit Suit { get; set; }
        private CardRank Rank { get; set; }

        public Card(CardRank rank, CardSuit suit)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
        
        // Get value method

        public int GetCardValue()
        {
            if (Rank is > CardRank.Ace and < CardRank.Jack)
            {
                return (int) Rank;
            }
            else if (Rank == CardRank.Ace)
            {
                return 1;
            }
            else
            {
                return 10;
            }
        }
        
        //To string method to format the print statement

        public override string ToString()
        {
            return $"['{Rank}', {Suit}']";
        }
    }
}