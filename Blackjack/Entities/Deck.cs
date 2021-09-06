using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Entities
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            this.Cards = CreateNewDeck();
        }

        private List<Card> CreateNewDeck()
        {
            List<Card> cards = new List<Card>();
            foreach (Card.CardRank rank in Enum.GetValues<Card.CardRank>())
            {
                foreach (Card.CardSuit suit in Enum.GetValues<Card.CardSuit>())
                {
                    cards.Add(new Card(rank, suit));
                }
            }

            return cards;
        }

        public void ShuffleDeck()
        {
            Cards = Cards.OrderBy(c => new Random().Next()).ToList();
        }

        public Card GetNextCard()
        {
            Card nextCard = Cards[0];
            this.Cards.RemoveAt(0);
            return nextCard;
        }
    }
}