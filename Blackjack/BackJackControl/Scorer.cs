using System.Linq;
using Blackjack.Entities;
using static Blackjack.BackJackControl.BlackJackConstants;

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

        public static Winner DecideWinner(int playerValue, int dealerValue)
        {
            Winner winner;
            if (playerValue == dealerValue)
                winner = Winner.Tie;
            else if (playerValue > 21)
                winner = Winner.Dealer;
            else if (dealerValue > 21)
                winner = Winner.Player;
            else
                winner = playerValue > dealerValue ? Winner.Player : Winner.Dealer;
            return winner;
        }
    }
}