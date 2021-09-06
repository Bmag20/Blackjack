namespace Blackjack.BackJackControl
{
    public static class Validator
    {
        public static bool IsHitOrStay(string input)
        {
            return input is "0" or "1";
        }
    }
}