using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Calculator
    {
        private const string PlayerWins = "You beat the dealer!";    

        private const string DealerWins = "Dealer wins!";

        private const string Tied = "You tied with the dealer! Nobody wins!";
        public static void CalculateSumOfCardValues(Player player)
        {
            int sum = 0;
            foreach (var card in player.CardsInHand)
            {
                sum += card.GetCardValue();
            }
            player.Value = sum;
            
        }

        public static string DecideWinner(int playerValue, int dealerValue)
        {
            string winner;
            if (playerValue > 21)
                winner = DealerWins;
            else
            {
                if (playerValue == 21)
                    winner = dealerValue == 21 ? Tied : PlayerWins;
                else if (dealerValue > 21)
                    winner = DealerWins;
                else
                    winner = playerValue > dealerValue ? PlayerWins : DealerWins;
            }
            return winner;
        }
        
    }
}