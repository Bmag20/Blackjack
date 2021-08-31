namespace Blackjack
{
    class Card
    {

        private enum CardSuit
        {
            Spade, Heart, Diamond, Club
        }

        enum CardRank
        {
            Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Jack, Queen, King
        }

        private CardSuit Suit { get; set; }
        private CardRank Rank { get; set; }
        
        //To string method to format the print statement
    }
}