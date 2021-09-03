using System.Linq;
using Blackjack.Entities;

namespace Blackjack.BackJackControl
{
    public static class Scorer
    {
        private static bool _aceInHand;

        public static void CalculateValueOfHand(Hand player)
        {
            _aceInHand = false;
            int valueInHand = player.CardsInHand.Aggregate(0, (current, card) => current + GetCardValue(card, current));
            player.Value = ReCorrectAceValue(valueInHand);
        }

        private static int GetCardValue(Card card, int totalValueInHand)
        {
            switch (card.Rank)
            {
                case > Card.CardRank.Ace and < Card.CardRank.Jack:
                    return (int) card.Rank;
                case Card.CardRank.Ace:
                    _aceInHand = true;
                    return totalValueInHand + 11 <= 21 ? 11 : 1;
                default:
                    return 10;
            }
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
                    else if (dealerValue == playerValue)
                        winner = BlackJackConstants.Tied;
                    else
                        winner = playerValue > dealerValue ? BlackJackConstants.PlayerWins : BlackJackConstants.DealerWins;
                    break;
                }
            }
            
            return winner;
        }
    }
}