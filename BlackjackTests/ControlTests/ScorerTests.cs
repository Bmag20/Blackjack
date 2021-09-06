using System.Collections.Generic;
using Blackjack.BackJackControl;
using Blackjack.Entities;
using Xunit;
using static Blackjack.BackJackControl.BlackJackConstants;
using static Blackjack.Entities.Card.CardRank;
using static Blackjack.Entities.Card.CardSuit;

namespace BlackjackTests.ControlTests
{
    public class ScorerTests
    {
        
        // Unit tests validating the value of cards in hand

        private readonly Hand _hand = new Hand();
        private List<Card> _cardsInHand;

        [Fact]
        public void CalculateValueOfHand_NumericCards()
        {
            _cardsInHand = new List<Card>(){new Card(Eight, Club), new Card(Four, Heart)};
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(12, Scorer.CalculateValueOfHand(_hand));
        }
        
        [Fact]
        public void CalculateValueOfHand_FaceCards()
        {
            _cardsInHand = new List<Card>(){new Card(King, Club), new Card(Queen, Heart)};
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(20, Scorer.CalculateValueOfHand(_hand));
        }
        
        [Fact]
        public void CalculateValueOfHand_AceValue1WhenOtherCardsAddUpToMoreThan10()
        {
            _cardsInHand = new List<Card>()
            {
                new Card(Seven, Spade), new Card(Ace, Heart),
                new Card(Five, Heart),
            };
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(13, Scorer.CalculateValueOfHand(_hand));
        }
        
        [Fact]
        public void CalculateValueOfHand_AceValue11WhenOtherCardsAddUpToLessThan10()
        {
            _cardsInHand = new List<Card>(){new Card(Nine, Diamond), new Card(Ace, Spade)};
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(20, Scorer.CalculateValueOfHand(_hand));
        }
        
        [Fact]
        public void CalculateValueOfHand_TwoAcesWithOneAceBeing11()
        {
            _cardsInHand = new List<Card>()
            {
                new Card(Six, Heart), new Card(Ace, Heart),
                new Card(Ace, Diamond)
            };
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(18, Scorer.CalculateValueOfHand(_hand));
        }
        
        [Fact]
        public void CalculateValueOfHand_TwoAcesWithNoAceBeing11()
        {
            _cardsInHand = new List<Card>(){new Card(Ace, Club), new Card(Three, Heart),
                new Card(Ace, Diamond), new Card(Queen, Heart)};
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(15, Scorer.CalculateValueOfHand(_hand));
        }
        
        [Fact]
        public void CalculateValueOfHand_ThreeAcesWithWithNoAceBeing11()
        {
            _cardsInHand = new List<Card>(){new Card(Ace, Spade), new Card(Ace, Heart),
                new Card(Ace, Club), new Card(Ten, Heart)};
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(13, Scorer.CalculateValueOfHand(_hand));
        }
        
        [Fact]
        public void CalculateValueOfHand_ThreeAcesWithWithOneAceBeing11()
        {
            _cardsInHand = new List<Card>(){new Card(Two, Heart), new Card(Ace, Diamond),
                new Card(Ace, Club), new Card(Ace, Heart)};
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(15, Scorer.CalculateValueOfHand(_hand));
        }
        
        [Fact]
        public void CalculateValueOfHand_FourAces()
        {
            _cardsInHand = new List<Card>(){new Card(Ace, Spade), new Card(Ace, Diamond),
                new Card(Ace, Club), new Card(Ace, Heart)};
            _hand.CardsInHand = _cardsInHand;
            Assert.Equal(14, Scorer.CalculateValueOfHand(_hand));
        }
        
        // Unit tests for Deciding winner
        
        [Fact]
        public void DecideWinner_PlayerHasBlackjackDealerDoesnt_ReturnsPlayerWins()
        {
            Assert.Equal(Winner.Player, Scorer.DecideWinner(21, 15));
        }

        [Fact]
        public void DecideWinner_PlayerAndDealerBothHaveBlackjack_IsTied()
        {
            Assert.Equal(Winner.Tie, Scorer.DecideWinner(21, 21));
        }

        [Fact]
        public void DecideWinner_DealerBustsPlayerDoesnt_ReturnsPlayerWins()
        {
            Assert.Equal(Winner.Player, Scorer.DecideWinner(15, 22));
        }

        [Fact]
        public void DecideWinner_PlayerBusts_ReturnsDealerWins()
        {
            Assert.Equal(Winner.Dealer, Scorer.DecideWinner(22, 0));
        }

        [Fact]
        public void DecideWinner_NoBustPlayerCloseTo21_ReturnsPlayerWins()
        {
            Assert.Equal(Winner.Player, Scorer.DecideWinner(18, 15));
        }

        [Fact]
        public void DecideWinner_NoBustDealerCloseTo21_ReturnsDealerWins()
        {
            Assert.Equal(Winner.Dealer, Scorer.DecideWinner(15, 18));
        }

        [Fact]
        public void DecideWinner_NoBustDealerHasBlackjack_ReturnsDealerWins()
        {
            Assert.Equal(Winner.Dealer, Scorer.DecideWinner(19, 21));
        }

        [Fact]
        public void DecideWinner_NoBustPlayerAndDealerHaveSameScore_IsTied()
        {
            Assert.Equal(Winner.Tie, Scorer.DecideWinner(20, 20));
        }
    }
}