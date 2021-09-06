using Blackjack.BackJackControl;
using static Blackjack.BackJackControl.BlackJackConstants;

namespace Blackjack.Entities
{
    internal class Game
    {
        public Deck Deck { get; set; }
        public Hand Player { get; set; }
        public Hand Dealer { get; set; }
        private int _playerValue;
        private int _dealerValue;

        public int PlayerValue
        {
            get
            {
                _playerValue = Scorer.CalculateValueOfHand(Player);
                return _playerValue;
            }
        }
        public int DealerValue
        {
            get
            {
                _dealerValue = Scorer.CalculateValueOfHand(Dealer);
                return _dealerValue;
            }
        }
        
        private Winner _winner;

        public Winner Winner
        {
            get
            {
                _winner = Scorer.DecideWinner(PlayerValue, DealerValue);
                return _winner;
            }
        }

        public Game()
        {
            Player = new Hand();
            Dealer = new Hand();
            Deck = new Deck();
            Deck.ShuffleDeck();
        }

        public void DrawInitialHand()
        {
            Player.CardsInHand.Add(Deck.GetNextCard());
            Player.CardsInHand.Add(Deck.GetNextCard());
            Dealer.CardsInHand.Add(Deck.GetNextCard());
            Dealer.CardsInHand.Add(Deck.GetNextCard());
            Scorer.CalculateValueOfHand(Player);
            Scorer.CalculateValueOfHand(Dealer);
        }

        public void AddCardToPlayer(Card card)
        {
            Player.CardsInHand.Add(card);
        }

        public void AddCardToDealer(Card card)
        {
            Dealer.CardsInHand.Add(card);
        }
    }
}