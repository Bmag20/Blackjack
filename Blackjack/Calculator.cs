using System.Collections.Generic;

namespace Blackjack
{
    class Calculator
    {
        // Calculate the value of cards in hand
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
            {
                winner = "dealer";
            }
            else
            {
                if (playerValue == 21)
                    winner = dealerValue == 21 ? "dealer" : "player";
                else if (dealerValue > 21)
                    winner = "dealer";
                else if ((21 - playerValue) < (21 - dealerValue))
                    winner = "player";
                else
                    winner = "dealer";
            }
            return winner;
        }
        
    }
}