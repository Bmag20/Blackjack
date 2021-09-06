using System.Collections.Generic;
using Blackjack.BackJackControl;

namespace Blackjack.Entities
{
    public class Hand
    {
        public List<Card> CardsInHand { get; set; }

        public Hand()
        {
            CardsInHand = new List<Card>();
        }
        
    }
}