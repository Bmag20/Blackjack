using Blackjack.Entities;
using Xunit;

namespace BlackjackTests.Entities
{
    public class GameTests
    {
        Game _game = new Game();
        
        [Fact]
        public void Drawing_initial_hand_assigns_2_cards_to_player()
        { 
            _game = new Game();
            _game.DrawInitialHand();
            Assert.Equal(2, _game.Player.CardsInHand.Count);
        }

        [Fact]
        public void Drawing_initial_hand_assigns_2_cards_to_dealer()
        {
            _game = new Game();
            _game.DrawInitialHand();
            Assert.Equal(2, _game.Dealer.CardsInHand.Count);
        }
        
        [Fact]
        public void Adding_card_to_player_increases_the_player_cards_count_by_1()
        {
            var playerCardsCount = _game.Player.CardsInHand.Count;
            _game.AddCardToPlayer(new Card(Card.CardRank.Ace, Card.CardSuit.Spade));
            Assert.Equal(playerCardsCount + 1, _game.Player.CardsInHand.Count);
        }
        
        [Fact]
        public void Adding_card_to_dealer_increases_the_dealer_cards_count_by_1()
        {
            var dealerCardsCount = _game.Dealer.CardsInHand.Count;
            _game.AddCardToDealer(new Card(Card.CardRank.Queen, Card.CardSuit.Heart));
            Assert.Equal(dealerCardsCount + 1, _game.Dealer.CardsInHand.Count);
        }
    }
}