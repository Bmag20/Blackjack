using System.Collections.Generic;

namespace Blackjack
{
    class Player
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
            Calculator.CalculateSumOfCardValues(this);
        }
        
        public bool IsBusted()
        {
            return (Value > 21);
        }
        
        //compute sum

        // public override string ToString()
        // {
        //     return $"with the hand [{CardsInHand}]";
        // }
    }
}