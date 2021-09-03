namespace Blackjack.Entities
{
    public class Card
    {
        public enum CardSuit
        {
            Spade,
            Heart,
            Diamond,
            Club
        }

        public enum CardRank
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Jack,
            Queen,
            King
        }

        private CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }

        public Card(CardRank rank, CardSuit suit)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        public override string ToString()
        {
            return $"['{Rank}', {Suit}']";
        }
    }
}