using System;

namespace Blackjack
{
    class ConsoleInputHandler : IInputHandler
    {
        public int GetHitOrStayInput()
        {
            string userInput = Console.ReadLine();
            // validate
            return Int32.Parse(userInput);
        }
    }
}