using Blackjack.Entities;

namespace Blackjack.BackJackControl
{
    public static class Scorer
    {
        private static bool _aceInHand;

        public static void CalculateValueOfHand(Player player)
        {
            int valueInHand = 0;
            _aceInHand = false;
            foreach (var card in player.CardsInHand)
            {
                valueInHand += GetCardValue(card, valueInHand);
            }

            player.Value = ReCorrectAceValue(valueInHand);
        }

        private static int GetCardValue(Card card, int totalValueInHand)
        {
            if (card.Rank is > Card.CardRank.Ace and < Card.CardRank.Jack)
                return (int) card.Rank;
            else if (card.Rank == Card.CardRank.Ace)
            {
                _aceInHand = true;
                return totalValueInHand + 11 <= 21 ? 11 : 1;
            }
            else
                return 10;
        }

        private static int ReCorrectAceValue(int totalValueInHand)
        {
            if (_aceInHand && totalValueInHand > 21)
                return totalValueInHand - 10;
            else
                return totalValueInHand;
        }

        public static string DecideWinner(int playerValue, int dealerValue)
        {
            string winner;
            switch (playerValue)
            {
                case > 21:
                    winner = BlackJackConstants.DealerWins;
                    break;
                case 21:
                    winner = dealerValue == 21 ? BlackJackConstants.Tied : BlackJackConstants.PlayerWins;
                    break;
                default:
                {
                    if (dealerValue > 21)
                        winner = BlackJackConstants.PlayerWins;
                    else
                        winner = playerValue > dealerValue ? BlackJackConstants.PlayerWins : BlackJackConstants.DealerWins;
                    break;
                }
            }

            return winner;
        }
    }
}