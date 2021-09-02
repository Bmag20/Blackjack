using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IInputHandler inputHandler = new ConsoleInputHandler();
            IOutputHandler outputHandler = new ConsolePrinter();
            BlackJackEngine blackJack = new BlackJackEngine(inputHandler, outputHandler);
            blackJack.ConductGame();
        }
    }
}