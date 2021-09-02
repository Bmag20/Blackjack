using System.Collections.Generic;

namespace Blackjack
{
    class Calculator
    {
        // Calculate the value of cards in hand
        public static int CalculateSumOfCardValues(List<Card> cardsInHand)
        {
            int sum = 0;
            foreach (var card in cardsInHand)
            {
                sum += card.GetCardValue();
            }

            return sum;
        }
    }
}