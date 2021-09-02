namespace Blackjack
{
    class Validator
    {
        // Validate user input
        public static bool IsHitOrStay(string input)
        {
            return (input == "0" || input == "1");
        }
    }
}