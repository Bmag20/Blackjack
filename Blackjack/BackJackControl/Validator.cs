namespace Blackjack.BackJackControl
{
    internal class Validator
    {
        public static bool IsHitOrStay(string input)
        {
            return input is "0" or "1";
        }
    }
}