using Blackjack.BackJackControl;
using Blackjack.Entities;
using Xunit;
using static Blackjack.BackJackControl.BlackJackConstants;

namespace BlackjackTests
{
    public class UnitTests
    {
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