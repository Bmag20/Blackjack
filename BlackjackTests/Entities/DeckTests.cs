using Blackjack.Entities;
using Xunit;

namespace BlackjackTests.Entities
{
    public class DeckTests
    {
        private Deck _deck = new Deck();

        [Fact]
        public void New_deck_contains_52_cards()
        {
            _deck = new Deck();
            Assert.Equal(52, _deck.Cards.Count);
        }

        [Fact]
        public void First_card_is_different_after_shuffling_the_deck()
        {
            Card topCard = _deck.Cards[0];
            _deck.ShuffleDeck();
            Assert.NotEqual(topCard, _deck.Cards[0]);
        }

        [Fact]
        public void Deck_has_1_less_card_after_getting_next_card()
        {
            var cardsCount = _deck.Cards.Count;
            _deck.GetNextCard();
            Assert.Equal(cardsCount - 1, _deck.Cards.Count);
        }

        [Fact]
        public void Getting_next_card_gives_top_card_from_the_deck()
        {
            var card = _deck.Cards[0];
            Assert.Equal(card, _deck.GetNextCard());
        }
    }
}