using System;
using Blackjack.BackJackControl;
using Blackjack.InputOutput;

namespace Blackjack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IInputReader inputHandler = new ConsoleReader();
            IOutputWriter outputHandler = new ConsolePrinter();
            BlackJackEngine blackJack = new BlackJackEngine(inputHandler, outputHandler);
            blackJack.ConductGame();
        }
    }
}