using System;

namespace Blackjack
{
    class ConsoleReader : IInputReader
    {
        public int GetHitOrStayInput()
        {
            string userInput = Console.ReadLine();
            while (!Validator.IsHitOrStay(userInput))
            {
                Console.WriteLine("Invalid Input! Please enter 0 or 1 only (Hit = 1, Stay = 0)");
                userInput = Console.ReadLine();
            }
            return Int32.Parse(userInput);
        }
    }
}