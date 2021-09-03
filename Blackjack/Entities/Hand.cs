using System.Collections.Generic;
using Blackjack.BackJackControl;

namespace Blackjack.Entities
{
    public class Hand
    {
        public List<Card> CardsInHand { get; set; }
        public int Value { get; set; }

        public Hand()
        {
            CardsInHand = new List<Card>();
            Value = 0;
        }

        public void AddCard(Card card)
        {
            CardsInHand.Add(card);
        }

        public bool IsBusted()
        {
            return (Value > 21);
        }
    }
}