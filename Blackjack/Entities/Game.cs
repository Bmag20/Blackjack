using Blackjack.BackJackControl;
using static Blackjack.BackJackControl.BlackJackConstants;

namespace Blackjack.Entities
{
    internal class Game
    {
        public Deck Deck { get; set; }
        public Hand Player { get; set; }
        public Hand Dealer { get; set; }
        private Winner _winner;
        public Winner Winner 
        {
            get 
            {
                _winner = Scorer.DecideWinner(Player.Value, Dealer.Value);
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
            Player.AddCard(Deck.GetNextCard());
            Player.AddCard(Deck.GetNextCard());
            Dealer.AddCard(Deck.GetNextCard());
            Dealer.AddCard(Deck.GetNextCard());
        }

        public void AddCardToPlayer(Card card)
        {
            Player.AddCard(card);
            Scorer.CalculateValueOfHand(Player);
        }

        public void AddCardToDealer(Card card)
        {
            Dealer.AddCard(card);
            Scorer.CalculateValueOfHand(Dealer);
        }

        public void FinaliseWinner()
        {
            Scorer.DecideWinner(Player.Value, Dealer.Value);
        }
    }
}