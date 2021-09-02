using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputReader inputHandler = new ConsoleReader();
            IOutputWriter outputHandler = new ConsolePrinter();
            BlackJackEngine blackJack = new BlackJackEngine(inputHandler, outputHandler);
            blackJack.ConductGame();
        }
    }
}