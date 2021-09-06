using Blackjack.Entities;

namespace Blackjack.InputOutput
{
    internal interface IOutputWriter
    {
        public void PrintText(string text);
        public void PrintCardsInHand(Hand hand);
    }
}