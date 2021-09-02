using System;
using System.Collections.Generic;

namespace Blackjack
{
    class ConsolePrinter : IOutputWriter
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

        public void PrintPlayerHandStatus(Player player)
        {
            Console.WriteLine($"You are currently at {player.Value}");
            PrintCardsInHand(player.CardsInHand);
        }

        public void PrintDealerHandStatus(Player dealer)
        {
            Console.WriteLine($"\nDealer is at {dealer.Value}");
            PrintCardsInHand(dealer.CardsInHand);
        }
    }
}