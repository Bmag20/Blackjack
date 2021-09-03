using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{
    internal class Deck
    {
        private List<Card> Cards { get; set; }

        public Deck()
        {
            this.Cards = CreateNewDeck();
        }
        
        // Create a deck
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
        
        // Shuffle deck??

        // Get random card from the deck
        public Card GetRandomCard()
        {
            Random random = new Random();
            int randomNumber = random.Next(this.Cards.Count);
            Card randomCard = Cards[randomNumber];
            this.Cards.RemoveAt(randomNumber);
            return randomCard;
        }
        
    }
}