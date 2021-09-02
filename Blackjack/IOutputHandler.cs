using System.Collections.Generic;

namespace Blackjack
{
    interface IOutputHandler
    {
        public void PrintText(string text);
        public void PrintCardsInHand(List<Card> cards);
        public void PrintPlayerHandStatus(Player player);
        public void PrintDealerHandStatus(Player dealer);
    }
}