using System;
using System.Collections.Generic;
using Blackjack.Entities;

namespace Blackjack.InputOutput
{
    internal class ConsolePrinter : IOutputWriter
    {
        public void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        public void PrintCardsInHand(Hand hand)
        {
            Console.Write("with the hand [");
            foreach (var card in hand.CardsInHand)
            {
                Console.Write(card);
            }

            Console.WriteLine("]");
        }
    }
}