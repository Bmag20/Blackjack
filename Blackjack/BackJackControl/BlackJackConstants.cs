namespace Blackjack.BackJackControl
{
    public static class BlackJackConstants
    {
        public enum Winner
        {
            Player,
            Dealer,
            Tie
        }
        public const string PlayerWins = "You beat the dealer!";

        public const string DealerWins = "Dealer wins!";

        public const string Tied = "You tied with the dealer! Nobody wins!";
    }
}