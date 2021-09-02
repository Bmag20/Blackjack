using System;
using System.Collections.Generic;

namespace Blackjack
{
    class ConsolePrinter : IOutputHandler
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

        public void PrintHandStatus(Player player)
        {
            Console.WriteLine($"You are currently at {player.Value}");
            PrintCardsInHand(player.CardsInHand);
        }
    }
}