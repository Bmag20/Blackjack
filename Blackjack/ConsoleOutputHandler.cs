using System;
using System.Collections.Generic;

namespace Blackjack
{
    class ConsoleOutputHandler : IOutputHandler
    {
        public void PrintText(string text)
        {
            Console.Write(text);
        }

        public void PrintCardsInHand(List<Card> cards)
        {
            Console.Write("with the hand [");
            foreach (var card in cards)
            {
                Console.Write(card);
            }
            Console.WriteLine("]");
        }
    }
}