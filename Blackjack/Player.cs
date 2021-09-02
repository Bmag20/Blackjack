using System.Collections.Generic;

namespace Blackjack
{
    class Player
    {
        public List<Card> CardsInHand { get; set; }

        public Player()
        {
            CardsInHand = new List<Card>();
        }
        public void AddCard(Card card)
        {
            CardsInHand.Add(card);
        }
        
        //compute sum

        // public override string ToString()
        // {
        //     return $"with the hand [{CardsInHand}]";
        // }
    }
}