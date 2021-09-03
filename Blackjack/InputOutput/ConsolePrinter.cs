using System;
using System.Collections.Generic;
using Blackjack.Entities;

namespace Blackjack.InputOutput
{
    internal class ConsolePrinter : IOutputWriter
    {
        public void PrintText(string text)
        {
            Console.Write(text);
        }

        private static void PrintCardsInHand(List<Card> cards)
        {
            Console.Write("with the hand [");
            foreach (var card in cards)
            {
                Console.Write(card);
            }
            Console.WriteLine("]");
        }

        public void PrintPlayerHandStatus(Hand player)
        {
            Console.WriteLine($"You are currently at {player.Value}");
            PrintCardsInHand(player.CardsInHand);
        }

        public void PrintDealerHandStatus(Hand dealer)
        {
            Console.WriteLine($"\nDealer is at {dealer.Value}");
            PrintCardsInHand(dealer.CardsInHand);
        }
    }
}