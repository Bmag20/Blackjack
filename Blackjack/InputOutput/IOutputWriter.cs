using System.Collections.Generic;
using Blackjack.Entities;

namespace Blackjack.InputOutput
{
    internal interface IOutputWriter
    {
        public void PrintText(string text);
        public void PrintCardsInHand(List<Card> cards);
        public void PrintPlayerHandStatus(Player player);
        public void PrintDealerHandStatus(Player dealer);
    }
}