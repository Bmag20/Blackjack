using System.Collections.Generic;
using Blackjack.BackJackControl;

namespace Blackjack.Entities
{
    public class Player
    {
        public List<Card> CardsInHand { get; set; }
        public bool Busted { get; set; }
        public int Value { get; set; }

        public Player()
        {
            CardsInHand = new List<Card>();
            Busted = false;
            Value = 0;
        }
        public void AddCard(Card card)
        {
            CardsInHand.Add(card);
            Scorer.CalculateValueOfHand(this);
        }
        
        public bool IsBusted()
        {
            return (Value > 21);
        }
        
    }
}