using Blackjack.Entities;

namespace Blackjack.InputOutput
{
    internal interface IOutputWriter
    {
        public void PrintText(string text);
        public void PrintPlayerHandStatus(Hand player);
        public void PrintDealerHandStatus(Hand dealer);
    }
}