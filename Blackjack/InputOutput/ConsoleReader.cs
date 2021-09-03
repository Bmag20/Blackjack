using System;
using Blackjack.BackJackControl;

namespace Blackjack.InputOutput
{
    internal class ConsoleReader : IInputReader
    {
        public int GetHitOrStayInput()
        {
            var userInput = Console.ReadLine();
            while (!Validator.IsHitOrStay(userInput))
            {
                Console.Write("Invalid Input! Please enter 0 or 1 only (Hit = 1, Stay = 0)");
                userInput = Console.ReadLine();
            }
            return Int32.Parse(userInput);
        }
    }
}